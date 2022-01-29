using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbeterde_Machi_Koro
{
    class KaartGroen : KaartBase
    {
        public KaartGroen(string _kaartNaam, int _kaartPrijs, List<int> _dobbelGetallen, int _aantalMunten, string _icoon)
        {
            this.Kleur = "Groen";
            this.KaartNaam = _kaartNaam;
            this.KaartPrijs = _kaartPrijs;
            this.DobbelGetallen = _dobbelGetallen;
            this.AantalMunten = _aantalMunten;
            this.Icoon = _icoon;
            ZetKaartAfbeelding();
        }

        /// <summary>
        /// Spelers met groene kaarten krijgen x aantal munten van de bank als zij de actieve speler zijn.
        /// Sidenote: mogelijk niet best practice dat de controle op het bovenstaande buiten de class van de kaart
        /// om worden gedaan. - Keano
        /// </summary>
        /// <param name="_speler"></param>
        public override void Effect(Speler _speler)
        {
            if (_speler == _speler.MachiKoroPotje.ActieveSpeler)
            {
                _speler.OntvangGeld(this.AantalMunten);
            }
        }
    }
}
