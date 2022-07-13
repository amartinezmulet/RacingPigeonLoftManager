﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL
{
    public static class PigeonMenu
    {
        public static int origRow;
        public static int origCol;

        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        
           
        
    }
}
