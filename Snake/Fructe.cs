using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fructe
    {
        int[,] fruct;
        public Fructe()
        {
            fruct = new int[2, 1];
        }
        public int[,] Fruct(int x, int y)
        {
            Random rnd = new Random();
            fruct[0, 0] = rnd.Next(3, x+1);
            fruct[1, 0] = rnd.Next(3, y+1);
            return fruct;
        }
    }
}
