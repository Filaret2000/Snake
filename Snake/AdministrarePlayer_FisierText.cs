using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class AdministrarePlayer_FisierText
    {
        private const int NrMaxPlayeri = 50;
        private string numeFisier;
        public AdministrarePlayer_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddPlayer(Players player)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier,true))
            {
                streamWriterFisierText.WriteLine(player.ConversieLaSir_Fisier());
            }
        }
        public Players[] GetPlayeri(out int nrPlayeri)
        {
            Players[] player = new Players[NrMaxPlayeri];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPlayeri = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                   player[nrPlayeri++] = new Players(linieFisier);
                }
            }
            return player;
        }
    }
}
