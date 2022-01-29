using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verbeterde_Machi_Koro
{
    class KaartGeel : KaartBase
    {
        public bool Geactiveerd { get; private set; } = false;

        public KaartGeel(string _kaartNaam, int _kaartPrijs, string _icoon)
        {
            this.Kleur = "Geel";
            this.KaartNaam = _kaartNaam;
            this.KaartPrijs = _kaartPrijs;
            this.Icoon = _icoon;
            ZetKaartAfbeelding();
        }

        /// <summary>
        /// Verandert de status van de bezienswaardigheden.
        /// </summary>
        public void Activeer()
        {
            this.Geactiveerd = true;
        }

    }
}
