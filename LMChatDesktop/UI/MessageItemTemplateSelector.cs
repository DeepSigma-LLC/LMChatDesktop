using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI
{
    public class MessageItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? LeftTemplate { get; set; }
        public DataTemplate? RightTemplate { get; set; }
        protected override DataTemplate? SelectTemplateCore(object item, DependencyObject container)
        {
            var msg = item as Message;
            return (msg?.IsMyMessage == true) ? RightTemplate! : LeftTemplate!;
        }
    }
}
