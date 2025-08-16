using LMChatDesktop.UI;
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
        public MainWindow()
        {
            InitializeComponent();
            Loaded();
            contentFrame.Navigate(typeof(ChatPage));
        }

        public void NavigationView_SelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {

        }

        private void Loaded()
        {
            Categories.Add(new Category { Name = "Home", Glyph = Symbol.Home, Tooltip = "This is category 1" });
            Categories.Add(new Category { Name = "Chat 1", Glyph = Symbol.Message, Tooltip = "This is category 2" });
            Categories.Add(new Category { Name = "Chat 2", Glyph = Symbol.Message, Tooltip = "This is category 3" });
            Categories.Add(new Category { Name = "Chat 3", Glyph = Symbol.Message, Tooltip = "This is category 4" });
        }

    }
}
