using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace RPLM.BL.Helpers
{
    public static class InputValidator
    {
        //Band Organization, Band Club's code Validation
        /// <summary>
        /// Determines whether [is valid strig with no numbers] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is valid strig with no numbers] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidStrigWithNoNumbers(out string input)
        {
            string pattern = "^[a-zA-Z]+$";
            var regex = new Regex(pattern);

            input = Console.ReadLine();

            return regex.IsMatch(input.Trim());
        }

        public static bool IsValidStrigWithNumbers(out string input)
        {
            string pattern = "^[A-Za-z0-9]*$";
            var regex = new Regex(pattern);

            input = Console.ReadLine();

            return regex.IsMatch(input.Trim());
        }

        //Band Year Validation
        /// <summary>
        /// Determines whether [is valid year] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is valid year] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidYear(out string input)
        {
            string pattern = "^[12][0-9]{3}$";
            var regex = new Regex(pattern);

            input = Console.ReadLine();

            return regex.IsMatch(input);

        }

        //Band Serial Number Validation
        /// <summary>
        /// Determines whether [is integer number] [the specified input].
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is integer number] [the specified input]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsIntegerNumber(out string input)
        {
            string pattern = "^[0-9]+$";
            var regex = new Regex(pattern);

            input = Console.ReadLine();

            return regex.IsMatch(input);

        }

        //Get a DateTime value that could be either a date or a null date value
        public static bool IsANullableDateTime(string input)
        {
            string pattern = @"^$|^(?=\d)^(?:(?!(?:10\D(?:0?[5-9]|1[0-4])\D(?:1582))|(?:0?9\D(?:0?[3-9]|1[0-3])\D(?:1752)))((?:0?[13578]|1[02])|(?:0?[469]|11)(?!\/31)(?!-31)(?!\.31)|(?:0?2(?=.?(?:(?:29.(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:(?:\d\d)(?:[02468][048]|[13579][26])(?!\x20BC))|(?:00(?:42|3[0369]|2[147]|1[258]|09)\x20BC))))))|(?:0?2(?=.(?:(?:\d\D)|(?:[01]\d)|(?:2[0-8])))))([-.\/])(0?[1-9]|[12]\d|3[01])\2(?!0000)((?=(?:00(?:4[0-5]|[0-3]?\d)\x20BC)|(?:\d{4}(?!\x20BC)))\d{4}(?:\x20BC)?)(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]\d|2[0-3])(?::[0-5]\d){1,2})?$";
            Regex regex = new Regex(pattern);
            var IsValidDate = regex.IsMatch(input.Trim());
            return (String.IsNullOrEmpty(input) || IsValidDate) ? true : false;
        }

        public static DateTime? GetHatchDate(string input)
        {
            DateTime date;
            return DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : null;
        }


        /// <summary>
        /// Wrongs the input MSG.
        /// </summary>
        /// <param name="cursorLeft">The cursor left.</param>
        /// <param name="cursorTop">The cursor top.</param>
        public static void WrongInputMsg(int cursorLeft, int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write("Wrong input, please try again");
            Thread.Sleep(2000);
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft));
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        // Yes or Not choice. Returns Y or N
        /// <summary>
        /// Yer or not choice.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <returns>Returns 'Y' or 'N'</returns>
        public static Char YesOrNotChoice(string question)
        {
            Console.Write(question);

            var cursorLeft = Console.CursorLeft;
            var cursorTop = Console.CursorTop;

            char choice;

            do
            {
                ConsoleKeyInfo pressed = Console.ReadKey();
                choice = pressed.KeyChar;

                if (choice == 'Y' || choice == 'y')
                {
                    choice = 'Y';
                }
                else if (choice == 'N' || choice == 'n')
                {
                    choice = 'N';
                }
                else
                {
                    InputValidator.WrongInputMsg(cursorLeft, cursorTop);
                }

            } while (!(choice == 'Y' || choice == 'N'));

            return choice;
        }

        /// <summary>
        /// Chooses an item in a ListBox.
        /// </summary>
        /// <param name="items">An array of string.</param>
        /// <param name="ucol">The cursor's upper column.</param>
        /// <param name="urow">The cursor's upper row.</param>
        /// <param name="back">The background color.</param>
        /// <param name="fore">The foreground color.</param>
        /// <returns></returns>
        public static int ChooseListBoxItem(string[] items, int ucol, int urow, ConsoleColor back, ConsoleColor fore)
        {
            Console.CursorVisible = false;

            int numItems = items.Length;
            int maxLength = items[0].Length;

            for (int i = 1; i < numItems; i++)
            {
                if (items[i].Length > maxLength)
                {
                    maxLength = items[i].Length;
                }
            }
            int[] rightSpaces = new int[numItems];
            for (int i = 0; i < numItems; i++)
            {
                rightSpaces[i] = maxLength - items[i].Length + 1;
            }
            int lcol = ucol + maxLength + 3;
            int lrow = urow + numItems + 1;
            DrawBox(ucol, urow, lcol, lrow, back, fore, true);
            WriteColorString(" " + items[0] + new string(' ', rightSpaces[0]), ucol + 1, urow + 1, fore, back);
            for (int i = 2; i <= numItems; i++)
            {
                WriteColorString(items[i - 1], ucol + 2, urow + i, back, fore);
            }
            Console.CursorLeft = ucol;
            Console.CursorTop = urow;

            ConsoleKeyInfo cki;
            char key;
            int choice = 1;

            while (true)
            {
                cki = Console.ReadKey(true);
                key = cki.KeyChar;
                if (key == '\r') // enter
                {
                    return choice;
                }
                else if (cki.Key == ConsoleKey.DownArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice < numItems)
                    {
                        choice++;
                    }
                    else
                    {
                        choice = 1;
                    }
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);

                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice > 1)
                    {
                        choice--;
                    }
                    else
                    {
                        choice = numItems;
                    }
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);
                }

            }
        }

        public static void WriteColorString(string s, int col, int row, ConsoleColor background, ConsoleColor foreground)
        {
            SetColors(background, foreground);
            // write string
            Console.SetCursorPosition(col, row);
            Console.Write(s);
        }

        public static void SetColors(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        /// <summary>
        /// Draws a box using ascii graphic characters.
        /// </summary>
        /// <param name="ucol">The upper column.</param>
        /// <param name="urow">The upper row.</param>
        /// <param name="lcol">The lower column.</param>
        /// <param name="lrow">The lower row.</param>
        /// <param name="back">The background color.</param>
        /// <param name="fore">The foreground color.</param>
        /// <param name="fill">if set to <c>true</c> [fill a line].</param>
        public static void DrawBox(int ucol, int urow, int lcol, int lrow, ConsoleColor back, ConsoleColor fore, bool fill)
        {
            const char Horizontal = '\u2500';
            const char Vertical = '\u2502';
            const char UpperLeftCorner = '\u250c';
            const char UpperRightCorner = '\u2510';
            const char LowerLeftCorner = '\u2514';
            const char LowerRightCorner = '\u2518';
            string fillLine = fill ? new string(' ', lcol - ucol - 1) : "";
            SetColors(back, fore);
            // draw top edge
            Console.SetCursorPosition(ucol, urow);
            Console.Write(UpperLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }
            Console.Write(UpperRightCorner);

            // draw sides
            for (int i = urow + 1; i < lrow; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(Vertical);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(Vertical);
            }
            // draw bottom edge
            Console.SetCursorPosition(ucol, lrow);
            Console.Write(LowerLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }
            Console.Write(LowerRightCorner);
        }
    }
}
