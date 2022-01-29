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
    partial class FormInstellingenScherm : Form
    {
        public MachiKoro Spel { get; set; }
        public List<Button> GeluidsKnoppen { get; set; }

        public FormInstellingenScherm(MachiKoro _spel)
        {
            InitializeComponent();
            Spel = _spel;
        }

        /// <summary>
        /// Voegt alle geluidsknoppen toe aan een lijst. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInstellingenScherm_Load(object sender, EventArgs e)
        {
            GeluidsKnoppen.Add(buttonGeluidDobbelsteen);
            GeluidsKnoppen.Add(buttonGeluidBeginSpelerbeurt);
            GeluidsKnoppen.Add(buttonGeluidKaartGekocht);
            GeluidsKnoppen.Add(buttonGeluidOverwinning);
            GeluidsKnoppen.Add(buttonGeluidAlles);
        }

        private void buttonGeluidSchakelen_Click(object sender, EventArgs e)
        {
            Button buttonSender = (Button)sender;

            int geluidsKnopIndex = GeluidsKnoppen.IndexOf(buttonSender);
            GeluidsKnoppen[geluidsKnopIndex].Text = "";
            //Lijst met booleans[geluidsKnopIndex] = !Lijst met booleans[geluidsKnopIndex]
            //als de knop de laatste is, dan foreach geluidsknop alles aan/uitzetten.

            //Als de knop de tekst "Aan" bevat, moet deze wanneer geklikt naar "uit" veranderen.
            //Ook moet de bijbehorende boolean worden uitgezet.
            //Lijst met knoppen en lijst met geluidseffectbooleans.
            //Ivm dat beide lijsten altijd gelijk zullen blijven, lijst1[i] = lijst2[i] ofzo.
        }

        /// <summary>
        /// Sluit het instellingenvenster af. - Keano
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTerugNaarSpel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
