using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Verbeterde_Machi_Koro
{
    public partial class FormStartScherm : Form
    {
        private MachiKoro Spel { get; set; }
        private bool GekliktButtonAfsluiten { get; set; }

        public FormStartScherm()
        {
            InitializeComponent();
            Spel = new MachiKoro();
            listBoxSpelers.Items.Clear(); //Voor de zekerheid - Keano
        }

        private void FormStartScherm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Als het scherm wordt afgesloten, wordt de gebruiker gevraagd of het bewust was gedaan. - Keano
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (GekliktButtonAfsluiten == false)
            {
                if (MessageBox.Show("Weet u zeker dat u het programma wilt afsluiten?", "Afsluiten Machi Koro", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Als het scherm wordt afgesloten, wordt de gebruiker gevraagd of het bewust was gedaan. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpelAfsluiten_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u het programma wilt afsluiten?", "Afsluiten Machi Koro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GekliktButtonAfsluiten = true;
                this.Close();
            }
        }

        /// <summary>
        /// Voegt 1 speler toe aan het spel. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpelerToevoegen_Click(object sender, EventArgs e)
        {
            Button buttonSender = (Button)sender;
            if (buttonSender == buttonCPUSpelerToevoegen)
            {
                MessageBox.Show("Computerspelers zijn nog niet bruikbaar. Onze excuses voor het ongemak.");
            }

            if (!String.IsNullOrWhiteSpace(textBoxSpelerNaam.Text))
            {
                if (Spel.Spelers.Count() == 4)
                {
                    MessageBox.Show("Er mogen maar 4 spelers meedoen aan een potje.");
                }
                else
                {
                    if (buttonSender == buttonMensSpelerToevoegen)
                    {
                        Spel.ToevoegenSpeler(textBoxSpelerNaam.Text, false);
                        listBoxSpelers.Items.Add(Spel.Spelers[Spel.Spelers.Count - 1]);
                    }
                    //Bewaren voor in de toekomst, wanneer CPU spelers worden toegevoegd.
                    /*else
                    {
                        Spel.ToevoegenSpeler(textBoxSpelerNaam.Text, true);
                    }*/
                    //listBoxSpelers.Items.Add(Spel.Spelers[Spel.Spelers.Count - 1]);
                }
                textBoxSpelerNaam.Clear();
            }
            else
            {
                MessageBox.Show("U mag geen lege naam invullen.");
            }
        }

        /// <summary>
        /// Verwijdert 1 speler. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpelerVerwijderen_Click(object sender, EventArgs e)
        {
            if (listBoxSpelers.SelectedItem == null)
            {
                MessageBox.Show("U heeft geen speler geselecteerd om te verwijderen.");
            }
            else
            {
                Spel.VerwijderenSpeler(Spel.Spelers[listBoxSpelers.SelectedIndex]);
                listBoxSpelers.Items.Remove(listBoxSpelers.SelectedItem);
            }
        }

        /// <summary>
        /// Toont de uitleg aan de gebruiker. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSpeluitleg_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.spelregels.eu/PDF/spelregels-machi-koro.pdf") { UseShellExecute = true });
        }

        private void buttonSpelStarten_Click(object sender, EventArgs e)
        {
            if (Spel.Spelers.Count > 1)
            {
                if (Spel.Spelers.Count < 5)
                {
                    Spel.BeginSpel();

                    FormSpelvensterScherm spelScherm = new FormSpelvensterScherm(Spel);
                    spelScherm.StartSchermForm = this;
                    this.Hide(); //Mag niet afgesloten worden i.v.m. dat het de main form is => applicatie sluit af als deze sluit.
                    listBoxSpelers.Items.Clear(); //De spelers zullen dit scherm niet meer zien tot het spel voorbij is. - Keano
                    spelScherm.Show();
                }
                else
                {
                    MessageBox.Show("Er mogen maar 4 spelers aan een potje meedoen.");
                }
            }
            else
            {
                MessageBox.Show("Er moeten minimaal 2 mensen aan een potje meedoen.");
            }
            
        }
    }
}
