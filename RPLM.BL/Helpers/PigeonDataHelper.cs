using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.Helpers
{
    public static class PigeonDataHelper
    {
        public static Dictionary<string, Pigeon> Pigeons = new Dictionary<string, Pigeon>();

        public static void AddPigeon(Pigeon pigeon)
        {
            Pigeons.Add(pigeon.BandId, pigeon);
        }

        public static void EditPigeon(string bandIdNumber, Pigeon pigeon)
        {
            if (Pigeons.ContainsKey(bandIdNumber))
            {
                Pigeons[bandIdNumber] = pigeon;
            }
        }

        public static Pigeon GetPigeonById(string bandIdNumber)
        {
            if (Pigeons.ContainsKey(bandIdNumber))
            {
                return Pigeons[bandIdNumber];
            }

            return null;
        }

        public static void Save()
        {
            //TODO Save to Jason File
        }

        // Load pigeon data
    }
}
