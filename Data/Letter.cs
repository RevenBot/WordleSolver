using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    internal class Letter : ILetter
    {
        public char Value { get; set; } = '?';
        public int Position { get; set; }
        public int Type { get; set; } = -1;
    }
}
