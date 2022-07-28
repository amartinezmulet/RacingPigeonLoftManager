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
            string bandNumber;

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

                    Console.WriteLine("│1. Find a Pigeon   5. Born in Loft      11. In Loft          │");
                    Console.WriteLine("│2. Add a Pigeon    6. Purchased         12. By Color         │");
                    Console.WriteLine("│3. Update a Pigeon 7. Received as Gift  13. By Strain        │");
                    Console.WriteLine("│4. Delete a Pigeon 8. Given away        14. By Sex           │");
                    Console.WriteLine("│                   9. Lost              15. By Year          │");
                    Console.WriteLine("│                  10. Deceased           0. Back to Main menu│");
                    Console.WriteLine("└" + new string('─', menuHeader.Length - 2) + "┘");

                    Console.ResetColor();

                    Display.TypeWrite("Select your choice(0 - Back to Main Menu):");

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
                    
                    case 1: // Finds a pigeon by Band Id
                        CleanUp();
                        Console.Title = "Find a Pigeon";
                        
                        Display.WriteColorString("Band numbers are in a series of letters & numbers as shown below.", 1, 1, ConsoleColor.Black, ConsoleColor.White);
                        Display.WriteColorString("EXAMPLE= the band may read-->AU2022LOU1234", 1, 2, ConsoleColor.Black, ConsoleColor.White);

                        Display.WriteColorString("Please enter the pigeon Band Number: ", 1, 4, ConsoleColor.Black, ConsoleColor.White);

                        bandNumber = Console.ReadLine();

                        if (PigeonDataHelper.ExistPigeon(bandNumber))
                        {
                            CleanUp();

                            Console.CursorTop = 20;
                            Console.CursorLeft = 0;

                            Display.PigeonRecord(0, 0, 37, 17, PigeonDataHelper.GetPigeonById(bandNumber));
                            Display.WriteColorString("Please hit enter to continue", 1, 19, ConsoleColor.Black, ConsoleColor.White);
                        }
                        else
                        {
                            Console.WriteLine();
                            Display.MessageBox("The pigeon you are looking for is not in your pigeon's record", 1, 1);
                        }
                                                

                        Console.ReadLine();

                        break;

                    case 2: //Add a new Pigeon
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

                    case 3://TODO: Implement Edit or Update Pigeon Record

                        break;

                    case 4://TODO: Delete a pigeon
                        Console.Title = "Delete a Pigeon";

                        Display.WriteColorString("Band numbers are in a series of letters & numbers as shown below.", 1, 1, ConsoleColor.Black, ConsoleColor.White);
                        Display.WriteColorString("EXAMPLE= the band may read-->AU2022LOU1234", 1, 2, ConsoleColor.Black, ConsoleColor.White);

                        Display.WriteColorString("Please enter the pigeon Band Number: ", 1, 4, ConsoleColor.Black, ConsoleColor.White);

                        bandNumber = Console.ReadLine();



                        if (PigeonDataHelper.ExistPigeon(bandNumber))
                        {
                            CleanUp();

                            Console.CursorTop = 20;
                            Console.CursorLeft = 0;

                            Display.PigeonRecord(0, 0, 37, 17, PigeonDataHelper.GetPigeonById(bandNumber));

                            
                            Display.WriteColorString("Are you sure you want to delete this pigeon? (Y/N)", 1, 19, ConsoleColor.Black, ConsoleColor.White);
                            Console.ReadLine();

                            PigeonDataHelper.Remove("band id here");
                            PigeonDataHelper.Save();
                        }
                        else
                        {
                            Console.WriteLine();
                            Display.MessageBox("The pigeon you are looking for is not in your pigeon's record", 1, 1);
                        }
                        
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
    }
}
