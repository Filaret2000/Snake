using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Tabla
    {
        //inaltimea si latimea portiunii tablei de joc
        public int Inaltime { get; set; }
        public int Latime { get; set; }
        public Tabla()//constructor implicit
        {
            Inaltime = 20;
            Latime = 40;
        }
        public void AfisareTabla()
        {
            for (int i = 2; i <= (Inaltime+2); i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write('|');
            }
            for (int i = 2; i <= (Inaltime + 2); i++)
            {
                Console.SetCursorPosition(Latime+2, i);
                Console.Write('|');
            }
            for (int i = 2; i <= (Latime+2); i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("-");
            }
            for (int i = 2; i <= (Latime+2); i++)
            {
                Console.SetCursorPosition(i, Inaltime+3);
                Console.Write("-");
            }
        }
    }
}
