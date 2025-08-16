using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMChatDesktop.UI
{
    public class ItemViewModel<T>
    {
        public string Label { get; }
        public T Value { get; }

        public ItemViewModel(string label, T value)
        {
            Label = label;
            Value = value;
        }

        public ItemViewModel(string label)
        {
            Label = label;

            if (typeof(T) == typeof(string))
            {
                Value = (T)(object)label;
            }
            else
            {
                throw new InvalidOperationException("Value must be provided for non-string types.");
            }
        }
    }
}
