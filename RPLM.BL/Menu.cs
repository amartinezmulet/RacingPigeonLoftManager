using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    public partial class Program
    {
        static void MainMenu()
        {

            bool exitApplication = false;
            while (!exitApplication)
            {
                int userChoice;
                bool validChoice;
                string Title = "Racing Pigeon Loft Manager";

                do
                {
                    Console.Clear();
                    Console.WriteLine($"{Title}\n");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine("┌" + new string('─', 18) + "┐");
                    Console.WriteLine($"│Main Menu         │");
                    Console.WriteLine("├" + new string('─', 18) + "┤");

                    Console.WriteLine("│1.Pigeons Record  │");
                    Console.WriteLine("│2.Breeding Record │");
                    Console.WriteLine("│3.Pedigree        │");
                    Console.WriteLine("│4.Inventory       │");
                    Console.WriteLine("│0.Exit application│\r");
                    Console.WriteLine("└" + new string('─', 18) + "┘");

                    Console.ResetColor();

                    TypeWrite("Please choose one of the above options:");

                    validChoice = Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 4;

                    if (!validChoice)
                    {
                        TypeWrite("Wrong input. Please try again");
                        System.Threading.Thread.Sleep(500);
                    }

                } while (!validChoice);

                switch (userChoice)
                {
                    case 1:
                        PigeonsRecordMenu();
                        break;
                    case 2:
                        Console.WriteLine("Breeding Record - Option 2 was chosen");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Pedigree - Option 3 was chosen");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Inventory - Option 4 was chosen");
                        Console.ReadLine();
                        break;
                    case 0:
                        exitApplication = true;
                        break;
                    default:
                        TypeWrite("Not a choice, Please try again!!");
                        System.Threading.Thread.Sleep(500);
                        //Console.ReadLine();
                        break;
                }
            }
        }

        static void PigeonsRecordMenu()
        {
            bool exitApplication = false;
            while (!exitApplication)
            {
                int userChoice;
                bool validChoice;
                string Title = "Pigeon records";
                string menuHeader = "│Pigeon record     Display Pigeons       List of all Pigeons  │";

                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine("┌" + new string('─', menuHeader.Length - 2) + "┐");
                    Console.WriteLine(menuHeader);
                    Console.WriteLine("├" + new string('─', menuHeader.Length - 2) + "┤");

                    Console.WriteLine("│1. Find a Pigeon   5. Born in Loft      11. In Loft          │");
                    Console.WriteLine("│2. Add Pigeon      6. Purchased         12. By Color         │");
                    Console.WriteLine("│3. Edit Pigeon     7. Received as Gift  13. By Strain        │");
                    Console.WriteLine("│4. Delete Pigeon   8. Given away        14. By Sex           │");
                    Console.WriteLine("│                   9. Lost              15. By Year          │");
                    Console.WriteLine("│                  10. Deceased           0. Back to Main menu│");
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
                        Console.WriteLine("Find a Pigeon");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Add Pigeon");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Edit Pigeon");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Delete Pigeon");
                        Console.ReadLine();
                        break;

                    //Display Pigeons
                    case 5:
                        Console.WriteLine("Born in Loft");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Purchased");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Received as Gift");
                        Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine("Given away");
                        Console.ReadLine();
                        break;
                    case 9:
                        Console.WriteLine("Lost");
                        Console.ReadLine();
                        break;
                    case 10:
                        Console.WriteLine("Deceased");
                        Console.ReadLine();
                        break;
                    //List of all Pigeons
                    case 11:
                        Console.WriteLine("In Loft");
                        Console.ReadLine();
                        break;
                    case 12:
                        Console.WriteLine("By Color");
                        Console.ReadLine();
                        break;
                    case 13:
                        Console.WriteLine("By Strain");
                        Console.ReadLine();
                        break;
                    case 14:
                        Console.WriteLine("By Sex");
                        Console.ReadLine();
                        break;
                    case 15:
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
        static void TypeWrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
