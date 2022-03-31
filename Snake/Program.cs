using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier;
            if (args[0] == null)
                numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            else
                numeFisier = args[0];

            Snake snake = new Snake();
            Fructe fruct = new Fructe();
            Tabla tabla = new Tabla();

            int[,] PozitieSnake = snake.GetPozSnake();
            var Lung = snake.GetLungSnake();
            int[,] ffruct = fruct.Fruct(tabla.GetLatime(), tabla.GetInaltime());
            char input = 'w';
            int k;
            int LungSnake;

            while (input != 'p')
            {
                Console.Clear();
                LungSnake = snake.GetLungSnake();
                if (Lung != LungSnake)
                {
                    ffruct = fruct.Fruct(tabla.GetLatime(), tabla.GetInaltime());
                    while (VerificareFruct(ffruct, PozitieSnake, Lung) == false)
                        ffruct = fruct.Fruct(tabla.GetLatime(), tabla.GetInaltime());
                    Lung = LungSnake;
                }

                tabla.AfisareTabla();
                AfisareSnake(LungSnake, PozitieSnake );
                AfisareFruct(ffruct);

                input = Console.ReadKey().KeyChar;

                k = snake.Miscare(input, ffruct[0,0], ffruct[1,0], tabla.GetLatime(), tabla.GetInaltime());
                if (k == 0)
                {
                    Console.WriteLine("Stop");
                    Console.ReadKey();
                    input = 'p';
                }
                
            }
        }
        public static bool VerificareFruct(int[,] fruct, int[,] PozitieSnake, int Lung)
        {
            for (int i = 1; i <= Lung; i++)
                if (PozitieSnake[0, i] == fruct[0, 0] | PozitieSnake[1, i] == fruct[1, 0])
                    return false;
            return true;
        }
        public static void AfisareSnake(int LungSnake, int[,] PozitieSnake)
        {
            for (int i = 1; i <= LungSnake; i++)
            {
                Console.SetCursorPosition(PozitieSnake[0, i], PozitieSnake[1, i]);
                Console.Write('x');
            }            
        }
        public static void AfisareFruct(int[,] fruct)
        {
            Console.SetCursorPosition(fruct[0, 0], fruct[1, 0]);
            Console.Write('#');
        }
    }
}
