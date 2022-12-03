using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace WordleSolver.Data.Wordle
{
    internal class Letter : ILetter
    {
        public char Value { get; set; } = '?';
        public int Position { get; set; }
        public int Type { get; set; } = -1;
        public string CssClass
        {
            get
            {
                switch (Type)
                {
                    case 0:
                        return "letter-yellow";
                    case 1:
                        return "letter-green";
                    default:
                        return "letter-grey";
                }
            }
        }
    }
}
