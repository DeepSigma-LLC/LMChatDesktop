using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    public class Message
    {
        public string MsgText { get; set; } = "";
        public DateTime MsgDateTime { get; set; } = DateTime.Now;
        public HorizontalAlignment MsgAlignment { get; set; } = HorizontalAlignment.Left;
    }
}
