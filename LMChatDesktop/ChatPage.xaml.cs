using LMChatDesktop.UI.Models;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMChatDesktop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatPage : Page, INotifyPropertyChanged
    {
        private LMModelConfig _modelConfig = ModelConstructor.GetConfig();
        private ObservableCollection<ItemViewModel<string>> Models { get; set; } = [];
        private ObservableCollection<ItemViewModel<string>> ModelProviders { get; set; } = [];
        private MessageHistory MessageHistory { get; set; } = new();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ItemViewModel<string>? _selectedModelItem;
        public ItemViewModel<string>? SelectedModelItem
        {
            get => _selectedModelItem;
            set { _selectedModelItem = value; OnPropertyChanged(); RebuildModelSplitFlyout(); }
        }

        private ItemViewModel<string>? _selectedModelProviderItem;
        public ItemViewModel<string>? SelectedModelProviderItem
        {
            get => _selectedModelProviderItem;
            set { _selectedModelProviderItem = value; LoadModels();  OnPropertyChanged(); RebuildModelProviderSplitFlyout(); RebuildModelSplitFlyout(); if (Models.Count > 0) SelectedModelItem = Models[0]; }
        }
        public ChatPage()
        {
            InitializeComponent();
            LoadProviderSources();
            RebuildModelProviderSplitFlyout();
            if (ModelProviders.Count > 0) SelectedModelProviderItem = ModelProviders[0];
            if (Models.Count > 0) SelectedModelItem = Models[0];

            Models.CollectionChanged += Models_CollectionChanged; // Keep flyout in sync if the list changes dynamically
        }

        private void Models_CollectionChanged(object? s, NotifyCollectionChangedEventArgs e) => RebuildModelSplitFlyout();


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MessageHistory.Messages.Add(new Message
            {
                MsgText = MessageInput.Text.Trim(),
                MsgDateTime = DateTime.Now,
                IsMyMessage = true
            });

            MessageHistory.Messages.Add(new Message
            {
                MsgText = "This is an example of a system generated message!",
                MsgDateTime = DateTime.Now,
                IsMyMessage = false
            });

            MessageInput.Text = string.Empty;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InvertedListView.Items.Clear();
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            if (!ConfigurePopup.IsOpen)
            { 
                ConfigurePopup.IsOpen = true;  
                return; 
            }
            ConfigurePopup.IsOpen = false; 
        }

        private void LoadModels()
        {
            Models.Clear();
            string? selected_provider_name = SelectedModelProviderItem?.Label;
            if (string.IsNullOrWhiteSpace(selected_provider_name)) { return; }

            LMModelProvider? selectedProvider = _modelConfig.GetModelProviderByName(selected_provider_name);
            if (selectedProvider is null){ return;}

            List<LMModel> models = selectedProvider.Models;
            foreach (LMModel model in models)
            {
                Models.Add(new ItemViewModel<string>(model.ModelName, model.FriendelyModelName, model.Description ?? string.Empty));
            }
        }

        private void LoadProviderSources()
        {
            ModelProviders.Clear();
            foreach (LMModelProvider provider in _modelConfig.GetEnabledModelProviders())
            {
                ModelProviders.Add(new ItemViewModel<string>(provider.Name, provider.Name));
            }
        }

        private void RebuildModelSplitFlyout()
        {
            if (mymodels is null) return;

            var menu = new MenuFlyout();
            foreach (var m in Models)
            {
                var item = new MenuFlyoutItem { Text = m.Label, Tag = m };
                item.Click += (sender, args) =>
                {
                    SelectedModelItem = (ItemViewModel<string>)((MenuFlyoutItem)sender!).Tag!;
                };

                if(string.IsNullOrWhiteSpace(m.ToolTipLabel) ==false)
                {
                    ToolTipService.SetToolTip(item, m.ToolTipLabel);
                }
                menu.Items.Add(item);
            }
            mymodels.Flyout = menu;
        }

        private void RebuildModelProviderSplitFlyout()
        {
            if (modelProviders is null) return;

            var menu = new MenuFlyout();
            foreach (var m in ModelProviders)
            {
                var item = new MenuFlyoutItem { Text = m.Label, Tag = m };
                item.Click += (sender, args) =>
                {
                    SelectedModelProviderItem = (ItemViewModel<string>)((MenuFlyoutItem)sender!).Tag!;
                };
                menu.Items.Add(item);
            }
            modelProviders.Flyout = menu;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Message msg && !string.IsNullOrWhiteSpace(msg.MsgText))
            {
                var dp = new DataPackage();
                dp.SetText(msg.MsgText);
                Clipboard.SetContent(dp);
                Clipboard.Flush(); // Optional: persists after app closes
                ShowCopiedToast("Message copied!");
            }
        }

        private void ShowCopiedToast(string message)
        {
            CopyInfoBar.Message = message;
            CopyInfoBar.Severity = InfoBarSeverity.Success;
            CopyInfoBar.IsOpen = true;

            // auto-close after a short delay
            _ = Task.Delay(2000).ContinueWith(_ =>
            {
                DispatcherQueue.TryEnqueue(() => CopyInfoBar.IsOpen = false);
            });
        }

        private void MessageInput_KeyUp(object s, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                var shift = InputKeyboardSource.GetKeyStateForCurrentThread(VirtualKey.Shift);
                if ((shift & CoreVirtualKeyStates.Down) != CoreVirtualKeyStates.Down)
                { e.Handled = true; SendButton_Click(s, e); }
            }
        }

    }
}
