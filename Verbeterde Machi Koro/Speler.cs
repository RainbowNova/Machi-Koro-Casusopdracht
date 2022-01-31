using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbeterde_Machi_Koro
{
    class Speler
    {
        public string Naam { get; private set; }
        public List<KaartBase> Hand { get; private set; }
        public List<KaartGeel> Bezienswaardigheden { get; private set; }
        public int TotaalGeld { get; private set; } = 3;
        public List<int> GedobbeldeGetallen { get; private set; }
        public bool IsComputer { get; private set; }
        public bool HeeftGedobbeld { get; private set; } = false;
        public bool TweemaalDezelfdeOgenGedobbeld { get; private set; } = false;
        public bool HeeftHerdobbeld { get; private set; } = false;
        public MachiKoro MachiKoroPotje { get; private set; }

        public Speler(string _naam, bool _isComputer, MachiKoro _spel)
        {
            if (_isComputer == true)
            {
                Naam = _naam + " (CPU)";
            }
            else { Naam = _naam; }

            Hand = new List<KaartBase>();
            Bezienswaardigheden = new List<KaartGeel>();
            IsComputer = _isComputer;
            MachiKoroPotje = _spel;

            //Toevoegen startkaarten
            this.Hand.Add(new KaartGroen("Bakkerij", 1, new List<int>() { 2, 3 }, 1, "Brood"));
            this.Hand.Add(new KaartBlauw("Graanveld", 0, new List<int>() { 1 }, 1, "Graan"));

            this.Bezienswaardigheden.Add(new KaartGeel("Treinstation", 4, "Torenmast"));
            this.Bezienswaardigheden.Add(new KaartGeel("Winkelcentrum", 10, "Torenmast"));
            this.Bezienswaardigheden.Add(new KaartGeel("Pretpark", 16, "Torenmast"));
            this.Bezienswaardigheden.Add(new KaartGeel("Radiostation", 22, "Torenmast"));
        }

        /// <summary>
        /// Zorgt ervoor dat de speler betaalt en de kaart ontvangt, zolang deze genoeg munten heeft.
        /// Na het kopen van een kaart eindigt een beurt automatisch. - Keano
        /// </summary>
        public void KoopKaart(KaartBase _kaart)
        {
            if (this.TotaalGeld >= _kaart.KaartPrijs)
            {
                this.TotaalGeld -= _kaart.KaartPrijs;

                if (_kaart.Kleur == "Geel")
                {
                    foreach (KaartGeel _geleKaart in this.Bezienswaardigheden)
                    {
                        if (_kaart.KaartNaam == _geleKaart.KaartNaam && _geleKaart.Geactiveerd != true)
                        {
                            int indexGeleKaart = this.Bezienswaardigheden.IndexOf(_geleKaart);
                            this.Bezienswaardigheden[indexGeleKaart].Activeer();
                        }
                    }
                }
                else if (_kaart.Kleur == "Paars") //Spelers mogen van elke paarse kaart maar 1 hebben.
                {
                    if (!this.Hand.Contains(_kaart))
                    {
                        this.MachiKoroPotje.Kaarten.Remove(_kaart);
                        this.Hand.Add(_kaart);
                    }
                }
                else
                {
                    this.MachiKoroPotje.Kaarten.Remove(_kaart);
                    this.Hand.Add(_kaart);
                }
            }
        }

        /// <summary>
        ///V De speler moet eerst dobbelen voor zij een kaart mogen kopen of de beurt mogen beëindigen.
        ///V De speler mag alleen met 2 dobbelstenen dobbelen als zij hiervoor de juiste BZ hebben. 
        ///V Als de speler met beide dobbelstenen hetzelfde aantal ogen gooit, krijgen zij na deze beurt nog een beurt als zij hiervoor de juiste BZ hebben gekocht.
        ///V De speler krijgt direct na het dobbelen de keuze of zij willen herdobbelen als zij de juiste BZ hiervoor hebben gekocht.
        /// - Keano
        /// </summary>
        public void Dobbelen(int _aantalDobbelstenen)
        {
            GedobbeldeGetallen = new List<int>();

            //Heeft de speler al gedobbeld? Zo nee, dan mogen zij dat nu. - Keano
            if (this.HeeftGedobbeld == false)
            {
                if (_aantalDobbelstenen == 1)
                {
                    Random tijdelijkDobbelGetal = new Random();
                    this.GedobbeldeGetallen.Add(tijdelijkDobbelGetal.Next(1, 7));
                    this.HeeftGedobbeld = true;
                }
                else if (_aantalDobbelstenen == 2)
                {
                    //Controleert of de speler wel met 2 dobbelstenen mag rollen.
                    if (BezienswaardigheidGeactiveerd("Treinstation"))
                    {
                        Random tijdelijkDobbelGetal1 = new Random();
                        Random tijdelijkDobbelGetal2 = new Random();
                        this.GedobbeldeGetallen.Add(tijdelijkDobbelGetal1.Next(1, 7));
                        this.GedobbeldeGetallen.Add(tijdelijkDobbelGetal2.Next(1, 7));
                        this.HeeftGedobbeld = true;

                        //Controleert of de speler een extra beurt mag krijgen als zij met beide dobbelstenen hetzelfde aantal ogen rollen.
                        //- Keano
                        if (BezienswaardigheidGeactiveerd("Pretpark"))
                        {
                            if (this.GedobbeldeGetallen[0] == this.GedobbeldeGetallen[1])
                            {
                                this.TweemaalDezelfdeOgenGedobbeld = true;
                            }
                        }
                    }
                    else { this.GedobbeldeGetallen = new List<int>() { 0 }; }
                }
            }
        }

        /// <summary>
        /// De speler mag maar 1x herdobbelen per beurt.
        /// Deze methode wordt alleen aangeroepen als de speler ervoor kiest om te herdobbelen.
        /// De speler moet eerst dobbelen om te mogen herdobbelen.
        /// Als de speler herdobbelt, dan wordt de oude dobbelwaarde verwaarloosd.
        /// De nieuwe dobbelwaarde geldt dan.
        /// Dus: 
        /// 1. Dobbelen levert lijst met getallen.
        /// 2. Wilt speler herdobbelen?
        /// 3. Ja? -> Dobbelen nog eens.
        /// 4. Nee? -> Activeer kaarten.
        /// </summary>
        /// <returns></returns>
        public void Herdobbelen()
        {
            //Om te herdobbelen moet de speler:
            // 1. De juiste BZ geactiveerd hebben.
            // 2. Minstens 1x gedobbeld hebben.
            // 3. Nog niet herdobbeld deze beurt.
            if (this.BezienswaardigheidGeactiveerd("Radiostation") && this.HeeftGedobbeld && this.HeeftHerdobbeld == false)
            {
                this.HeeftGedobbeld = false;
                this.HeeftHerdobbeld = true;
                this.TweemaalDezelfdeOgenGedobbeld = false;
                this.GedobbeldeGetallen = new List<int>(){ 0 };
            }
        }

        /// <summary>
        /// Controleert of de gevraagde bezienswaardigheidskaart geactiveerd is.
        /// </summary>
        /// <param name="_gevraagdeBezienswaardigheid"></param>
        /// <returns></returns>
        public bool BezienswaardigheidGeactiveerd(string _gevraagdeBezienswaardigheid)
        {
            foreach (KaartGeel _geleKaart in this.Bezienswaardigheden)
            {
                if (_geleKaart.KaartNaam == _gevraagdeBezienswaardigheid && _geleKaart.Geactiveerd)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Als de speler heeft gedobbeld, mogen zij de beurt beëindigen.
        /// Dit gebeurt ook als de speler een kaart heeft gekocht.
        /// </summary>
        public void EindeBeurt()
        {
            if (this.HeeftGedobbeld) //De speler moet hebben gedobbeld om de beurt te mogen beëindigen.
            {
                if (this.TweemaalDezelfdeOgenGedobbeld) //Als true, dan is de BZ voor de extra beurt geactiveerd.
                {
                    this.MachiKoroPotje.BepaalActieveSpeler(true); //Dit geeft de huidige speler de extra beurt.
                    this.TweemaalDezelfdeOgenGedobbeld = false; //Weer uitzetten zodat het nog een keer kan voorkomen.
                    this.HeeftGedobbeld = false;
                }
                else
                {
                    this.MachiKoroPotje.BepaalActieveSpeler(false);
                }
            }
            this.HeeftHerdobbeld = false;
            this.HeeftGedobbeld = false;
        }

        public override string ToString()
        {
            return (Naam);
        }


        /// <summary>
        /// Deze methode is overloaded.
        /// Als er 1 argument wordt meegegeven, dan krijgt de speler een munt van de 'bank'.
        /// De speler waarop de methode wordt gebruikt krijgt geld van de ingevoerde speler. - Keano
        /// - Keano
        /// </summary>
        /// <param name="_geld"></param>
        public void OntvangGeld(int _geld)
        {
            this.TotaalGeld += _geld;
        }

        /// <summary>
        /// Deze methode is overloaded.
        /// De speler waarop de methode wordt gebruikt krijgt geld van de ingevoerde speler. - Keano
        /// </summary>
        /// <param name="_geld"></param>
        /// <param name="_ontvangendeSpeler"></param>
        /// <param name="_betalendeSpeler"></param>
        public void OntvangGeld(int _geld, Speler _betalendeSpeler)
        {
            this.TotaalGeld += _geld;
            _betalendeSpeler.TotaalGeld -= _geld;
        }
    }
}
