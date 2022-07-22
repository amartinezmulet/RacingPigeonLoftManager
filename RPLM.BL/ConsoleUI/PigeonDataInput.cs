using RPLM.BL.DrawingTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.ConsoleUI
{
    public class PigeonDataInput:Pigeon
    {
        //***************************************************************
        Draw draw = new Draw();

        /// <summary>
        /// Gets the band identifier from console input.
        /// </summary>
        /// <param name="leftUpperRow">The column position of the cursor.numbered from left to right starting at 1</param>
        /// <param name="topUpperRow">The row position of the cursor. numbered from top to bottom starting at 1 </param>
        /// <param name="foregroundColor">Sets the foreground color of the console.</param>
        /// <param name="backgroundColor">Sets the background color of the console.</param>
        /// <returns></returns>
        public void GetBandIdFromConsoleInput(int leftUpperRow, int topUpperRow, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {


            Console.SetCursorPosition(leftUpperRow, topUpperRow);

            bool correctBandInformation = false;
            string organization = "", year = "", club = "", serialNumber = "";

            Console.ResetColor();

            var columnPosition = leftUpperRow;
            var rowPosition = topUpperRow;

            Console.ResetColor();
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;



            while (!correctBandInformation)
            {
                draw.Container(leftUpperRow - 1, topUpperRow - 1, 40, 7, "Band Information", foregroundColor, backgroundColor);
                //Input Organization
                rowPosition++;

                BandOrganization = GetData("Organization", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);

                //draw.WriteColorString("Organization: ", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                // = Console.ReadLine();

                //Input Year
                rowPosition++;
               // BandYear = GetData("Year", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                //draw.WriteColorString("Year: ", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                //year = Console.ReadLine();

                //Input Club
                rowPosition++;
                draw.WriteColorString("Club: ", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                club = Console.ReadLine();

                //Input Band Serial Number
                rowPosition++;
                draw.WriteColorString("Serial #: ", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                serialNumber = Console.ReadLine();

                //Asking if all entered data is correct
                rowPosition += 4;
                draw.WriteColorString("Is the Information correct? (Y/N): ", columnPosition, rowPosition, ConsoleColor.Blue, ConsoleColor.White);
                correctBandInformation = (Console.ReadLine().ToUpper() == "Y") ? true : false;

                if (!correctBandInformation)
                {
                    rowPosition = topUpperRow;
                }
                draw.CleanUpConsole();
            }
        }

        public string GetData(string input, int cursorColumn, int cursorRow, ConsoleColor background, ConsoleColor foreground)
        {

            string output = null;
            while (String.IsNullOrEmpty(output))
            {
                
                draw.WriteColorString($"{new string(' ', input.Length+5)}: ", cursorColumn, cursorRow, background, foreground);
                draw.WriteColorString($"{input}: ", cursorColumn, cursorRow, background, foreground);
                output = Console.ReadLine();
            }
            return output;
        }



        //***************************************************************
        public DateTime? GetHatchDate(string input)
        {
            
            DateTime date;
            return DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : null;
        }
    }
}
