using RPLM.BL.DrawingTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.ConsoleUI
{
    public static class Display
    {
        public static void PigeonRecord(Pigeon pigeonRecord)
        {
            int ucolumn = 0,
                uRow = 0,
                lcolumn = 37,
                lRow = 16;
           
            Draw.Box(ucolumn,uRow,lcolumn,lRow, ConsoleColor.Gray,ConsoleColor.Black, true);
            Draw.Container(2,1,34,5, "Band: "+ pigeonRecord.BandId, ConsoleColor.Gray, ConsoleColor.Black);
            
            Draw.WriteColorString("Organization:", 3,2, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.BandOrganization, 16, 2, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Year:", 11, 3, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.BandYear, 16, 3, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Club:", 11, 4, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.BandClubCode, 16, 4, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Serial#:", 8, 5, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.BandSerialNumber, 16, 5, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Color:", 11, 7, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.Color, 16, 7, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Sex:", 12, 8, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.Sex, 16, 8, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Hatch Date:", 5, 9, ConsoleColor.Gray, ConsoleColor.Black);

            string strHatchDate;
            if (pigeonRecord.HatchDate != null)
            {
                strHatchDate = ((DateTime)pigeonRecord.HatchDate).ToShortDateString();
            }
            else
            {
                strHatchDate = "unknown";
            }

            Draw.WriteColorString(strHatchDate, 16, 9, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Origin:", 9, 10, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.Origin, 16, 10, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Strain:", 9, 11, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.Strain, 16, 11, ConsoleColor.Blue, ConsoleColor.White);

            Draw.Container(2, 12, 34, 3, "Parents", ConsoleColor.Gray, ConsoleColor.Black);

            Draw.WriteColorString("Sire Id:", 8, 13, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.SireBandId, 16, 13, ConsoleColor.Blue, ConsoleColor.White);

            Draw.WriteColorString("Dam Id:", 9, 14, ConsoleColor.Gray, ConsoleColor.Black);
            Draw.WriteColorString(pigeonRecord.SireBandId, 16, 14, ConsoleColor.Blue, ConsoleColor.White);

            Console.ResetColor();

        }
    }
}
