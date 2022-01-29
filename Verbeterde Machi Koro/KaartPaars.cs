using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verbeterde_Machi_Koro
{
    class KaartPaars : KaartBase
    {
        public KaartPaars(string _kaartNaam, int _kaartPrijs, List<int> _dobbelGetallen, int _aantalMunten, string _icoon)
        {
            this.Kleur = "Paars";
            this.KaartNaam = _kaartNaam;
            this.KaartPrijs = _kaartPrijs;
            this.DobbelGetallen = _dobbelGetallen;
            this.AantalMunten = _aantalMunten;
            this.Icoon = _icoon;
            ZetKaartAfbeelding();
        }

        /// <summary>
        /// De implementatie van de laatste 2 paarse kaarten is spijtig genoeg niet gelukt. - Keano
        /// </summary>
        /// <param name="_actieveSpeler"></param>
        public override void Effect(Speler _speler)
        {
            if (_speler == _speler.MachiKoroPotje.ActieveSpeler)
            {
                //3 paarse effecten

                //Stadion:
                //Als het jouw beurt is (_actieveSpeler), dan moet elke andere speler jou 2 munten betalen. - Keano
                if (this.KaartNaam == "Stadion")
                {
                    foreach (Speler _betalendeSpeler in _speler.MachiKoroPotje.Spelers)
                    {
                        _speler.OntvangGeld(this.AantalMunten, _betalendeSpeler);
                    }
                }
                //Tv Station:
                //Als het jouw beurt is (_actieveSpeler), dan moet 1 speler naar keuze jou 5 munten betalen.
                else if (this.KaartNaam == "TvStation")
                {
                    MessageBox.Show("Deze kaart is nog niet geïmplementeerd. Sorry.");
                }
                //Bedrijfscomplex:
                //Als het jouw beurt is (_actieveSpeler), dan moet je 1 kaart ruilen met een speler naar keuze waarvan het icoontje geen Torenmast is.s
                else if (this.KaartNaam == "Bedrijfscomplex")
                {
                    MessageBox.Show("Deze kaart is nog niet geïmplementeerd. Sorry.");
                }
            }
        }
    }
}
