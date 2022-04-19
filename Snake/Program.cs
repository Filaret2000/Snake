using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fisier
            string numeFisier;
            if (args[0] == null)
                numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            else
                numeFisier = args[0];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrarePlayer_FisierText adminPlayer = new AdministrarePlayer_FisierText(caleCompletaFisier);
            
            //Declarari si initializari
            int nrPlayeri = 0;
            Snake snake = new Snake();
            Fructe fruct = new Fructe();
            Tabla tabla = new Tabla();
            Players player = new Players();

            int[,] PozitieSnake = snake.GetPozSnake();
            int LungSnake, LungPredef, Lung;
            Lung = snake.LungimeSnake;
            LungPredef = Lung;
            int latime = tabla.Latime;
            int inaltime = tabla.Inaltime;
            int[,] ffruct = fruct.Fruct(latime, inaltime);
            char input = 'w';
            bool Stop = false;
            int Contor = 0;
            int pct=0;

            adminPlayer.GetPlayeri(out nrPlayeri);
            
            //Meniu
            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("\n  S. Show players chart");
                Console.WriteLine("  P. Play");
                Console.WriteLine("  X. Exit");
                Console.WriteLine("   Choose an option...");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "S":
                        Players[] Player = adminPlayer.GetPlayeri(out nrPlayeri);
                        AfisarePlayeri(Player, nrPlayeri);
                        break;
                    case "P":
                        Players[] Pllayer = adminPlayer.GetPlayeri(out nrPlayeri);
                        player = CitirePlayer(Pllayer,nrPlayeri,out pct);
                        optiune = "x";
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Option doesn't exist.");
                        break;
                }
                if (optiune.ToUpper() != "X")
                {
                    Console.WriteLine("\nPress any key to ontinue...");
                    Console.ReadKey();
                }
            } while (optiune.ToUpper() != "X");

            //Logica
            while (!Stop)
            {
                Console.Clear();
                Console.CursorVisible = false ;
                Contor += 1;
                LungSnake = snake.LungimeSnake;
                if (Lung != LungSnake)
                {
                    ffruct = fruct.Fruct(latime, inaltime);
                    while (VerificareFruct(ffruct, PozitieSnake, Lung) == false)
                        ffruct = fruct.Fruct(latime, inaltime);
                    Lung = LungSnake;
                }

                tabla.AfisareTabla();
                AfisareSnake(LungSnake, PozitieSnake );
                AfisareFruct(ffruct);

                input = Console.ReadKey(true).KeyChar;

                Stop = snake.Miscare(input, ffruct[0,0], ffruct[1,0], latime, inaltime, Contor);
                if (Stop == true)
                {
                    Console.SetCursorPosition(17,12);
                    Console.WriteLine(" Game Over\n");
                    Console.SetCursorPosition(17, 13);
                    Console.WriteLine("Punctaj: {0}", Punctaj(snake,LungPredef));
                    if (pct != 0)
                    {
                        Console.SetCursorPosition(13, 14);
                        Console.WriteLine("Ultimul punctaj: {0}", pct);
                    }
                    player.Punctaj = Punctaj(snake, LungPredef);

                    int IdPlayers = nrPlayeri + 1;
                    player.idPlayer = IdPlayers;
                    adminPlayer.AddPlayer(player);
                    nrPlayeri += 1;

                    Console.ReadKey();
                }
                
            }
        }
        public static int Punctaj(Snake snake, int lung)
        {
            return (snake.LungimeSnake - lung) * 10;
        }
        public static void AfisarePlayeri(Players[] player, int nrPlayeri)
        {
            Console.WriteLine("  Players are:");
            for (int contor = 0; contor < nrPlayeri; contor++)
            {
                AfisarePlayer(player[contor]);
            }
        }
        public static void AfisarePlayer(Players player)
        {
            string infoPlayer = string.Format("  #{0,2}. {1,7}: {2,4} points ~ {3}",
                    player.idPlayer,
                    (player.Nickname ?? "NECUNOSCUT"),
                    player.Punctaj,
                    player.Data);

            Console.WriteLine(infoPlayer);
        }
        public static Players CitirePlayer(Players[] playerr, int nrPlayeri,out int pct)
        {
            int punctaj=0;
            pct = 0;
            Console.WriteLine("Nickname: ");
            string nickname = Console.ReadLine();
            if (VerifExistentaInFisier(playerr, nrPlayeri, nickname, out punctaj) == true)
                pct = punctaj;
            DateTime Date = DateTime.Today;
            string date = Date.ToString();
            Players player = new Players(nickname, date.Remove(10, 9), 0);
            return player;
        }
        public static bool VerifExistentaInFisier(Players[] player, int nrPlayeri, string nickname, out int punctaj)
        {
            punctaj = 0;
            for (int contor = 0; contor < nrPlayeri; contor++)
            {
                if (player[contor].Nickname == nickname)
                {
                    punctaj = player[contor].Punctaj;
                    return true;
                }
            }
            return false;
        }
        public static bool VerificareFruct(int[,] fruct, int[,] PozitieSnake, int Lung)
        {
            for (int i = 1; i <= Lung; i++)
                if (PozitieSnake[0, i] == fruct[0, 0] | PozitieSnake[1, i] == fruct[1, 0])
                    return false;
            return true;
        }
        public static void AfisareSnake(int lung, int[,] PozitieSnake)
        {
            for (int i = 2; i <= lung; i++)
            {
                Console.SetCursorPosition(PozitieSnake[0, i], PozitieSnake[1, i]);
                Console.Write('x');
            }
            Console.SetCursorPosition(PozitieSnake[0, 1], PozitieSnake[1, 1]);
            Console.Write('$');
        }
        public static void AfisareFruct(int[,] fruct)
        {
            Console.SetCursorPosition(fruct[0, 0], fruct[1, 0]);
            Console.Write('#');
        }
    }
}
