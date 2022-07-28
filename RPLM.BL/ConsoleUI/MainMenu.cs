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
        static void MainMenu()
        {
            
            

            CleanUp();
            Console.SetWindowSize(120, 45);

            

            bool exitApplication = false;

            while (!exitApplication)
            {
                PigeonDataHelper.LoadData();
                int userChoice;
                bool validChoice;
                Console.Title = "Racing Pigeon Loft Manager";

                do
                {
                    Console.Clear();
                    //Console.WriteLine($"{Title}\n");

                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine("┌" + new string('─', 18) + "┐");
                    Console.WriteLine($"│Main Menu         │");
                    Console.WriteLine("├" + new string('─', 18) + "┤");

                    Console.WriteLine("│1.Pigeons Record  │");
                    Console.WriteLine("│2.Inventory       │");
                    Console.WriteLine("│3.Pedigree        │");
                    Console.WriteLine("│0.Exit application│\r");
                    Console.WriteLine("└" + new string('─', 18) + "┘");

                    Console.ResetColor();

                   

                    Console.SetCursorPosition(0, 8);
                    Display.TypeWrite("\r\nPlease choose one of\r\nthe above options:");

                    validChoice = Int32.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 3;

                    if (!validChoice)
                    {
                        Display.TypeWrite("Wrong input. Please try again");
                        //System.Threading.Thread.Sleep(500);
                    }

                } while (!validChoice);

                switch (userChoice)
                {
                    case 1:
                        PigeonsRecordMenu();
                        break;
                    case 2:
                        Console.Title = "Loft Inventory";
                        Console.Clear();
                        Console.ResetColor();
                        
                        Display.PigeonInventory(3, 3, 10, 5, ConsoleColor.Black, ConsoleColor.White);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Pedigree - Option 3 was chosen");
                        Console.ReadLine();
                        break;
                    case 0:
                        exitApplication = true;
                        break;
                    default:
                        Display.TypeWrite("Not a choice, Please try again!!");
                        //System.Threading.Thread.Sleep(500);
                        //Console.ReadLine();
                        break;
                }
            }
        }
        static void CleanUp()
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Clear();
        }
        
        //************************************************************************



        //************************************************************************
    }
}
