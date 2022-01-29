using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verbeterde_Machi_Koro
{
    partial class FormSpelvensterScherm : Form
    {
        public MachiKoro Spel { get; set; }
        private bool gekliktButtonAfsluiten;
        public FormStartScherm StartSchermForm { get; set; }
        public List<Label> SpelerNaamLabels { get; set; } = new List<Label>();
        public List<Label> SpelerGeldLabels { get; set; } = new List<Label>();
        public List<FlowLayoutPanel> FlowLayoutPanelKaartenLijst { get; set; } = new List<FlowLayoutPanel>();
        public List<FlowLayoutPanel> FlowLayoutPanelBZLijst { get; set; } = new List<FlowLayoutPanel>();

        public FormSpelvensterScherm(MachiKoro _spel)
        {
            InitializeComponent();
            Spel = _spel;
            
            FlowLayoutPanelKaartenLijst.Add(flowLayoutPanelSpeler1Kaarten);
            FlowLayoutPanelKaartenLijst.Add(flowLayoutPanelSpeler2Kaarten);
            FlowLayoutPanelKaartenLijst.Add(flowLayoutPanelSpeler3Kaarten);
            FlowLayoutPanelKaartenLijst.Add(flowLayoutPanelSpeler4Kaarten);
            FlowLayoutPanelBZLijst.Add(flowLayoutPanelSpeler1BZ);
            FlowLayoutPanelBZLijst.Add(flowLayoutPanelSpeler2BZ);
            FlowLayoutPanelBZLijst.Add(flowLayoutPanelSpeler3BZ);
            FlowLayoutPanelBZLijst.Add(flowLayoutPanelSpeler4BZ);
        }

        /// <summary>
        /// Zorgt ervoor dat alles wordt klaargezet voor de spelers (namen op de juiste plek, kaarten worden getoond). - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSpelvensterScherm_Load(object sender, EventArgs e)
        {
            UpdateLabels();
            //Alle bezienswaardigheden en startkaarten laden.
            ToonStartKaarten();
            labelSpelerBeurt.Text = ($"Speler {Spel.ActieveSpeler} is nu aan de beurt.");
        }
        /// <summary>
        /// Ik heb oprecht geen idee waarom, maar WinForms creeërt telkens de _Load en _Load1.
        /// Wanneer ik een verwijder, werkt de applicatie niet omdat de ander mist. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSpelvensterScherm_Load1(object sender, EventArgs e)
        {
            //Alle bezienswaardigheden en startkaarten laden.
            labelNaamSpeler1.Text = Spel.Spelers[0].Naam;
            labelNaamSpeler2.Text = Spel.Spelers[1].Naam;
            labelNaamSpeler3.Text = Spel.Spelers[2].Naam;
            labelNaamSpeler4.Text = Spel.Spelers[3].Naam;

            UpdateLabels();

            buttonDobbelsteen1.Image = Image.FromFile($"Resources/Dobbelsteen/1.png");
            buttonDobbelsteen2.Image = Image.FromFile($"Resources/Dobbelsteen/1.png");

            ToonStartKaarten();
            labelSpelerBeurt.Text = ($"Speler {Spel.ActieveSpeler} is nu aan de beurt.");
        }

        /// <summary>
        /// Zorgt ervoor dat de geld labels worden geüpdate.
        /// Wordt gebruikt aan het begin van het spel en na elke kaartaankoop.
        /// Wordt ook gebruikt nadat alle kaarten zijn geactiveerd.
        /// </summary>
        public void UpdateLabels()
        {
            for (int i = 0; i < Spel.Spelers.Count(); i++)
            {
                switch (i)
                {
                    case 0: //Onnodig aangezien er altijd minimaal 2 spelers zullen zijn. Dus je hoeft niet te controleren of er een speler in Spelers[0] zit.
                        labelNaamSpeler1.Text = Spel.Spelers[0].Naam;
                        labelSpeler1Geld.Text = Spel.Spelers[0].TotaalGeld.ToString();
                        break;
                    case 1:
                        labelNaamSpeler2.Text = Spel.Spelers[1].Naam;
                        labelSpeler2Geld.Text = Spel.Spelers[1].TotaalGeld.ToString();
                        break;
                    case 2:
                        labelNaamSpeler3.Text = Spel.Spelers[2].Naam;
                        labelSpeler3Geld.Text = Spel.Spelers[2].TotaalGeld.ToString();
                        break;
                    case 3:
                        labelNaamSpeler4.Text = Spel.Spelers[3].Naam;
                        labelSpeler4Geld.Text = Spel.Spelers[3].TotaalGeld.ToString();
                        break;
                    default:
                        break;
                }
            } 
        }

        /// <summary>
        /// Zorgt ervoor dat alle bezienswaardigheden en startkaarten worden getoond.
        /// </summary>
        private void ToonStartKaarten()
        {
            foreach (Speler _speler in Spel.Spelers)
            {
                for (int aantalKaarten = 0; aantalKaarten < _speler.Hand.Count; aantalKaarten++)
                {
                    KaartAfbeeldingToevoegen(_speler, _speler.Hand[aantalKaarten]);
                }
                for (int aantalBZ = 0; aantalBZ < _speler.Bezienswaardigheden.Count(); aantalBZ++)
                {
                    KaartAfbeeldingToevoegen(_speler, _speler.Bezienswaardigheden[aantalBZ]);
                }
            }
        }

        /// <summary>
        /// Zorgt ervoor dat kaarten worden toegevoegd aan de lijst met kaarten van de spelers. 
        /// Wordt aan het begin van het spel gebruikt, maar ook bij het kopen van een kaart. - Keano
        /// </summary>
        /// <param name="_speler"></param>
        /// <param name="_kaart"></param>
        public void KaartAfbeeldingToevoegen(Speler _speler, KaartBase _kaart)
        {
            FlowLayoutPanel tijdelijkKopie;
            PictureBox pictureBoxKaart = new PictureBox();

            pictureBoxKaart.Image = Image.FromFile($"Resources/{_kaart.KaartNaam}.png");
            pictureBoxKaart.Name = _kaart.KaartNaam + " " + _speler.Naam;
            pictureBoxKaart.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxKaart.Size = new System.Drawing.Size(50, 69);
            pictureBoxKaart.BackColor = Color.Transparent;

            if (_speler.Bezienswaardigheden.Contains(_kaart))
            {
                tijdelijkKopie = FlowLayoutPanelBZLijst[Spel.Spelers.IndexOf(_speler)];
            }
            else
            {
                tijdelijkKopie = FlowLayoutPanelKaartenLijst[Spel.Spelers.IndexOf(_speler)];
            }
            tijdelijkKopie.Controls.Add(pictureBoxKaart);
            if (_kaart.KaartNaam == "Treinstation" || _kaart.KaartNaam == "Winkelcentrum" || _kaart.KaartNaam == "Pretpark" || _kaart.KaartNaam == "Radiostation")
            {
                pictureBoxKaart.Click += new EventHandler(pictureBoxBezienswaardigheidKopen_Click);
            }
        }



        /// <summary>
        /// Stopt het huidige spel, maar sluit niet de applicatie af. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpelStoppen_Click(object sender, EventArgs e)
        {
            DialogResult bevestigingSpelStoppen = MessageBox.Show("Weet u zeker dat u het spel wilt stoppen?", "Spel stoppen", MessageBoxButtons.YesNo);
            if (bevestigingSpelStoppen == DialogResult.Yes)
            {
                gekliktButtonAfsluiten = true;
                Spel.Spelers.Clear();
                this.Close();
                StartSchermForm.Show();
            }
        }

        /// <summary>
        /// Opent het instellingenscherm bovenop het Spelvenster/Koopkaartscherm. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInstellingen_Click(object sender, EventArgs e)
        {
            FormInstellingenScherm instellingenForm = new FormInstellingenScherm(Spel);
            instellingenForm.Show();
        }

        /// <summary>
        /// Verbergt het spelvenster en opent het scherm waar de speler kaarten kan kopen, als zij nog niet gedobbeld hebben. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNaarKaartKoopScherm_Click(object sender, EventArgs e)
        {
            if (Spel.ActieveSpeler.HeeftGedobbeld == true)
            {
                FormKaartKopenScherm kaartKoopScherm = new FormKaartKopenScherm(Spel);
                kaartKoopScherm.StartSchermForm = this.StartSchermForm;
                kaartKoopScherm.SpelvensterSchermForm = this;
                this.Hide();
                kaartKoopScherm.Show();
            }
            else { MessageBox.Show("U mag nog geen kaart kopen totdat u heeft gedobbeld."); }
        }

        /// <summary>
        /// Eindigt de beurt als de speler hiervoor kiest óf als de speler een kaart koopt.
        /// Hiervoor moet de speler minimaal 1x gedobbeld hebben. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonEindeBeurt_Click(object sender, EventArgs e)
        {
            if (Spel.ActieveSpeler.HeeftGedobbeld) //De speler moet hebben gedobbeld om de beurt te mogen beëindigen.
            {
                Label kopieControle = new Label();
                kopieControle.Text = labelSpelerBeurt.Text;

                Spel.ActieveSpeler.EindeBeurt();

                labelSpelerBeurt.Text = ($"Speler {Spel.ActieveSpeler} is nu aan de beurt.");

                if (labelSpelerBeurt.Text == kopieControle.Text)
                {
                    MessageBox.Show($"{Spel.ActieveSpeler.Naam} mag nog een keer dobbelen, omdat zij net met 2 dobbelstenen dezelfde ogen hebben gerold!");
                }
                buttonDobbelsteen1.Enabled = true;
                buttonDobbelsteen2.Enabled = true;
            }
            else
            {
                MessageBox.Show("U mag uw beurt niet beëindigen totdat u heeft gedobbeld.");
            }
            if (Spel.IsSpelEinde())
            {
                MessageBox.Show($"Speler {Spel.Winnaar} heeft gewonnen!");
                gekliktButtonAfsluiten = true;
                this.StartSchermForm.Show();
                this.Close();
            }
        }

        /// <summary>
        /// De gebruiker wordt gevraagd of zij zeker weten dat zij de applicatie willen afsluiten. - Keano
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (gekliktButtonAfsluiten == false)
            {
                if (MessageBox.Show("Weet u zeker dat u het programma wilt afsluiten?", "Afsluiten Machi Koro", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    this.StartSchermForm.Close();
                }
            }
        }

        /// <summary>
        /// Laat de actieve speler dobbelen.
        /// Hierbij worden controles in deze class nogmaals uitgevoerd zodat de MessageBoxes aan de speler kunnen worden getoond.
        /// Ten slotte zal de speler deze beurt 1 kans krijgen om te herdobbelen als zij het Treinstation hebben geactiveerd.
        /// - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDobbelsteen_Click(object sender, EventArgs e)
        {
            //Dit gaat weg wanneer alles werkt.
            Button buttonSender = (Button)sender;

            if (Spel.ActieveSpeler.HeeftGedobbeld == false)
            {
                if (buttonSender == buttonDobbelsteen1)
                {
                    Spel.ActieveSpeler.Dobbelen(1);
                    if (Spel.ActieveSpeler.GedobbeldeGetallen.Count() != 0)
                    {
                        buttonDobbelsteen1.Image = Image.FromFile($"Resources/{Spel.ActieveSpeler.GedobbeldeGetallen[0]}.png");
                    }
                    else { MessageBox.Show("U mag maar 1x dobbelen per beurt, tenzij u daar de juiste kaart voor bezit."); }
                }
                else if (buttonSender == buttonDobbelsteen2)
                {
                    Spel.ActieveSpeler.Dobbelen(2);
                    if (!Spel.ActieveSpeler.GedobbeldeGetallen.Contains(0))
                    {
                        buttonDobbelsteen1.Image = Image.FromFile($"Resources/{Spel.ActieveSpeler.GedobbeldeGetallen[0]}.png");
                        buttonDobbelsteen2.Image = Image.FromFile($"Resources/{Spel.ActieveSpeler.GedobbeldeGetallen[1]}.png");
                    }
                    else { MessageBox.Show("U mag alleen met 2 dobbelstenen dobbelen als u het \"Treinstation\" heeft gekocht. "); }
                }
            }
            else { MessageBox.Show("U mag maar 1x dobbelen per beurt, tenzij u daar de juiste kaart voor bezit."); }

            if (Spel.ActieveSpeler.BezienswaardigheidGeactiveerd("Radiostation") && Spel.ActieveSpeler.HeeftHerdobbeld == false)
            {
                DialogResult dialogResult = MessageBox.Show("Wilt u opnieuw dobbelen? (Max. 1x per beurt)", "Herdobbelkans", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Spel.ActieveSpeler.Herdobbelen();
                }
                else if (dialogResult == DialogResult.No)
                {
                    buttonDobbelsteen1.Enabled = false;
                    buttonDobbelsteen2.Enabled = false;
                }
            }
            Spel.ActiveerKaarten();
            UpdateLabels();
        }

        /// <summary>
        /// Dit is jammer genoeg heel erg slordig gedaan, i.v.m. dat ik dit last-minute heb moeten doen. - Keano
        /// De actieve speler kan op de bezienswaardigheden van anderen klikken, maar zij zijn wel de persoon die de kaart krijgen.
        /// Voor de speler momenteel geen probleem, i.v.m. dat de bezienswaardigheden geen duidelijk verschil hebben tussen gekocht en ongekocht.
        /// In de toekomst, als er updates komen, zal dit zéér zeker aangepast moeten worden. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxBezienswaardigheidKopen_Click(object sender, EventArgs e)
        {
            if (Spel.ActieveSpeler.HeeftGedobbeld == false)
            {
                MessageBox.Show("U mag geen kaarten kopen totdat u heeft gedobbeld.");
            }
            else
            {
                PictureBox pbSender = (PictureBox)sender;
                List<string> lijstBZ = new List<string>() { "Treinstation", "Winkelcentrum", "Pretpark", "Radiostation" };

                foreach (string _bzNaam in lijstBZ)
                {
                    if (pbSender.Name.Contains(_bzNaam))
                    {
                        int index = lijstBZ.IndexOf(_bzNaam);
                        if (Spel.ActieveSpeler.BezienswaardigheidGeactiveerd(_bzNaam))
                        {
                            MessageBox.Show("U heeft deze bezienswaardigheid al gekocht!");
                        }
                        else if (Spel.ActieveSpeler.TotaalGeld >= Spel.ActieveSpeler.Bezienswaardigheden[index].KaartPrijs)
                        {
                            Spel.ActieveSpeler.KoopKaart(Spel.ActieveSpeler.Bezienswaardigheden[index]);
                            MessageBox.Show($"U heeft een {Spel.ActieveSpeler.Bezienswaardigheden[index].KaartNaam} gekocht!");
                            UpdateLabels();
                        }
                        else { MessageBox.Show($"Deze kaart kost {Spel.ActieveSpeler.Bezienswaardigheden[index].KaartPrijs} munten. U heeft niet genoeg geld."); }
                    }
                }
            }
        }
    }
}
