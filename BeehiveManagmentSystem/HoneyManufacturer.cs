using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.25f;
        public override float CostPerShift => 1.7f;
        public HoneyManufacturer():base("Honey Manufacturer") { }
        protected override void DoJob()
        {
            //HoneyVault.ConsumeHoney(CostPerShift);
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
