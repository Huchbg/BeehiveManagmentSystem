using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    internal class Queen:Bee
    {
        private float eggs=0;
        private float unassignedWorkers=3f;
        private const float EGGS_PER_SHIFT = .45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = .5f;

        private Bee[] workers=new Bee[0];
        public override float CostPerShift => 2.15f ;
        public string StatusReport { get; private set; }
        public Queen():base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }
        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                default:
                    break;
            }
            UpdateStatusReport();
        }
        
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs>=eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
                $"\nEgg count: {eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
                $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Egg Care")}\n{WorkerStatus("Honey Manufacturer")}" +
                $"\nTOTAL WORKERS: {workers.Length}";
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers*HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers>=1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length-1] = worker;
            }
        }
        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
            {
                if (worker.Job==job)
                {
                    count++;
                }
            }

            //string s = (count == 1) ? "" : "s";
            
            string s = "s";
            if (count == 1)
            {
                s = "";
            }

            return $"{count} {job} bee{s}";
        }
    }
}
