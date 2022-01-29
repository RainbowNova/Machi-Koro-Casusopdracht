using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbeterde_Machi_Koro
{
    class MachiKoro
    {
        public List<Speler> Spelers { get; set; }
        public Speler ActieveSpeler { get; set; }
        public List<KaartBase> Kaarten { get; set; }
        public Speler Winnaar { get; private set; }

        public MachiKoro()
        {
            Spelers = new List<Speler>();
            Kaarten = GenereerKaarten();
        }

        /// <summary>
        /// Genereert alle koopbare kaarten. - Keano
        /// </summary>
        /// <returns></returns>
        public List<KaartBase> GenereerKaarten()
        {
            List<KaartBase> nieuweKaartenLijst = new List<KaartBase>();

            for (int i = 0; i < 6; i++)
            {
                nieuweKaartenLijst.Add(new KaartBlauw("Graanveld", 1, new List<int>(){ 1 }, 1, "Graan"));
                nieuweKaartenLijst.Add(new KaartBlauw("Veehouderij", 1, new List<int>() { 2 }, 1, "Dier"));
                nieuweKaartenLijst.Add(new KaartBlauw("Bos", 3, new List<int>() { 5 }, 1, "Tandwiel"));
                nieuweKaartenLijst.Add(new KaartBlauw("Mijn", 6, new List<int>() { 9 }, 5, "Tandwiel"));
                nieuweKaartenLijst.Add(new KaartBlauw("Appelboomgaard", 3, new List<int>() { 10 }, 3, "Graan"));

                //Groene kaarten
                nieuweKaartenLijst.Add(new KaartGroen("Bakkerij", 1, new List<int>() { 2, 3 }, 1, "Brood"));
                nieuweKaartenLijst.Add(new KaartGroen("Fruitmarkt", 2, new List<int>() { 11, 12 }, 2, "Appel"));
                nieuweKaartenLijst.Add(new KaartGroen("Kaasfabriek", 5, new List<int>() { 7 }, 3, "Fabriek"));
                nieuweKaartenLijst.Add(new KaartGroen("Supermarkt", 2, new List<int>() { 4 }, 3, "Brood"));
                nieuweKaartenLijst.Add(new KaartGroen("Meubelfabriek", 3, new List<int>() { 8 }, 3, "Fabriek"));

                //Rode kaarten
                nieuweKaartenLijst.Add(new KaartRood("Café", 2, new List<int>() { 3 }, 1, "Koffiekop"));
                nieuweKaartenLijst.Add(new KaartRood("Restaurant", 3, new List<int>() { 9, 10 }, 2, "Koffiekop"));

                if(i < 4)
                {
                    //Paarse kaarten
                    nieuweKaartenLijst.Add(new KaartPaars("Stadion", 6, new List<int>() { 6 }, 2, "Torenmast"));
                    nieuweKaartenLijst.Add(new KaartPaars("TvStation", 7, new List<int>() { 6 }, 5, "Torenmast"));
                    nieuweKaartenLijst.Add(new KaartPaars("Bedrijfscomplex", 8, new List<int>() { 6 }, 0, "Torenmast"));
                }
        }
            return (nieuweKaartenLijst);
        }

        /// <summary>
        /// Voegt spelers toe. - Keano
        /// </summary>
        /// <param name="_spelerNaam"></param>
        /// <param name="_isComputer"></param>
        public void ToevoegenSpeler(string _spelerNaam, bool _isComputer)
        {
            if (!(String.IsNullOrWhiteSpace(_spelerNaam)))
            {
                Spelers.Add(new Speler(_spelerNaam, _isComputer, this));
            }       
        }

        /// <summary>
        /// Verwijdert spelers van het spel. - Keano
        /// </summary>
        /// <param name="_speler"></param>
        public void VerwijderenSpeler(Speler _speler)
        {
            if (_speler != null)
            {
                Spelers.Remove(_speler);
            }
        }

        /// <summary>
        /// Bepaalt welke speler aan de beurt is. - Keano
        /// </summary>
        public void BepaalActieveSpeler(bool _extraBeurtDezelfdeSpeler) //Als true, dan krijgt dezelfde speler nog een beurt.
        {
            if (_extraBeurtDezelfdeSpeler == true)
            {
                this.ActieveSpeler = this.ActieveSpeler;
            }
            else if(_extraBeurtDezelfdeSpeler == false)
            {
                int spelerIndex = this.Spelers.IndexOf(ActieveSpeler);
                if (this.ActieveSpeler == null || spelerIndex == this.Spelers.Count() - 1) //Als de huidige actieve speler de laatste in de lijst is, dan is speler 1 weer aan de beurt.
                {
                    this.ActieveSpeler = this.Spelers[0];
                }
                else
                {
                    this.ActieveSpeler = this.Spelers[spelerIndex + 1];
                }
            }
        }

        /// <summary>
        /// Als het spel tussen niet minder dan 1 en niet meer dan 4 spelers bevat, zal het spel starten.
        /// De eerste toegevoegde speler zal eerst aan de beurt zijn.
        /// </summary>
        public void BeginSpel()
        {
            if ((this.Spelers.Count() > 1) && (this.Spelers.Count() < 5))
            {
                BepaalActieveSpeler(false);
            }
        }

        /// <summary>
        /// Zorgt ervoor dat de verschillende kleuren kaarten in de juiste volgorde worden geactiveerd, zolang
        /// het totale aantal ogen hoger is dan 0. - Keano
        /// </summary>
        public void ActiveerKaarten()
        {
            int totaalAantalOgen = this.ActieveSpeler.GedobbeldeGetallen.Sum();

            if (totaalAantalOgen > 0)
            {
                ActiveerKaartenHulpMethode(totaalAantalOgen, "Rood");
                ActiveerKaartenHulpMethode(totaalAantalOgen, "Blauw");
                ActiveerKaartenHulpMethode(totaalAantalOgen, "Groen");
                ActiveerKaartenHulpMethode(totaalAantalOgen, "Paars");
            }
        }

        /// <summary>
        /// Zorgt ervoor dat de code voor de verschillende kleuren kaarten niet 3x onnodig vaak geplakt hoeven te worden.
        /// Maakt de code lichtelijk overzichtelijker. - Keano
        /// </summary>
        /// <param name="_totaalAantalOgen"></param>
        /// <param name="_kaartKleur"></param>
        public void ActiveerKaartenHulpMethode(int _totaalAantalOgen, string _kaartKleur)
        {
            List<Speler> transactieLijst =  BepaalTransactiesVolgorde(_kaartKleur);

            foreach (Speler _speler in transactieLijst)
            {
                foreach (KaartBase _kaart in _speler.Hand)
                {
                    if (_kaart.DobbelGetallen.Contains(_totaalAantalOgen) && _kaart.Kleur == _kaartKleur)
                    {
                        _kaart.Effect(_speler);
                    }
                }
            }
        }

        /// <summary>
        /// Bepaalt de volgorde van de betalingen.
        /// Bij blauwe en groene kaarten maakt dit niet uit. 
        /// Bij rode en paarse kaarten moeten transacties tegen de klok in worden betaald. - Keano
        /// </summary>
        /// <returns></returns>
        public List<Speler> BepaalTransactiesVolgorde(string _kaartKleur)
        {
            if (_kaartKleur == "Rood" || _kaartKleur == "Paars")
            {
                List<Speler> spelerLijstVoorBetalingen = new List<Speler>();

                //Zolang de te leveren lijst niet even groot is als de ingevulde lijst, moeten er spelers worden toegevoegd.
                while (spelerLijstVoorBetalingen.Count() != this.Spelers.Count())
                {
                    spelerLijstVoorBetalingen.Add(this.ActieveSpeler);
                    //Zolang i niet de index bereikt van de actieve speler, verlaag de index met 1.
                    for (int i = this.Spelers.IndexOf(this.ActieveSpeler); i != this.Spelers.IndexOf(this.ActieveSpeler); i--)
                    {
                        if (!(i <= 0)) //Als de index 0 bereikt, moet de index teruggaan naar het einde van de spelers lijst.
                        {
                            spelerLijstVoorBetalingen.Add(this.Spelers[i]);
                        }
                        else
                        {
                            i = Spelers.Count - 1;
                        }
                    }
                }
                return (spelerLijstVoorBetalingen);
            }
            return (this.Spelers); //Ik ga ervan uit dat als de kaart niet rood/paars is, dat deze blauw/groen is.
        }

        /// <summary>
        /// Controleert welke kaarten koopbaar zijn voor de UI. - Keano
        /// </summary>
        /// <param name="_kaartNaam"></param>
        /// <returns></returns>
        public KaartBase KoopbareKaarten(string _kaartNaam)
        {
            foreach (KaartBase _kaart in this.Kaarten)
            {
                if (_kaartNaam.Contains(_kaart.KaartNaam))
                {
                    return _kaart;
                }
            }
            return null;
        }


        /// <summary>
        /// Als 1 speler alle 4 de bezienswaardigheden heeft geactiveerd, dan winnen zij het spel. - Keano
        /// </summary>
        public bool IsSpelEinde()
        {
            foreach (Speler _speler in this.Spelers)
            {
                if (_speler.BezienswaardigheidGeactiveerd("Treinstation") && _speler.BezienswaardigheidGeactiveerd("Winkelcentrum") && _speler.BezienswaardigheidGeactiveerd("Pretpark") && _speler.BezienswaardigheidGeactiveerd("Radiostation"))
                {
                    this.Spelers.Clear();
                    Winnaar = _speler;
                    return true;
                }
            }
            return (false);
        }
    }
}
