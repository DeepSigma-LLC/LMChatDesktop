using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatPage : Page
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            InvertedListView.Items.Add(new Message
            {
                MsgText = MessageInput.Text.Trim(),
                MsgDateTime = DateTime.Now,
                MsgAlignment = HorizontalAlignment.Right
            });
            MessageInput.Text = string.Empty;
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InvertedListView.Items.Clear();
        }
    }
}
