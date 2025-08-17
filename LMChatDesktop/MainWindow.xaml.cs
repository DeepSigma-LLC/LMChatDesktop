using LMChatDesktop.UI.Models;
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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LMChatDesktop.Pages;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMChatDesktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<Category> Categories { get; set; } = [];
        private ObservableCollection<ItemViewModel<MessageHistory>> ChatHistories { get; set; } = [];
        public MainWindow()
        {
            InitializeComponent();
            LoadChatHistory();
        }

        public void NavigationView_SelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {
            if(e.IsSettingsSelected)
            {
                content_frame.Navigate(typeof(SettingsPage));
            }
            else if(e.SelectedItem is null) // TODO update to navigate to saved message histroy
            {
                content_frame.Navigate(typeof(ChatPage), new MessageHistory());
            }
            else
            {
                //New chat selected
                content_frame.Navigate(typeof(ChatPage)); 
            }
        }

        private void LoadChatHistory()
        {
            ChatHistories.Add(new(new MessageHistory(), "New Chat", "Create a new chat", Symbol.Add));
            ChatHistories.Add(new(new MessageHistory(), "Chat 1", "Chat Number 1", Symbol.Message));
            ChatHistories.Add(new(new MessageHistory(), "Chat 2", "Chat Number 2", Symbol.Message));

            foreach(ItemViewModel<MessageHistory> chat in ChatHistories)
            {
                Categories.Add(new Category { Name = chat.Label, Glyph = chat.SymbolIcon ?? Symbol.Placeholder, Tooltip = chat.ToolTipLabel ?? string.Empty});
            }
        }
    }
}
