using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    public class LMModel
    {
        public required string FriendelyModelName { get; init; }
        public required string ModelName { get; init; }
        public bool ReasoningModel { get; set; } = false;
        public string? Description { get; set; }
        public bool IsEnabled { get; set; } = true;
        public bool ReasoningEnabled { get; set; } = false;
        public bool DeepResearchEnabled { get; set; } = false;
        public bool WebSearchEnabled { get; set; } = false;
        public bool CodeInterpreterEnabled { get; set; } = false;
        public bool ImageGenerationEnabled { get; set; } = false;
        public bool AudioGenerationEnabled { get; set; } = false;
        public LMModel()
        {
            
        }
    }
}
