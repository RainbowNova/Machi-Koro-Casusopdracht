using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Verbeterde_Machi_Koro
{
    abstract class KaartBase
    {
        public string Kleur { get; protected set; }
        public string KaartNaam { get; protected set; }
        public int KaartPrijs { get; protected set; }
        public List<int> DobbelGetallen { get; protected set; }
        public int AantalMunten { get; protected set; }
        public Image KaartAfbeelding { get; protected set; }
        public string Icoon { get; protected set; }


        protected void ZetKaartAfbeelding()
        {
            this.KaartAfbeelding = Image.FromFile($"Resources/{KaartNaam}.png");
        }

        public virtual void Effect(Speler _speler) //true => met de klok mee, false = tegen de klok in.
        {
            //Niks.
        }
    }
}
