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
    partial class FormGrotereAfbeelding : Form
    {
        public MachiKoro Spel { get; set; }
        public FormKaartKopenScherm BijbehorendScherm { get; set; }
        public KaartBase MeegegevenKaart { get; set; }
        public FormGrotereAfbeelding(bool _kopen, MachiKoro _spel, FormKaartKopenScherm _bijbehorendScherm, KaartBase _meegegevenKaart)
        {
            InitializeComponent();
            this.Spel = _spel;
            this.BijbehorendScherm = _bijbehorendScherm;
            this.MeegegevenKaart = _meegegevenKaart;
            this.pictureBoxGrotereKaart.Image = _meegegevenKaart.KaartAfbeelding;
            this.buttonKoopKaart.Visible = _kopen;
        }

        private void FormGrotereAfbeelding_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonKoopKaart_Click(object sender, EventArgs e)
        {
            if (Spel.ActieveSpeler.TotaalGeld >= this.MeegegevenKaart.KaartPrijs)
            {
                bool magKopen = true;

                foreach (KaartBase _kaart in Spel.ActieveSpeler.Hand)
                {
                    if (_kaart.KaartNaam == (this.MeegegevenKaart.KaartNaam) && MeegegevenKaart.Kleur == "Paars")
                    {
                        MessageBox.Show("U mag per paarse kaart maar 1 exemplaar kopen.");
                        magKopen = false;
                    }
                }
                if(magKopen) //Moet los staan van de foreach-loop ivm dat collections niet gewijzigd mogen worden tijdens een loop. - Keano
                {
                    Spel.ActieveSpeler.KoopKaart(this.MeegegevenKaart); //Geeft de speler de kaart en haalt deze uit de koopbare kaarten.

                    MessageBox.Show($"U heeft een {MeegegevenKaart.KaartNaam} gekocht!");
                    BijbehorendScherm.SpelvensterSchermForm.UpdateLabels();
                    BijbehorendScherm.SpelvensterSchermForm.KaartAfbeeldingToevoegen(Spel.ActieveSpeler, MeegegevenKaart);
                    BijbehorendScherm.SpelvensterSchermForm.Show();
                    BijbehorendScherm.Close();
                    this.Close();
                    BijbehorendScherm.SpelvensterSchermForm.buttonEindeBeurt.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("U heeft niet genoeg geld om deze kaart te kopen.");
            }
        }

        /// <summary>
        /// Annuleert de aankoop van de geselecteerde kaart.
        /// Brengt de speler terug naar het scherm met de koopbare kaarten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnnuleer_Click(object sender, EventArgs e)
        {
            this.BijbehorendScherm.Show();
            this.Close();
        }
    }
}
