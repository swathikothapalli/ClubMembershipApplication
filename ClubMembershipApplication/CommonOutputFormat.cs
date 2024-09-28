using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication
{
    public enum Fonts
    {
        Default,
        Error,
        Success
    };
    internal class CommonOutputFormat
    {
        public static void fontChange(Fonts font)
        {
            if (font == Fonts.Error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (font == Fonts.Success)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
        }

    }
}
