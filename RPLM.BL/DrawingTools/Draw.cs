using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.DrawingTools
{
    public static class Draw
    {
        public static char LeftTopCorner => '┌';
        public static char RighTopCorner => '┐';
        public static char LeftBottomCorner => '└';
        public static char RightBottomCorner => '┘';
        public static char HorizontalLine => '─';
        public static char VerticalLine => '│';
        public static char DividerTop => '┬';
        public static char DividerCenter => '┼';
        public static char DividerBotton => '┬';
        public static char DividerLeftToRight => '├';
        public static char DividerRightToLeft => '┤';

        /// <summary>
        /// Draw a container box using ascii graphic characters.
        /// </summary>
        /// <param name="column">The column position of the cursor. Columns are numbered from left to right starting at 0.</param>
        /// <param name="row">The row position of the cursor. Rows are numbered from top to bottom starting at 0.</param>
        /// <param name="width">The container's width.</param>
        /// <param name="height">The container's height.</param>
        /// <param name="title">The container's title.</param>
        /// <param name="frgrndColor">The container's foreground color.</param>
        /// <param name="bckgrndColor">The container's background color.</param>
        public static void Container(int column, int row, int width, int height, string title, ConsoleColor bckgrndColor, ConsoleColor frgrndColor)
        {
            int times;

            if (title.Length + 2 >= width)
            {
                times = 0;
                width = title.Length + 2;
            }
            else
            {
                times = width - title.Length - 2;
            }
            Console.ResetColor();
            Console.SetCursorPosition(column, row);

            Console.ForegroundColor = frgrndColor;
            Console.BackgroundColor = bckgrndColor;

            Console.Write(LeftTopCorner.ToString() + title + new string(HorizontalLine, times) + RighTopCorner);

            if (height > 2)
            {
                for (int i = 0; i < height; ++i)
                {
                    ++row;
                    Console.SetCursorPosition(column, row);
                    Console.Write(VerticalLine + new string(' ', width - 2) + VerticalLine);
                }
                Console.SetCursorPosition(column, row);
                Console.Write(LeftBottomCorner + new string(HorizontalLine, width - 2) + RightBottomCorner);
            }
        }

        /// <summary>
        /// Chooses an item in a ListBox.
        /// </summary>
        /// <param name="stringArray">An array of string.</param>
        /// <param name="uppercolumn">The cursor's upper column.</param>
        /// <param name="upperrow">The cursor's upper row.</param>
        /// <param name="background">The background color.</param>
        /// <param name="foreground">The foreground color.</param>
        /// <returns></returns>
        public static int ChooseListBoxItem(string[] stringArray, int uppercolumn, int upperrow, ConsoleColor background, ConsoleColor foreground)
        {
            int arraySize = stringArray.Length;
            int maxLength = stringArray[0].Length;
            for (int index = 1; index < arraySize; index++)
            {
                if (stringArray[index].Length > maxLength)
                {
                    maxLength = stringArray[index].Length;
                }
            }
            int[] rightSpaces = new int[arraySize];
            for (int index = 0; index < arraySize; index++)
            {
                rightSpaces[index] = maxLength - stringArray[index].Length + 1;
            }
            int lcol = uppercolumn + maxLength + 3;
            int lrow = upperrow + arraySize + 1;
            Box(uppercolumn, upperrow, lcol, lrow, background, foreground, true);
            WriteColorString(" " + stringArray[0] + new string(' ', rightSpaces[0]), uppercolumn + 1, upperrow + 1, foreground, background);
            for (int index = 2; index <= arraySize; index++)
            {
                WriteColorString(stringArray[index - 1], uppercolumn + 2, upperrow + index, background, foreground);
            }

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
                    WriteColorString(" " + stringArray[choice - 1] + new string(' ', rightSpaces[choice - 1]), uppercolumn + 1, upperrow + choice, background, foreground);
                    if (choice < arraySize)
                    {
                        choice++;
                    }
                    else
                    {
                        choice = 1;
                    }
                    WriteColorString(" " + stringArray[choice - 1] + new string(' ', rightSpaces[choice - 1]), uppercolumn + 1, upperrow + choice, foreground, background);

                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    WriteColorString(" " + stringArray[choice - 1] + new string(' ', rightSpaces[choice - 1]), uppercolumn + 1, upperrow + choice, background, foreground);
                    if (choice > 1)
                    {
                        choice--;
                    }
                    else
                    {
                        choice = arraySize;
                    }
                    WriteColorString(" " + stringArray[choice - 1] + new string(' ', rightSpaces[choice - 1]), uppercolumn + 1, upperrow + choice, foreground, background);
                }
            }
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
        public static void Box(int ucol, int urow, int lcol, int lrow, ConsoleColor back, ConsoleColor fore, bool fill)
        {
            string fillLine = fill ? new string(' ', lcol - ucol - 1) : "";
            SetColors(back, fore);
            // draw top edge
            Console.SetCursorPosition(ucol, urow);
            Console.Write(LeftTopCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(HorizontalLine);
            }
            Console.Write(RighTopCorner);

            // draw sides
            for (int i = urow + 1; i < lrow; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(VerticalLine);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(VerticalLine);
            }
            // draw bottom edge
            Console.SetCursorPosition(ucol, lrow);
            Console.Write(LeftBottomCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(HorizontalLine);
            }
            Console.Write(RightBottomCorner);
        }

        /// <summary>
        /// Cleans up console and resets colors.
        /// </summary>
        public static void CleanUpConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Writes a color string to console
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="col">The col.</param>
        /// <param name="row">The row.</param>
        /// <param name="background">The background.</param>
        /// <param name="foreground">The foreground.</param>
        public static void WriteColorString(string s, int col, int row, ConsoleColor background, ConsoleColor foreground)
        {
            SetColors(background, foreground);
            // write string
            Console.SetCursorPosition(col, row);
            Console.Write(s);
        }

        /// <summary>
        /// Sets the background and foreground colors.
        /// </summary>
        /// <param name="background">The background.</param>
        /// <param name="foreground">The foreground.</param>
        public static void SetColors(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        
        //***********************************************************************************************************************
    }
}
