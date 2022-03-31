using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake    
    {
        int[,] PozSnake;
        int LungimeSnake;
        public Snake()//constructor implicit
        {
            PozSnake = new int[2, 100];
            LungimeSnake = 3;
            PozSnake[0,1] = 10;//0 reprezinta X
            PozSnake[1,1] = 10;//1 reprezinta Y
            PozSnake[0,0] = 10;//Pozitiile 0 din matricea PozSnake
            PozSnake[1,0] = 10;//nu reprezinta parte din lungimea snake-ului!
        }
        private bool Stop(int Latime, int Inaltime)
        {
            if (PozSnake[0, 0] == 2 | PozSnake[0, 0] == Latime+2 | PozSnake[1, 0] == 2 | PozSnake[1, 0] == Inaltime)
                return true;
            else
                return false;
        }
        public int Miscare(char input, int x, int y, int Latime, int Inaltime)
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
            if (PozSnake[0, 1] == x & PozSnake[1, 1] == y)
                LungimeSnake += 1;
            if (Stop(Latime, Inaltime) == false)
            {
                for (int i = LungimeSnake; i > 0; i--)
                {
                    PozSnake[0, i] = PozSnake[0, i - 1];
                    PozSnake[1, i] = PozSnake[1, i - 1];
                }
                return 1;
            }
            else
                return 0;
        }
        public int[,] GetPozSnake()
        {
            return PozSnake;
        }
        public int GetLungSnake()
        {
            return LungimeSnake;
        }
        public int NrPuncte()
        {
            return (LungimeSnake - 3);
        }
    }
}
