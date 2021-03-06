using RPLM.BL.ConsoleUI;
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
            while (!exitApplication)
            {
                int userChoice;
                bool validChoice;


                string menuHeader = "│Pigeon record     Display Pigeons       List of all Pigeons  │";

                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine("┌" + new string('─', menuHeader.Length - 2) + "┐");
                    Console.WriteLine(menuHeader);
                    Console.WriteLine("├" + new string('─', menuHeader.Length - 2) + "┤");

                    Console.WriteLine("│1. Add Pigeon      4. Born in Loft      10. In Loft          │");
                    Console.WriteLine("│2. Delete Pigeon   5. Purchased         11. By Color         │");
                    Console.WriteLine("│3. Find a Pigeon   6. Received as Gift  12. By Strain        │");
                    Console.WriteLine("│                   7. Given away        13. By Sex           │");
                    Console.WriteLine("│                   8. Lost              14. By Year          │");
                    Console.WriteLine("│                   9. Deceased           0. Back to Main menu│");
                    Console.WriteLine("└" + new string('─', menuHeader.Length - 2) + "┘");

                    Console.ResetColor();

                    TypeWrite("Select your choice(0 - Back to Main Menu):");

                    validChoice = Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 15;

                    if (!validChoice)
                    {
                        TypeWrite("Wrong input. Please try again");
                        System.Threading.Thread.Sleep(500);
                    }

                } while (!validChoice);

                switch (userChoice)
                {
                    //Pigeon record
                    case 1:
                        CleanUp();
                        var addPigeon = new PigeonDataInput();
                        addPigeon.GetBandIdFromConsoleInput(1, 1, ConsoleColor.White, ConsoleColor.Blue);

                        break;
                    case 2:
                        Console.WriteLine("Delete Pigeon");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Find a Pigeon");
                        Console.ReadLine();
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
                        TypeWrite("Not a choice, Please try again!!");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
    }
}
