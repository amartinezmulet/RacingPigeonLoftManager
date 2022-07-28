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

                    Console.WriteLine("│1. Find a Pigeon   4. Born in Loft      10. In Loft          │");
                    Console.WriteLine("│2. Add Pigeon      5. Purchased         11. By Color         │");
                    Console.WriteLine("│3. Delete Pigeon   6. Received as Gift  12. By Strain        │");
                    Console.WriteLine("│                   7. Given away        13. By Sex           │");
                    Console.WriteLine("│                   8. Lost              14. By Year          │");
                    Console.WriteLine("│                   9. Deceased           0. Back to Main menu│");
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
                    
                    case 1:
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

                    case 2:
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
                    case 3:
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
                    case 4:
                        Console.WriteLine("Born in Loft");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Purchased");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Received as Gift");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Given away");
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Lost");
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("Deceased");
                        Console.ReadLine();
                        break;
                    //List of all Pigeons
                    case 10:
                        Console.WriteLine("In Loft");
                        Console.ReadLine();
                        break;
                    case 11:
                        Console.WriteLine("By Color");
                        Console.ReadLine();
                        break;
                    case 12:
                        Console.WriteLine("By Strain");
                        Console.ReadLine();
                        break;
                    case 13:
                        Console.WriteLine("By Sex");
                        Console.ReadLine();
                        break;
                    case 14:
                        Console.WriteLine("By Year");
                        Console.ReadLine();
                        break;
                    case 0:
                        exitApplication = true;
                        break;
                    default:
                        Display.TypeWrite("Not a choice, Please try again!!");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}
