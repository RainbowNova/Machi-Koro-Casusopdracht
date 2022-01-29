using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbeterde_Machi_Koro
{
    class KaartRood : KaartBase
    {
        public KaartRood(string _kaartNaam, int _kaartPrijs, List<int> _dobbelGetallen, int _aantalMunten, string _icoon)
        {
            this.Kleur = "Rood";
            this.KaartNaam = _kaartNaam;
            this.KaartPrijs = _kaartPrijs;
            this.DobbelGetallen = _dobbelGetallen;
            this.AantalMunten = _aantalMunten;
            this.Icoon = _icoon;
            ZetKaartAfbeelding();
        }

        /// <summary>
        /// Voor de rode kaarten ontvangt de _speler munten van de actieve speler die de rode kaart(en) heeft geactiveerd.
        /// De transacties gebeuren tegen de klok in.
        /// De betalende speler moet eerst alle transacties bij 1 speler afmaken voor hij de volgende speler mag betalen.
        /// Daarnaast stopt het betalen zodra de betalende speler 0 munten heeft.
        /// Schulden worden weggescholden. - Keano
        /// </summary>
        /// <param name="_speler"></param>
        public override void Effect(Speler _speler) //_speler is de speler die munten ontvangt.
        {
            //Zolang de betalende speler > 0 munten heeft, moeten zij munten afstaan tot zij aan de AantalMunten voldoen.
            //Controle: heeft de betalende speler meer dan 0 munten? - Keano
            for (int Schuld = this.AantalMunten; Schuld > 0; Schuld--)
            {
                if (_speler.MachiKoroPotje.ActieveSpeler.TotaalGeld > 0) //Heeft de actieve speler geld?
                {
                    //Als de ontvangende speler het "Winkelcentrum" heeft gekocht, krijgen zij
                    //1 extra munt per geactiveerde rode kaart.
                    int mogelijkAangepasteAantalMunten = this.AantalMunten + Convert.ToInt32(_speler.BezienswaardigheidGeactiveerd("Winkelcentrum"));
                    _speler.OntvangGeld(mogelijkAangepasteAantalMunten, _speler.MachiKoroPotje.ActieveSpeler);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
