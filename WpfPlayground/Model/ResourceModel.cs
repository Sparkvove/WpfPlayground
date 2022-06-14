using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPlayground.Model
{
    public class ResourceModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public ResourceModel(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
