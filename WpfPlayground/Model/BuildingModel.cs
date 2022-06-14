using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfPlayground.Model
{
    public class BuildingModel 
    { 
        public int lvl { get; set; }
        public string Name { get; set; }
        public ResourceModel[] Cost { get; set; }
        public BuildingModel(string name, ResourceModel[] cost, int Lvl)
        {
            Name = name;
            lvl = Lvl;
            Cost = cost;
        }
    }
}
