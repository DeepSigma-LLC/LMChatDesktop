using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    public class LMModelConfig
    {
        public List<LMModelProvider> ModelProviders { get; set; } = [];
        public LMModelConfig()
        {
            
        }

        public IEnumerable<LMModelProvider> GetEnabledModelProviders()
        {
            return ModelProviders.Where(x => x.IsEnabled == true).OrderBy(x => x.Name);
        }

        public LMModelProvider? GetModelProviderByName(string name)
        {
            return ModelProviders.Where(x => x.IsEnabled = true).FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
