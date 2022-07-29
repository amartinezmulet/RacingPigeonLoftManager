using RPLM.BL.ConsoleUI;
using RPLM.BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    public partial class Program
    {
        
        public static void PigeonsRecordMenu()
        {
            bool exitApplication = false;
            string bandNumber="";
            while (!exitApplication)
            {
                int userChoice;
                bool validChoice;

                string menuHeader = "│Pigeon record     Display Pigeons       List of all Pigeons  │";

                do
                {
                    Console.Title = "Pigeon Record";
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine("┌" + new string('─', menuHeader.Length - 2) + "┐");
                    Console.WriteLine(menuHeader);
                    Console.WriteLine("├" + new string('─', menuHeader.Length - 2) + "┤");

                    Console.WriteLine("│1. Add a Pigeon    5. Born in Loft      11. In Loft          │");
                    Console.WriteLine("│2. Find a Pigeon   6. Purchased         12. By Color         │");
                    Console.WriteLine("│3. Update a Pigeon 7. Received as Gift  13. By Strain        │");
                    Console.WriteLine("│4. Delete a Pigeon 8. Given away        14. By Sex           │");
                    Console.WriteLine("│                   9. Lost              15. By Year          │");
                    Console.WriteLine("│                  10. Deceased           0. Back to Main menu│");
                    Console.WriteLine("└" + new string('─', menuHeader.Length - 2) + "┘");

                    Console.ResetColor();

                    Display.TypeWrite("\r\nSelect your choice(0 - Back to Main Menu):");

                    validChoice = Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 15;

                    if (!validChoice)
                    {
                        Display.TypeWrite("Wrong input. Please try again");
                        System.Threading.Thread.Sleep(500);
                    }

                } while (!validChoice);

                
                switch (userChoice)
                {
                    
                    //Pigeon record
                      case 1: //Add a new Pigeon
                        CleanUp();
                        
                        var pigeonDataInput = new Input();
                        Pigeon newPigeon = pigeonDataInput.PigeonData();

                        CleanUp();

                        Console.CursorTop = 20;
                        Console.CursorLeft = 0;

                        Display.PigeonRecord(0, 0, 37, 17, newPigeon);

                        var saveData = InputValidator.YesOrNotChoice("Would you like to save the above data (Y/N)?: ")=='Y' ? true : false;
                        if (saveData)
                        {
                            PigeonDataHelper.AddPigeon(newPigeon);
                            PigeonDataHelper.Save();
                        }

                        break;

                    case 2: // Finds a pigeon by Band Id
                        CleanUp();
                        Console.Title = "Find a Pigeon";

                        var exitFindAPigeon = true;

                        while (exitFindAPigeon)
                        {
                            bandNumber = ShowPigeonRecord();

                            exitFindAPigeon = InputValidator.YesOrNotChoice("\r\n\r\n\r\n\r\nDo you want to search again (Y/N): ") == 'Y' ? true : false;

                            CleanUp();
                        }

                        if (String.IsNullOrEmpty(bandNumber))
                            Console.WriteLine($"No buscastes ningun pigeon");
                        else
                            Console.WriteLine($"The pigeon you were searching for was {bandNumber}");

                        Console.ReadLine();

                        break;

                    case 3://TODO: Implement Edit or Update Pigeon Record

                        CleanUp();
                        Display.WriteColorString("Please enter the pigeon Band Number: ", 1, 0, ConsoleColor.Black, ConsoleColor.White);
                        var inputBandNumber = Console.ReadLine();

                        
                        Pigeon pigeon = PigeonDataHelper.GetPigeonById(inputBandNumber);
                        string option;
                        do
                        {
                            CleanUp();
                            option = string.Empty;
                            bool shouldBackToPigeonMenu;
                            UpdatePigeonMenu(pigeon, out shouldBackToPigeonMenu);
                            if (shouldBackToPigeonMenu) break;

                            Display.WriteColorString("\r\nPlease enter S - save, U - more updates, B - back to main menu. ", 1, 17, ConsoleColor.Black, ConsoleColor.White);
                            option = Console.ReadLine();

                        } while ("U".Equals(option, StringComparison.OrdinalIgnoreCase) || 
                                 (!"S".Equals(option, StringComparison.OrdinalIgnoreCase) &&
                                 !"B".Equals(option, StringComparison.OrdinalIgnoreCase)));

                        if ("S".Equals(option, StringComparison.OrdinalIgnoreCase))
                        {
                            PigeonDataHelper.UpdatePigeon(inputBandNumber, pigeon);
                            PigeonDataHelper.Save();
                        }
                        





                        break;

                    case 4://TODO: Implement Delete a Pigeon Record

                        CleanUp();

                        CleanUp();
                        Console.Title = "Delete a Pigeon";

                        var exitDeletePigeon = true;
                        var deletePigeon = false;

                        while (exitDeletePigeon)
                        {
                            bandNumber = ShowPigeonRecord();

                            deletePigeon = InputValidator.YesOrNotChoice("\r\n\r\n\r\n\r\nAre you sure you want delete this pigeon (Y/N): ") == 'Y' ? true : false;
                            
                            if (deletePigeon)
                            {
                                PigeonDataHelper.Remove(bandNumber);
                                PigeonDataHelper.Save();
                                Console.WriteLine("\r\nThe pigeon was deleted from your records");
                            }

                            exitDeletePigeon = InputValidator.YesOrNotChoice("\r\n\r\n\r\n\r\nDo you want delete another pigeon (Y/N): ") == 'Y' ? true : false;

                            CleanUp();
                        }

                        if (String.IsNullOrEmpty(bandNumber))
                            Console.WriteLine($"No buscastes ningun pigeon");
                        else
                            Console.WriteLine($"The pigeon you were searching for was {bandNumber}");

                        Console.ReadLine();
                        break;


                    //Display Pigeons
                    case 5://Display pigeons Born in Loft
                        CleanUp();
                        var pigeonsBornInLoft = PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                || (x.Status == "Racing")
                                                                                || (x.Status == "Squeaker")
                                                                                || (x.Status == "Standby"))
                                                                                && (x.Origin == "Bred")).ToList();

                        Display.Pigeons(pigeonsBornInLoft);
                        Console.ReadLine();
                        break;

                    case 6://Display purchased pigeons
                        CleanUp();
                        var pigeonsPurchased = PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                        || (x.Status == "Racing")
                                                                                        || (x.Status == "Squeaker")
                                                                                        || (x.Status == "Standby"))
                                                                                        && (x.Origin == "Purchased")).ToList();

                        Display.Pigeons(pigeonsPurchased);
                        Console.ReadLine();
                        break;

                    case 7://Display pigeons received as gift
                        CleanUp();
                        var pigeonsReceivedAsGift = PigeonDataHelper.Pigeons.Values.Where(x => ((x.Status == "Breeding")
                                                                                      || (x.Status == "Racing")
                                                                                      || (x.Status == "Squeaker")
                                                                                      || (x.Status == "Standby"))
                                                                                      && (x.Origin == "Gift")).ToList();

                        Display.Pigeons(pigeonsReceivedAsGift);
                        Console.ReadLine();
                        break;

                    case 8://Display pigeons given away
                        CleanUp();
                        var pigeonsGivenAway = PigeonDataHelper.Pigeons.Values.Where(x => x.Status == "Gifted").ToList();
                        Display.Pigeons(pigeonsGivenAway);
                        Console.ReadLine();
                        break;

                    case 9://Display pigeons lost
                        CleanUp();
                        var pigeonsLost = PigeonDataHelper.Pigeons.Values.Where(x => x.Status == "Lost").ToList();
                        Display.Pigeons(pigeonsLost);

                        Console.ReadLine();
                        break;

                    case 10://Display pigeons Dead
                        CleanUp();
                        var pigeonsDead = PigeonDataHelper.Pigeons.Values.Where(x => x.Status == "Dead").ToList();
                        Display.Pigeons(pigeonsDead);
                        break;

                    //List of all Pigeons
                    case 11://Display pigeons In Loft
                        CleanUp();
                        var pigeonsInLoft = PigeonDataHelper.Pigeons.Values.Where(x => (x.Status == "Breeding")
                                                                                      || (x.Status == "Racing")
                                                                                      || (x.Status == "Squeaker")
                                                                                      || (x.Status == "Standby")).ToList();
                        Display.Pigeons(pigeonsInLoft);
                        Console.ReadLine();
                        break;

                    case 12://Display pigeons Group by color
                        CleanUp();
                        // Group pigeons by color
                        var pigeonsGroupByColor = PigeonDataHelper.Pigeons.Values.OrderBy(x => x.BandId).Where(x => (x.Status == "Breeding")
                                                                                      || (x.Status == "Racing")
                                                                                      || (x.Status == "Squeaker")
                                                                                      || (x.Status == "Standby"))
                                                                                 .GroupBy(x => x.Color);

                        //Display results
                        Display.PigeonsGroupBy("Pigeon color",pigeonsGroupByColor);
                        Console.ReadLine();
                        break;

                    case 13:// Group pigeons in loft by strain
                        CleanUp();
                        var pigeonsGroupByStrain = PigeonDataHelper.Pigeons.Values.OrderBy(x => x.BandId).Where(x => (x.Status == "Breeding")
                                                                                      || (x.Status == "Racing")
                                                                                      || (x.Status == "Squeaker")
                                                                                      || (x.Status == "Standby"))
                                                                                 .GroupBy(x => x.Strain);

                        Display.PigeonsGroupBy("Pigeon strain", pigeonsGroupByStrain);
                        Console.ReadLine();
                        break;

                    case 14://Group pigeons by sex
                        CleanUp();
                        var pigeonsGroupBySex = PigeonDataHelper.Pigeons.Values.OrderBy(x => x.BandId).Where(x => (x.Status == "Breeding")
                                                                                                   || (x.Status == "Racing")
                                                                                                   || (x.Status == "Squeaker")
                                                                                                   || (x.Status == "Standby"))
                                                                                              .GroupBy(x => x.Sex);

                        Display.PigeonsGroupBy("Pigeon sex", pigeonsGroupBySex);
                        Console.ReadLine();
                        Console.ReadLine();
                        break;

                    case 15:// Group pigeons by sex
                        CleanUp();
                        var pigeonsGroupByBandYear = PigeonDataHelper.Pigeons.Values.OrderBy(x => x.BandId).Where(x => (x.Status == "Breeding")
                                                                                                   || (x.Status == "Racing")
                                                                                                   || (x.Status == "Squeaker")
                                                                                                   || (x.Status == "Standby"))
                                                                                              .GroupBy(x => x.BandYear);

                        Display.PigeonsGroupBy("Pigeon year", pigeonsGroupByBandYear);
                        Console.ReadLine();
                        break;

                    case 0:
                        exitApplication = true;
                        break;
                    default:
                        Display.TypeWrite("Not a choice, Please try again!!");
                        System.Threading.Thread.Sleep(300);
                        break;
                }
            }
        }

        private static void UpdatePigeonMenu(Pigeon pigeon, out bool exit)
        {
            Display.WriteColorString($"1 -  Band organization: {pigeon.BandOrganization}", 1, 1, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"2 -  Band year: {pigeon.BandYear}", 1, 2, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"3 -  Band club code: {pigeon.BandClubCode}", 1, 3, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"4 -  Band band serial number: {pigeon.BandSerialNumber}", 1, 4, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"5 -  Band strain: {pigeon.Strain}", 1, 5, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"6 -  Band status: {pigeon.Status}", 1, 6, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"7 -  Band sire band id: {pigeon.SireBandId}", 1, 7, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"8 -  Band dam band id: {pigeon.DamBandId}", 1, 8, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"9 -  Color: {pigeon.Color}", 1, 9, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"10 - Sex: {pigeon.Sex}", 1, 10, ConsoleColor.Black, ConsoleColor.White);
            string dateValue = pigeon.HatchDate.HasValue ? pigeon.HatchDate.Value.ToShortDateString() : string.Empty;
            Display.WriteColorString($"11 - Hatch date: {dateValue}", 1, 11, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"12 - Origin: {pigeon.Origin}", 1, 12, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString($"13 - Back to main menu", 1, 13, ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine("\r\n\r\nPlease select an option: ");
            int option = -1;
            exit = false;
            int.TryParse(Console.ReadLine(), out option);

            if (option > 0 && option < 14)
            {
                string value = string.Empty;
                if (option != 13)
                {
                    Console.WriteLine("Enter new value: ");
                    value = Console.ReadLine();
                }

                switch (option)
                {
                    case 1:
                        pigeon.BandOrganization = value;
                        break;
                    case 2:
                        pigeon.BandYear = value;
                        break;
                    case 3:
                        pigeon.BandClubCode = value;
                        break;
                    case 4:
                        pigeon.BandSerialNumber = value;
                        break;
                    case 5:
                        pigeon.Strain = value;
                        break;
                    case 6:
                        pigeon.Status = value;
                        break;
                    case 7:
                        pigeon.SireBandId = value;
                        break;
                    case 8:
                        pigeon.DamBandId = value;
                        break;
                    case 9:
                        pigeon.Color = value;
                        break;
                    case 10:
                        pigeon.Sex = value;
                        break;
                    case 11:
                        DateTime newDate;
                        bool isValid = DateTime.TryParse(value, out newDate);
                        if (!isValid)
                        {
                            Console.WriteLine("\r\nInvalid date. ");
                        }
                        else
                        {
                            pigeon.HatchDate = DateTime.Parse(value);
                        }
                        break;
                    case 12:
                        pigeon.Origin = value;
                        break;
                    case 13:
                        exit = true;
                        return;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("\r\n\r\nOption not valid. ");
            }
        }

        private static string ShowPigeonRecord()
        {
            
            CleanUp();

            Display.WriteColorString("Band numbers are in a series of letters & numbers as shown below.", 1, 1, ConsoleColor.Black, ConsoleColor.White);
            Display.WriteColorString("EXAMPLE= the band may read-->AU2022LOU1234", 1, 2, ConsoleColor.Black, ConsoleColor.White);

            Display.WriteColorString("Please enter the pigeon Band Number: ", 1, 4, ConsoleColor.Black, ConsoleColor.White);

            var inputBandNumber = Console.ReadLine();

            if (PigeonDataHelper.ExistPigeon(inputBandNumber))
            {
                CleanUp();

                Console.CursorTop = 20;
                Console.CursorLeft = 0;

                Display.PigeonRecord(0, 0, 37, 17, PigeonDataHelper.GetPigeonById(inputBandNumber));
                //Display.WriteColorString("Please hit enter to continue", 1, 19, ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                CleanUp();
                Display.MessageBox("The pigeon you are looking for is not in your pigeon's record", 0, 0);

            }

            return inputBandNumber;
        }
    }
}
