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
    public class BoxDrawingCharacters
    {
        public char LeftTopCorner => '┌';
        public char RighTopCorner => '┐';
        public char LeftBottomCorner => '└';
        public char RightBottomCorner => '┘';
        public char HorizontalLine => '─';
        public char VerticalLine => '│';
        public char DividerTop => '┬';
        public char DividerCenter => '┼';
        public char DividerBotton => '┬';
        public char DividerLeftToRight => '├';
        public char DividerRightToLeft => '┤';
    }
}
