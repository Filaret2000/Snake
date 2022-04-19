using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Players
    {
        private const char Separator_FisText = ':';
        private const int ID = 0;
        private const int NICKNAME = 1;
        private const int PUNCTAJ = 2;
        private const int DATA = 3;
        public int Punctaj { get; set; }
        public string Nickname { get; set; }
        public string Data { get; set; }
        public int idPlayer { get; set; }

        public Players()
        {
            Nickname = Data = string.Empty;
            Punctaj = 0;
        }
        public Players(string _nickname, string _date,int _punctaj)
        {
            Nickname = _nickname;
            Data = _date;
            Punctaj = _punctaj;
        }
        public Players(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(Separator_FisText);
            idPlayer = Convert.ToInt32(dateFisier[ID]);
            Nickname = dateFisier[NICKNAME];
            Punctaj = Convert.ToInt32(dateFisier[PUNCTAJ]);
            Data = dateFisier[DATA];
        }
        public string ConversieLaSir_Fisier()
        {
            string SirPtFisierText = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                Separator_FisText,
                idPlayer.ToString(),
                (Nickname ?? "NECUNOSCUT" ),
                Punctaj.ToString(),
                Data);
            return SirPtFisierText;
        }
    }
}
