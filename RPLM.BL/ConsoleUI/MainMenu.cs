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
        static void MainMenu()
        {
            CleanUp();
            Console.SetWindowSize(120, 45);

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
        static void CleanUp()
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Clear();
        }
        static void TypeWrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(50);
            }
        }
        //************************************************************************



        //************************************************************************
    }
}
