using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI.Models
{
    public class ItemViewModelBase
    {
        public string Label { get; init; } = string.Empty;
        public string? ToolTipLabel { get; set; }
        public Symbol? SymbolIcon { get; set; }
        public Guid Guid { get; set; }

    }

}
