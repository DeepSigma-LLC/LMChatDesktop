using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop
{
    internal static class ModelConstructor
    {
        internal static LMModelConfig GetConfig()
        {
            LMModelConfig config = new();
            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "OpenAI",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "GPT-4o", ModelName = "gpt-4o", Description = "Great for quick anwsers and writting", WebSearchEnabled = true, DeepResearchEnabled = true },
                    new LMModel() { FriendelyModelName = "GPT-4.1", ModelName = "gpt-4.1", Description = "Great for coding and visual", WebSearchEnabled = true, DeepResearchEnabled = true },
                    new LMModel() { FriendelyModelName = "GPT-5", ModelName = "gpt-5", Description = "Intelligent routing", WebSearchEnabled = true }
                }
            });

            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "Anthropic",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "Claude 3", ModelName = "claude-3", Description = "Claude 3 model" },
                    new LMModel() { FriendelyModelName = "Claude 3 Sonnet", ModelName = "claude-3-sonnet", Description = "Claude 3 Sonnet model" }
                }
            });

            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "Azure",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "Azure GPT-4", ModelName = "azure-gpt-4", Description = "Great for writting and quick answers" },
                    new LMModel() { FriendelyModelName = "Azure GPT-3.5", ModelName = "azure-gpt-3.5", Description = "Azure GPT-3.5 model" }
                }
            });

            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "Ollama",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "Ollama Llama 2", ModelName = "ollama-llama-2", Description = "Ollama Llama 2 model" },
                    new LMModel() { FriendelyModelName = "Ollama Mistral", ModelName = "ollama-mistral", Description = "Ollama Mistral model" }
                }
            });

            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "HuggingFace",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "HuggingFace GPT-Neo", ModelName = "huggingface-gpt-neo", Description = "HuggingFace GPT-Neo model" },
                    new LMModel() { FriendelyModelName = "HuggingFace BERT", ModelName = "huggingface-bert", Description = "HuggingFace BERT model" }
                }
            });

            config.ModelProviders.Add(new LMModelProvider()
            {
                Name = "DeepSigma",
                Models = new List<LMModel>()
                {
                    new LMModel() { FriendelyModelName = "v.1", ModelName = "DeepSigma v.1", Description = "Custom transformer model" }
                }
            });

            return config;
        }
    }
}
