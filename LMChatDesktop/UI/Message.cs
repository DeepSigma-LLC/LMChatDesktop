using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI
{
    public class Message
    {
        public string MsgText { get; set; } = string.Empty;
        public DateTime MsgDateTime { get; set; } = DateTime.Now;
        public bool IsMyMessage { get; set; } = true;
        public HorizontalAlignment MessageAlignment
        {
            get => IsMyMessage ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }
        public float UserEvaluation { get; set; }
        public bool ExcludeFromRecord { get; set; } = false;
    }
}
