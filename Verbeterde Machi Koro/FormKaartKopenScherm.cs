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
    partial class FormKaartKopenScherm : Form
    {
        public MachiKoro Spel { get; set; }
        public List<PictureBox> FormKaarten { get; set; }
        public bool GekliktButtonAfsluiten { get; set; }
        public FormStartScherm StartSchermForm { get; set; }
        public FormSpelvensterScherm SpelvensterSchermForm { get; set; }

        public FormKaartKopenScherm(MachiKoro _spel)
        {
            InitializeComponent();
            Spel = _spel;
        }
        private void FormKaartKopenScherm_Load(object sender, EventArgs e)
        {
            labelActieveSpelerMunten.Text = ($"U heeft {Spel.ActieveSpeler.TotaalGeld} munten.");
            FormKaarten = new List<PictureBox>();

            //(Blauw)Alle pictureboxes aan lijst toevoegen.
            this.FormKaarten.Add(pictureBoxGraanveld);
            this.FormKaarten.Add(pictureBoxVeehouderij);
            this.FormKaarten.Add(pictureBoxBos);
            this.FormKaarten.Add(pictureBoxMijn);
            this.FormKaarten.Add(pictureBoxAppelboomgaard);

            this.FormKaarten.Add(pictureBoxBakkerij);
            this.FormKaarten.Add(pictureBoxFruitmarkt);
            this.FormKaarten.Add(pictureBoxKaasfabriek);
            this.FormKaarten.Add(pictureBoxSupermarkt);
            this.FormKaarten.Add(pictureBoxMeubelfabriek);

            this.FormKaarten.Add(pictureBoxCafé);
            this.FormKaarten.Add(pictureBoxRestaurant);

            this.FormKaarten.Add(pictureBoxStadion);
            this.FormKaarten.Add(pictureBoxTvStation);
            this.FormKaarten.Add(pictureBoxBedrijfscomplex);
        }

        /// <summary>
        /// Sluit het spel af.
        /// Door tijdsnood geen manier gevonden om herhaalde knoppen gemakkelijk vaker te gebruiken. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpelStoppen_Click(object sender, EventArgs e)
        {
            DialogResult bevestigingSpelStoppen = MessageBox.Show("Weet u zeker dat u het spel wilt stoppen?", "Spel stoppen", MessageBoxButtons.YesNo);
            if (bevestigingSpelStoppen == DialogResult.Yes)
            {
                GekliktButtonAfsluiten = true;
                Spel.Spelers.Clear();
                this.Close();
                StartSchermForm.Show();
            }
        }

        /// <summary>
        /// Brengt de speler terug naar het spelvenster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAankoopAnnuleren_Click(object sender, EventArgs e)
        {
            this.Close();
            this.SpelvensterSchermForm.Show();
        }

        private void pictureBoxNietGeïmplementeerd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deze kaarten zijn nog niet geïmplementeerd. Onze excuses voor het ongemak.");
        }

        /// <summary>
        /// Zorgt ervoor dat kaarten worden uitvergroot (als deze nog te koop zijn) en dat de speler de optie krijgt
        /// om hun betaling te bevestigen of te annuleren. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxKaartKopen_Click(object sender, EventArgs e)
        {
            PictureBox pbSender = (PictureBox)sender;
            int indexFormKaarten = FormKaarten.IndexOf(pbSender); //Deze lijst bevat elke kaart 1x

            foreach (KaartBase _kaart in Spel.Kaarten)
            {
                //Als de te kopen kaart niet in de totaalkaarten zit, dan nee. Anders ja.
                KaartBase meegegevenKaart = Spel.KoopbareKaarten(FormKaarten[indexFormKaarten].Name);
                if (meegegevenKaart != null)
                { 
                    FormGrotereAfbeelding grotereKaart = new FormGrotereAfbeelding(true, Spel, this, meegegevenKaart);
                    grotereKaart.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Deze kaart is jammer genoeg niet meer te koop.");
                    pbSender.Visible = false;
                    return;
                }
            }
        }

        private void buttonInstellingen_Click(object sender, EventArgs e)
        {
            FormInstellingenScherm instellingenForm = new FormInstellingenScherm(Spel);
            instellingenForm.Show();
        }
    }
}
