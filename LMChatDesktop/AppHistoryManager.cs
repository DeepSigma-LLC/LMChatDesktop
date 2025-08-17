using LMChatDesktop.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    internal class AppHistoryManager
    {
        private string HistoryFileName = "app_history.json";
        private string HistoryConfigDirectory { get; }
        private string PrivateChatDirectory{ get; }
        internal AppHistoryManager(string history_config_directory, string private_chat_directory)
        {
            this.HistoryConfigDirectory = history_config_directory;
            this.PrivateChatDirectory = private_chat_directory;
        }
        internal ObservableCollection<ItemViewModel<MessageHistory>> GetParsedChatHistory()
        {
            string[] chat_file_paths = GetAllChatFiles();

            Dictionary<Guid, MessageHistory> Chats = new Dictionary<Guid, MessageHistory>();
            foreach(string chat_file_path in chat_file_paths)
            {
                string chat_json = System.IO.File.ReadAllText(chat_file_path);
                MessageHistory chat = new(); //"Serialize json";
                bool parse_successful = Guid.TryParse(Path.GetFileNameWithoutExtension(chat_file_path), out Guid parsed_guid);
                if (parse_successful)
                {
                    Chats.Add(parsed_guid, chat);
                }
                
            }

            string JSON_text = System.IO.File.ReadAllText(GetHistoryFilePath());
            HashSet<ItemViewModelBase> all_chats = new(); //"Serialize json text";

            ObservableCollection<ItemViewModel<MessageHistory>> results = [];
            foreach (ItemViewModelBase chat in all_chats)
            {
                MessageHistory history = Chats[chat.Guid];
                results.Add(new ItemViewModel<MessageHistory>(history, chat.Label, chat.ToolTipLabel, chat.SymbolIcon));
            }
            
            return results;
        }

        private string GetHistoryFilePath()
        {
            return System.IO.Path.Combine(HistoryConfigDirectory, HistoryFileName);
        }

        private string[] GetAllChatFiles()
        {
            return Directory.GetDirectories(PrivateChatDirectory); //implement method to return all chat file paths. Get from OS library.
        }
    }
}
