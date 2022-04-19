using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private const int LungimePredef = 3;

        int[,] PozSnake;
        public int LungimeSnake { get; set; }
        public Snake()//constructor implicit
        {
            PozSnake = new int[2, 500];
            LungimeSnake = LungimePredef;
            for (int i = 0; i <= LungimeSnake; i++)
            {
                PozSnake[0, i] = 10;//0 reprezinta X
                PozSnake[1, i] = 10;//1 reprezinta Y
                //Pozitiile 0 din matricea PozSnake nu reprezinta parte din lungimea snake-ului afisat!
            }
        }
        private bool StopPerete(int latime, int inaltime)
        {
            if (PozSnake[0, 1] == 2 | PozSnake[0, 1] == latime+2 | PozSnake[1, 1] == 2 | PozSnake[1, 1] == inaltime+3)
                return true;
            else
                return false;
        }
        private bool StopCorpSnake()
        {
            for(int i = 2; i <= LungimeSnake; i++)
                if (PozSnake[0, 0] == PozSnake[0, i] & PozSnake[1, 0] == PozSnake[1, i])
                    return true;
            return false;
        }
        public bool Miscare(char input, int x, int y, int latime, int inaltime, int oMiscare)
        {
            switch (input)
            {
                    case 'w':
                        PozSnake[1,0]--;
                        break;
                    case 'a':
                        PozSnake[0,0]--;
                        break;
                    case 's':
                        PozSnake[1,0]++;
                        break;
                    case 'd':
                        PozSnake[0,0]++;
                        break;
                    default:
                        break;
            }
            if (PozSnake[0, 0] == x & PozSnake[1, 0] == y)
                LungimeSnake += 1;
            if (StopPerete(latime, inaltime) == false & (StopCorpSnake() == false | oMiscare <= 3))
            {
                for (int i = LungimeSnake; i > 0; i--)
                {
                    PozSnake[0, i] = PozSnake[0, i - 1];
                    PozSnake[1, i] = PozSnake[1, i - 1];
                }
                return false;
            }
            else
                return true;
        }
        public int[,] GetPozSnake()
        {
            return PozSnake;
        }
    }
}
