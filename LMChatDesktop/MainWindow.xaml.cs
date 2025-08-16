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
            contentFrame.Navigate(typeof(ChatPage));
        }

        public void NavigationView_SelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {

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
