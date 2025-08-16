using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI.Models
{
    internal class MessageHistory
    {
        internal ObservableCollection<Message> Messages = [];

        public MessageHistory()
        {
            
        }

    }
}
