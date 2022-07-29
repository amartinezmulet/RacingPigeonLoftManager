using RPLM.BL.DrawingTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPLM.BL.Helpers;
using RPLM.BL.Models;

namespace RPLM.BL.ConsoleUI
{
    public class Input
    {
        private Pigeon pigeon;
        //Variables from band information
        private string bandOrganization;
        private string bandYear;
        private string bandClubCode;
        private string bandSerialNumber;

        private string pigeonColor;
        private string pigeonSex;
        private DateTime? pigeonHatchDate;
        private string pigeonOrigen;
        private string pigeonStrain;
        private string pigeonStatus;
        private string pigeonSireId;
        private string pigeonDamId;

        public Input()
        {
            pigeon = new Pigeon();
        }

        public Pigeon PigeonData()
        {
            
            BandInformation();
            pigeon.BandOrganization = bandOrganization;
            pigeon.BandYear = bandYear;
            pigeon.BandClubCode = bandClubCode;
            pigeon.BandSerialNumber = bandSerialNumber;

            PigeonColor();
            pigeon.Color = pigeonColor;

            PigeonSex();
            pigeon.Sex = pigeonSex;

            HatchDate();
            pigeon.HatchDate = pigeonHatchDate;

            Origin();
            pigeon.Origin = pigeonOrigen;

            Strain();
            pigeon.Strain = pigeonStrain;

            Status();
            pigeon.Status = pigeonStatus;

            SireAndDamBandId();
            pigeon.SireBandId = pigeonSireId;
            pigeon.DamBandId = pigeonDamId;

            return pigeon;
        }

        private void BandInformation()
        {
            int cursorLeft = 0;
            int cursorTop = 0;

            bool correctBandInformation = false;
            bool rigthInput;

            string bandId;

            while (!correctBandInformation)
            {
                Console.Clear();
                Console.WriteLine("Band Information");
                Console.WriteLine("================");
                Console.WriteLine("Band numbers are in a series of letters & numbers as shown below.");
                Console.WriteLine("EXAMPLE= the band may read-->AU2022LOU1234");
                Console.WriteLine("(1) - AU   - is the national organization that has registered the bird,");
                Console.WriteLine("             in this case the American Racing Pigeon Union, Inc.");
                Console.WriteLine("             The band can also have ARPU, IF, CU, ATB, NBRC, or IPB in this position.");

                Console.WriteLine("(2) - 2022 - is the year the bird was hatched and banded/registered.");
                Console.WriteLine("(3) - LOU  - is a letters representing the pigeon club the band is registered to");
                Console.WriteLine("            (no two clubs have the same registration letters - and they have one, two or three letters).");
                Console.WriteLine("(4) - 1234 - A one-up number unique to each pigeon based on the club letters.\r\n");
                Console.WriteLine("Now that you understand how to read the band, please enter the band information\r\n");



                Console.Write("Enter the national organization (1): ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
                do
                {
                    rigthInput = InputValidator.IsValidStrigWithNoNumbers(input: out bandOrganization);

                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);

                bandOrganization = bandOrganization.Replace(" ", string.Empty).ToUpper();
                pigeon.BandOrganization = bandOrganization;

                //Year Console Input

                Console.Write("Enter the year the bird was banded/registered (2): ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;

                do
                {
                    rigthInput = InputValidator.IsValidYear(input: out bandYear);
                    

                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);

                pigeon.BandYear = bandYear;

                //Pigeon's club Console Input

                Console.Write("Enter the letters representing the pigeon's club the band is registered to (3): ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
                do
                {
                    rigthInput = InputValidator.IsValidStrigWithNoNumbers(input: out bandClubCode);
                    

                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);

                bandClubCode = bandClubCode.Replace(" ", string.Empty).ToUpper();
                pigeon.BandClubCode = bandClubCode;


                bandClubCode = bandClubCode.Replace(" ", string.Empty).ToUpper();

                //Band Serial Number Console Input

                Console.Write("Enter the band serial # (4): ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;

                do
                {
                    rigthInput = InputValidator.IsIntegerNumber(input: out bandSerialNumber);
                    

                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);

                pigeon.BandSerialNumber = bandSerialNumber;
                bandId = string.Concat(bandOrganization, bandYear, bandClubCode, bandSerialNumber);
                
                Console.Write($"\r\nDoes the pigeon's band you entered reads {bandId} ");

                correctBandInformation = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';



            } // Exits if correctBandInformation = true
        }
        /*********************************************************************************************************/
        private void PigeonColor()
        {
            string[] colors = {
                                "Blue bar",
                                "Blue bar piebald",
                                "Blue bar splash",
                                "Blue bar white flight",
                                "Blue check",
                                "Blue check piebald",
                                "Blue check splash",
                                "Blue check white flight",
                                "Black",
                                "Brown",
                                "Blue splash",
                                "Black splash",
                                "Brown splash",
                                "Chocolate",
                                "Dirty blue bar",
                                "Dark check",
                                "Dark check pied",
                                "Dark check splash",
                                "Dark check white flight",
                                "Grizzles",
                                "Indigo",
                                "Lavender",
                                "Pencil",
                                "Red bar",
                                "Red bar piebald",
                                "Red bar splash",
                                "Red bar white flight",
                                "Red check",
                                "Red check piebald",
                                "Red check splash",
                                "Red check white flight",
                                "Red splash",
                                "Slate",
                                "Ticked bird",
                                "White",
                                "Yellow"
             };

            bool correctColor = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Pigeon's basic colors");
                Console.WriteLine("=====================");
                Console.WriteLine("\r\nPlease use up and down arrow keys and press enter to select the pigeon color\r\n");
                

                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                int colorChoice = InputValidator.ChooseListBoxItem(colors, Console.CursorLeft, Console.CursorTop, ConsoleColor.Blue, ConsoleColor.White);

                Console.CursorLeft = cursorLeft;
                Console.CursorTop = cursorTop + 37;

                Console.ResetColor();
                Console.CursorVisible = true;

                pigeonColor = colors[colorChoice - 1];

                Console.Write($"You chose \u0022{pigeonColor}\u0022");
                correctColor = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';


            } while (!correctColor);
        }
        /*****************************************************************************************************************/
        private void PigeonSex()
        {
            string[] sex = {"Cock", "Hen", "Unknown" };

            bool correctSex = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Pigeon's Sex");
                Console.WriteLine("============");
                Console.WriteLine("\r\nPlease use up and down arrow keys and press enter to select the pigeon sex");


                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                int sexChoice = InputValidator.ChooseListBoxItem(sex, Console.CursorLeft, Console.CursorTop, ConsoleColor.Blue, ConsoleColor.White);

                Console.CursorLeft = cursorLeft;
                Console.CursorTop = cursorTop + 37;

                Console.ResetColor();
                Console.CursorVisible = true;

                pigeonSex = sex[sexChoice - 1];

                Console.Write($"You chose \u0022{pigeonSex}\u0022 ");
                correctSex = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';


            } while (!correctSex);
        }

        /*****************************************************************************************************************/
        private void HatchDate()
        {
            int cursorLeft = 0;
            int cursorTop = 0;

            bool correctHatchDate = false;
            bool rigthInput;


            while (!correctHatchDate)
            {
                Console.Clear();
                Console.WriteLine("Hatch Date Information");
                Console.WriteLine("======================");
                Console.WriteLine("What is \u0022Hatch Date\u0022");
                Console.WriteLine("Hatch date is the date that your pigeon came out of its egg by breaking the shell");
                Console.WriteLine("Please type the date of the pigeon jus type it in the following format mm/dd/yyyy");
                Console.WriteLine("Ex. 02/07/2021");
                Console.WriteLine("If you don't know the hatch date just press enter to leave it empty or unknown\r\n");

                Console.Write("Please enter hatch date or just press enter if unknown: ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
                string consoleInput;
                do
                {
                    consoleInput = Console.ReadLine();
                    rigthInput = InputValidator.IsANullableDateTime(consoleInput);

                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);
                DateTime date;
                bool isSuccess = DateTime.TryParseExact(consoleInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                pigeonHatchDate = isSuccess ? date as DateTime? : null;

                Console.Write($"\r\nIs the Hatch Date {pigeonHatchDate} ");

                correctHatchDate = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y' ? true : false;



            } // Exits if the hatch date information = true
        }

        /*****************************************************************************************************************/

        private void Origin()
        {
            string[] origin = { "Ancestor", "Bred", "Gift", "Purchased" };

            bool correctOrigin = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Pigeon's Origin");
                Console.WriteLine("===============");
                Console.WriteLine("\r\nPlease use up and down arrow keys and press enter to select the \u0022Pigeon's Origin\u0022");


                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                int originChoice = InputValidator.ChooseListBoxItem(origin, Console.CursorLeft, Console.CursorTop, ConsoleColor.Blue, ConsoleColor.White);

                Console.CursorLeft = cursorLeft;
                Console.CursorTop = cursorTop + 37;

                Console.ResetColor();
                Console.CursorVisible = true;

                pigeonOrigen = origin[originChoice - 1];

                Console.Write($"You chose \u0022{pigeonOrigen}\u0022");
                correctOrigin = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';


            } while (!correctOrigin);
        }

        /****************************************************************************************************************/

        private void Strain()
        {
            string[] strain = { "Dijkstra", "Houben", "Janssen", "Ludo Claessens", "Meuleman", "Trenton", "Unknown" };

            bool correctStrain = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Pigeon's Strain");
                Console.WriteLine("===============");
                Console.WriteLine("The pigeon strain is the ancestry, lineage,the descendants of a common ancestor;");
                Console.WriteLine("race; or stock line; a line of pigeons differentiated from its main species ");
                Console.WriteLine("or race by certain generally superior qualities; ");
                Console.WriteLine("Choose your pigeon's strain from the most popular racing pigeons in US");
                Console.WriteLine("\r\nPlease use up and down arrow keys and press enter to select the \u0022Pigeon's Strain\u0022");


                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                int strainChoice = InputValidator.ChooseListBoxItem(strain, Console.CursorLeft, Console.CursorTop, ConsoleColor.Blue, ConsoleColor.White);

                Console.CursorLeft = cursorLeft;
                Console.CursorTop = cursorTop + 37;

                Console.ResetColor();
                Console.CursorVisible = true;

                pigeonStrain = strain[strainChoice - 1];

                Console.Write($"You chose \u0022{pigeonStrain}\u0022");
                correctStrain = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';


            } while (!correctStrain);
        }

        /****************************************************************************************************************/

        private void Status()
        {
            string[] status = { "Archive", "Breeding", "Dead", "Gifted", "Lost", "Racing", "Squeaker", "Standby" };

            bool correctStatus = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Pigeon's Status in Loft");
                Console.WriteLine("=======================");
                
                Console.WriteLine("\r\nPlease use up and down arrow keys and press enter to select the \u0022Pigeon's Status\u0022");


                var cursorLeft = Console.CursorLeft;
                var cursorTop = Console.CursorTop;

                int statusChoice = InputValidator.ChooseListBoxItem(status, Console.CursorLeft, Console.CursorTop, ConsoleColor.Blue, ConsoleColor.White);

                Console.CursorLeft = cursorLeft;
                Console.CursorTop = cursorTop + 37;

                Console.ResetColor();
                Console.CursorVisible = true;

                pigeonStatus = status[statusChoice - 1];

                Console.Write($"You chose \u0022{pigeonStatus}\u0022");
                correctStatus = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';


            } while (!correctStatus);
        }

        /****************************************************************************************************************/

        private void SireAndDamBandId()
        {
            int cursorLeft = 0;
            int cursorTop = 0;

            bool correctSireAndDamBandInformation = false;
            bool rigthInput;

            //string bandId;

            while (!correctSireAndDamBandInformation)
            {
                Console.Clear();
                Console.WriteLine("Sire & Dam Band Information");
                Console.WriteLine("===========================\r\n");
                Console.WriteLine("\u0022Sire\u0022 is the pigeon's father \r\n");
                Console.WriteLine("\u0022Dam\u0022 is the pigeon's mother \r\n");

                Console.WriteLine("Band numbers are in a series of letters & numbers as shown below.");
                Console.WriteLine("Ex. The band may read-->AU2018LOU3657\r\n");
                
                Console.Write("Please enter the pigeon's Sire band information: ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;

                do
                {
                    rigthInput = InputValidator.IsValidStrigWithNumbers(input: out pigeonSireId);


                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);

                Console.Write("Please enter the pigeon's Dam band information: ");

                rigthInput = false;
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;

                do
                {
                    rigthInput = InputValidator.IsValidStrigWithNumbers(input: out pigeonDamId);


                    if (!rigthInput)
                    {
                        InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                    }

                } while (!rigthInput);


                Console.Write($"Is the pigeon's Sire and Dam band information you entered ");

                correctSireAndDamBandInformation = InputValidator.YesOrNotChoice("Correct (Y/N)?: ") == 'Y';
            } // Exits if correctBandInformation = true
        }

    }
}
