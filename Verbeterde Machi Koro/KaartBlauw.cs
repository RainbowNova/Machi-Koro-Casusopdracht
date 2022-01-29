using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbeterde_Machi_Koro
{
    class KaartBlauw : KaartBase
    {
        public KaartBlauw(string _kaartNaam, int _kaartPrijs, List<int> _dobbelGetallen, int _aantalMunten, string _icoon)
        {
            this.Kleur = "Blauw";
            this.KaartNaam = _kaartNaam;
            this.KaartPrijs = _kaartPrijs;
            this.DobbelGetallen = _dobbelGetallen;
            this.AantalMunten = _aantalMunten;
            this.Icoon = _icoon;
            ZetKaartAfbeelding();
        }

        public override void Effect(Speler _speler)
        {
            _speler.OntvangGeld(this.AantalMunten);
        }
    }
}
