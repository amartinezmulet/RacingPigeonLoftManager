using System;
using System.Collections.Generic;
using System.IO;
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

        public static bool ExistPigeon(string bandId)
        {
            return Pigeons.ContainsKey(bandId);
        }

        public static void Remove(string bandId)
        {
            if (Pigeons.ContainsKey(bandId))
            {
                Pigeons.Remove(bandId);
            }
        }

        public static void Save()
        {
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(Pigeons.Values.ToList(), Newtonsoft.Json.Formatting.Indented);

            //Save to file
            string fileName = "PigeonDB.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(serializedObject);
            }
        }

        public static void LoadData()
        {
            string content = null;
            string fileName = "PigeonDB.json";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    content = sr.ReadToEnd();
                }

                List<Pigeon> pigeons = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pigeon>>(content);
                Pigeons = pigeons.ToDictionary(it => it.BandId);

            }
        }
    }
}
