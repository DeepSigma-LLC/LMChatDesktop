using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    public class LMModelProvider
    {
        public required string Name { get; init; }
        public string? Id { get; init; }
        public string? Description { get; init; }
        public string? Icon { get; init; }
        public bool IsEnabled { get; set; } = true;
        public List<LMModel> Models { get; set; } = [];
        public LMModelProvider()
        {
        }
        public override string ToString() => Name;
    }
}
