using RPLM.BL.DrawingTools;
using RPLM.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.ConsoleUI
{
    public static class Display
    {

        public static void PigeonsGroupBy(string sortBy, IEnumerable<IGrouping<string,Pigeon>> pigeonsGroupedBy)
        {
            string[] titles = { "BandId", "Color", "Sex", "Origin", "Strain", "Status", "HatchDate", "SireBandId", "DamBandId" };

            foreach (var GroupKey in pigeonsGroupedBy)
            {
                Console.Write($"\r\n{sortBy}: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(GroupKey.Key);
                

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new String('─', 112));
                Console.WriteLine($"{titles[0],-14}{titles[1],-17}{titles[2],-8}{titles[3],-10}{titles[4],-15}{titles[5],-9}{titles[6],-11}{titles[7],-15}{titles[8],-15}");
                Console.WriteLine(new String('─', 112));
                Console.ResetColor();

                foreach (var pigeon in GroupKey)
                {
                    string strHatchDate;
                    if (pigeon.HatchDate != null)
                    {
                        strHatchDate = ((DateTime)pigeon.HatchDate).ToShortDateString();
                    }
                    else
                    {
                        strHatchDate = "unknown";
                    }
                    //Console.WriteLine($"");
                    Console.WriteLine($"{pigeon.BandId,-14}{pigeon.Color,-17}{pigeon.Sex,-8}{pigeon.Origin,-10}{pigeon.Strain,-15}{pigeon.Status,-9}{strHatchDate,-11}{pigeon.SireBandId,-15}{pigeon.DamBandId,-15}");

                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new String('─', 112));
                Console.ResetColor();

            }
        }

        public static void Pigeons(List<Pigeon> PigeonList)
        {
            var pigeonsSortedByBandId = PigeonList.OrderBy(x => x.BandId);

            string[] titles = { "BandId", "Color", "Sex", "Origin", "Strain", "Status", "HatchDate", "SireBandId", "DamBandId" };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('─', 112));
            Console.WriteLine($"{titles[0],-14}{titles[1],-17}{titles[2],-8}{titles[3],-10}{titles[4],-15}{titles[5],-9}{titles[6],-11}{titles[7],-15}{titles[8],-15}");
            Console.WriteLine(new String('─', 112));
            Console.ResetColor();
            foreach (var pigeon in pigeonsSortedByBandId)
            {
                string strHatchDate;
                if (pigeon.HatchDate != null)
                {
                    strHatchDate = ((DateTime)pigeon.HatchDate).ToShortDateString();
                }
                else
                {
                    strHatchDate = "unknown";
                }
                //Console.WriteLine($"");
                Console.WriteLine($"{pigeon.BandId,-14}{pigeon.Color,-17}{pigeon.Sex,-8}{pigeon.Origin,-10}{pigeon.Strain,-15}{pigeon.Status,-9}{strHatchDate,-11}{pigeon.SireBandId,-15}{pigeon.DamBandId,-15}");


            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('─', 112));
            Console.ResetColor();
        }
        public static void PigeonInventory(int uColumn, int uRow, int lColumn, int lRow, ConsoleColor bckgrnd, ConsoleColor frgrnd)
        {
            Display.SetColors(bckgrnd, frgrnd);
            
            //Totals of pigeons in loft

            Draw.Container(uColumn+15, uRow, 15, 3, "Pigeons in Loft", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn+23, uRow+2);

            int total = Inventory.TotalOfPigeonsInLoft;
            Console.WriteLine($"{total, -4}");

            //Totals of pigeons breed in loft
            Draw.Container(uColumn, uRow+4, 15, 3, "Bred", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 7, uRow + 6);

            int bred = Inventory.TotalOfPigeonsBredInLoft;
            Console.WriteLine($"{bred,-4}");

            //Totals of pigeons received as gift
            Draw.Container(uColumn+15, uRow + 4, 15, 3, "Gift", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn+21, uRow + 6);

            int gift = Inventory.TotalOfPigeonsReceivedGift;
            Console.WriteLine($"{gift,-4}");

            //Totals of pigeons purchased
            Draw.Container(uColumn + 30, uRow + 4, 15, 3, "Purchased", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 36, uRow + 6);

            int purchased = Inventory.TotalOfPigeonsPurchased;
            Console.WriteLine($"{purchased,-4}");

            /******************************************************************************************/
            //Totals of Cocks
            Draw.Container(uColumn, uRow + 8, 15, 3, "Cocks", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 7, uRow + 10);

            int cocks = Inventory.TotalofCocksInLoft;
            Console.WriteLine($"{cocks,-4}");

            //Totals of Hens
            Draw.Container(uColumn + 15, uRow + 8, 15, 3, "Hens", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 21, uRow + 10);

            int hens = Inventory.TotalofHensInLoft;
            Console.WriteLine($"{hens,-4}");

            //Totals of unsexed
            Draw.Container(uColumn + 30, uRow + 8, 15, 3, "Unsexsed", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 36, uRow + 10);

            int unsexed = Inventory.TotalofUnsexedInLoft;
            Console.WriteLine($"{unsexed,-4}");

            /******************************************************************************************/
            //Totals of Breeders
            Draw.Container(uColumn, uRow + 12, 15, 3, "Breeders", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 7, uRow + 14);

            int breeders = Inventory.TotalOfBreeders;
            Console.WriteLine($"{breeders,-4}");

            //Totals of Squeakers
            Draw.Container(uColumn + 15, uRow + 12, 15, 3, "Squeakers", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 21, uRow + 14);

            int squeakers = Inventory.TotalOfSqueakers;
            Console.WriteLine($"{squeakers,-4}");

            //Totals of Racing
            Draw.Container(uColumn + 30, uRow + 12, 15, 3, "Racing", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 36, uRow + 14);

            int racing = Inventory.TotalOfPigeonsRacing;
            Console.WriteLine($"{racing,-4}");

            //Totals in Standby
            Draw.Container(uColumn + 45, uRow + 12, 15, 3, "Standby", bckgrnd, frgrnd);
            Console.SetCursorPosition(uColumn + 51, uRow + 14);

            int standby = Inventory.TotalOfPigeonsInStandBy;
            Console.WriteLine($"{standby,-4}");


        }
        public static void PigeonRecord(int uColumn, int uRow, int lColumn, int lRow, Pigeon pigeonRecord)
        {
            Draw.Box(uColumn,uRow,lColumn,lRow, ConsoleColor.Gray,ConsoleColor.Black, true);
            Draw.Container(uColumn+2, uRow+1, 34,5, "Band: "+ pigeonRecord.BandId, ConsoleColor.Gray, ConsoleColor.DarkRed);
            
            WriteColorString("Organization:", uColumn+3, uRow+2, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.BandOrganization, 16, 2, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Year:", uColumn+11, uRow+3, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.BandYear, uColumn+16, uRow+3, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Club:", uColumn+11, uRow+4, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.BandClubCode, uColumn+16, uRow+4, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Serial#:", uColumn+8, uRow+5, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.BandSerialNumber, 16, 5, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Color:", uColumn+11, uRow+7, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.Color, uColumn+16, uRow+7, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Sex:", uColumn+12, uRow+8, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.Sex, uColumn+16, uRow+8, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Hatch Date:", uColumn+5, uRow+9, ConsoleColor.Gray, ConsoleColor.Black);

            string strHatchDate;
            if (pigeonRecord.HatchDate != null)
            {
                strHatchDate = ((DateTime)pigeonRecord.HatchDate).ToShortDateString();
            }
            else
            {
                strHatchDate = "unknown";
            }

            WriteColorString(strHatchDate, uColumn+16, uRow+9, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Origin:", uColumn+9, uRow+10, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.Origin, uColumn+16, uRow+10, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Strain:", uColumn+9, uRow+11, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.Strain, uColumn+16, uRow+11, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Status:", uColumn+9, uRow+12, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.Status, uColumn+16, uRow+12, ConsoleColor.Blue, ConsoleColor.White);

            Draw.Container(uColumn+2, uRow+13, 34, 3, "Parents", ConsoleColor.Gray, ConsoleColor.DarkRed);

            WriteColorString("Sire Id:", uColumn+8, uRow+14, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.SireBandId, uColumn+16, uRow+14, ConsoleColor.Blue, ConsoleColor.White);

            WriteColorString("Dam Id:", uColumn+9, uRow+15, ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(pigeonRecord.DamBandId, uColumn+16, uRow+15, ConsoleColor.Blue, ConsoleColor.White);

            Console.ResetColor();

        }

        public static void MessageBox(string message, int column, int row)
        {
            Console.CursorVisible = false;
            var width = message.Length + 2;
            Draw.Container(column, row, width, 3, "\u0020Message\u0020", ConsoleColor.Gray, ConsoleColor.Black);
            WriteColorString(message, column+1,row+1, ConsoleColor.Gray, ConsoleColor.DarkRed);
            WriteColorString("Please hit enter to continue", column + 1, row + 2, ConsoleColor.Gray, ConsoleColor.Black);
            Console.ResetColor();
            Console.CursorVisible = true;

        }

        public static void WriteColorString(string s, int col, int row, ConsoleColor background, ConsoleColor foreground)
        {

            SetColors(background, foreground);
            // write string
            Console.SetCursorPosition(col, row);
            Console.Write(s);
        }

        public static void SetColors(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        public static void TypeWrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(30);
            }
        }

    }
}
