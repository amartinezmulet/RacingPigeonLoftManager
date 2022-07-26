using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPLM.BL.DrawingTools
{
    /// <summary>
    /// Contains properties with ascii graphic characters
    /// </summary>
    public static class BoxDrawingCharacters
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
        public static char  DividerRightToLeft => '┤';
    }
}
