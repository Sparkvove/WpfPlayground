using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPlayground.Model
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public ResourceModel CarbonFiber {get; set;}
        public ResourceModel Energy { get; set; }
        public ResourceModel[] playerResources { get; set; }
        public BuildingModel CarbonFiberBuilding { get; set; }
        public int[] Multiplayers { get; set; }

        public ResourceModel[] CarbonFiberBuilding_StartingCost =
        {
            new ResourceModel("Carbon Fiber", 100),
            new ResourceModel("Energy", 20),
        };

        public PlayerModel()
        {
            Name = "Spark";

            playerResources = new ResourceModel[]
            {
                 new ResourceModel("Carbon Fiber", 500),
                 new ResourceModel("Energy", 100),
            };
            Multiplayers = new int[]
            {
                5,
                5,
            };
            CarbonFiberBuilding = new BuildingModel("Carbon Fiber Building", CarbonFiberBuilding_StartingCost, 1);

        }

        public void upgradeBuilding(BuildingModel building) 
        {
            
            for (int i = 0; i < playerResources.Length; i++)
            {
                this.playerResources[i].Value -= building.Cost[i].Value;
                building.Cost[i].Value *= 2;
            }
            building.lvl++;
            this.Multiplayers[0] += 2 * building.lvl;
        }

        public bool canUpgradeBuilding(BuildingModel building)
        {
            for (int i = 0; i < playerResources.Length; i++)
            {
                if (this.playerResources[i].Value < building.Cost[i].Value) { return false; }
            }
            return true;
        }
    }
}
