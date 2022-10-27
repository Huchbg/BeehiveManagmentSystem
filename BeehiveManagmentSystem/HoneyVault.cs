using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem
{
    static class HoneyVault
    {

        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport {
            get
            {
                string returne = $"Honey left {honey} \n Nectar left{nectar}";
                if (honey<LOW_LEVEL_WARNING)
                {
                    returne += "\n LOW HONEY - ADD A HONEY MANUFACTURER";
                }
                if (nectar<LOW_LEVEL_WARNING)
                {
                    returne += "\n LOW NECTAR - ADD A NECTAR COLLECTOR";
                }
                return returne;
            } 
                }
        public static void ConvertNectarToHoney(float amount)
        {
            if (nectar<amount)
            {
                amount = nectar;
            }
            nectar = nectar - amount;
            honey = honey +amount * NECTAR_CONVERSION_RATIO;
        }
        public static bool ConsumeHoney(float amount)
        {
            if (amount < honey) { honey -= amount; return true; }
            return false;
        }
        public static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }


    }
}
