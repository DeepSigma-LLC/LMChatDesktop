using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI
{
    public class Category : CategoryBase
    {
        public string Name { get; set; } = "Undefined";
        public string Tooltip { get; set; } = "No tooltip provided";
        public Symbol Glyph { get; set; } = Symbol.Play;
        public Category()
        {
            
        }
    }

}
