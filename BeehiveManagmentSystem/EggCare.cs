using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class EggCare:Bee
    {
        private const float CARE_PROGRESS_PER_SHIFT = 0.15F;
        public override float CostPerShift => 1.95f ;
        private Queen queen;
        public EggCare(Queen queen):base("Egg Care") { this.queen = queen; }
        protected override void DoJob()
        {
             queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
