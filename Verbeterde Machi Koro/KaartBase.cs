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
        public string Kleur { get; set; }
        public string KaartNaam { get; set; }
        public int KaartPrijs { get; set; }
        public List<int> DobbelGetallen { get; set; }
        public int AantalMunten { get; set; }
        public Image KaartAfbeelding { get; set; }
        public string Icoon { get; set; }

        public void GeefKaartAanSpeler(Speler _speler)
        {
            _speler.Hand.Add(this);
            _speler.MachiKoroPotje.Kaarten.Remove(this);
        }

        protected void ZetKaartAfbeelding()
        {
            this.KaartAfbeelding = Image.FromFile($"Resources/{KaartNaam}.png");
        }

        public virtual void Effect(Speler _speler) //true => met de klok mee, false = tegen de klok in.
        {
            //Niks.
        }

        public List<Speler> AflopendeVolgordeBetalingen(List<Speler> _spelers)
        {
            List<Speler> spelerLijstVoorBetalingen = new List<Speler>();

            //Zolang de te leveren lijst niet even groot is als de ingevulde lijst, moeten er spelers worden toegevoegd.
            while (spelerLijstVoorBetalingen.Count() != _spelers.Count())
            {
                //Beginnend vanaf de actieve speler tot en met de 1e speler in de lijst, worden spelers toegevoegd aan de te leveren lijst.
                for (int i = _spelers.IndexOf(_spelers[0].MachiKoroPotje.ActieveSpeler); i >= 0; i--)
                {
                    //Als de index bij het 'einde' (ofwel het begin) komt, moet deze teruggaan naar de laatste speler(s) in de ingevulde lijst.
                    if (i < 0)
                    {
                        i = _spelers.Count() - 1;
                    }
                    spelerLijstVoorBetalingen.Add(_spelers[i]);
                }
            }    
            
            return (spelerLijstVoorBetalingen);
        }
    }
}
