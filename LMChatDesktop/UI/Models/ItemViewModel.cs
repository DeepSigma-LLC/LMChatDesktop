using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI.Models
{
    public class ItemViewModel<T> where T : notnull
    {
        public T ItemObject { get; }
        public string Label { get; }
        public string? ToolTipLabel { get; set; }
        public Symbol? SymbolIcon { get; set; }
        public ItemViewModel(T item_object, string label, string? tool_tip_label = null, Symbol? symbol_icon = null)
        {
            Label = label;
            ItemObject = item_object;
            ToolTipLabel = tool_tip_label;
            SymbolIcon = symbol_icon;
        }
    }
}
