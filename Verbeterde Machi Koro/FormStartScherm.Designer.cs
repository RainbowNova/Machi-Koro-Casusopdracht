
namespace Verbeterde_Machi_Koro
{
    partial class FormStartScherm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSpelAfsluiten = new System.Windows.Forms.Button();
            this.buttonMensSpelerToevoegen = new System.Windows.Forms.Button();
            this.textBoxSpelerNaam = new System.Windows.Forms.TextBox();
            this.labelAantalSpelers = new System.Windows.Forms.Label();
            this.buttonSpeluitleg = new System.Windows.Forms.Button();
            this.buttonSpelStarten = new System.Windows.Forms.Button();
            this.buttonSpelerVerwijderen = new System.Windows.Forms.Button();
            this.listBoxSpelers = new System.Windows.Forms.ListBox();
            this.buttonCPUSpelerToevoegen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSpelAfsluiten
            // 
            this.buttonSpelAfsluiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSpelAfsluiten.AutoEllipsis = true;
            this.buttonSpelAfsluiten.Location = new System.Drawing.Point(820, 12);
            this.buttonSpelAfsluiten.Name = "buttonSpelAfsluiten";
            this.buttonSpelAfsluiten.Size = new System.Drawing.Size(170, 47);
            this.buttonSpelAfsluiten.TabIndex = 17;
            this.buttonSpelAfsluiten.Text = "Spel afsluiten";
            this.buttonSpelAfsluiten.UseVisualStyleBackColor = true;
            this.buttonSpelAfsluiten.Click += new System.EventHandler(this.buttonSpelAfsluiten_Click);
            // 
            // buttonMensSpelerToevoegen
            // 
            this.buttonMensSpelerToevoegen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMensSpelerToevoegen.Location = new System.Drawing.Point(581, 310);
            this.buttonMensSpelerToevoegen.Name = "buttonMensSpelerToevoegen";
            this.buttonMensSpelerToevoegen.Size = new System.Drawing.Size(40, 27);
            this.buttonMensSpelerToevoegen.TabIndex = 16;
            this.buttonMensSpelerToevoegen.Text = "+";
            this.buttonMensSpelerToevoegen.UseVisualStyleBackColor = true;
            this.buttonMensSpelerToevoegen.Click += new System.EventHandler(this.buttonSpelerToevoegen_Click);
            // 
            // textBoxSpelerNaam
            // 
            this.textBoxSpelerNaam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSpelerNaam.Location = new System.Drawing.Point(449, 310);
            this.textBoxSpelerNaam.Name = "textBoxSpelerNaam";
            this.textBoxSpelerNaam.Size = new System.Drawing.Size(125, 27);
            this.textBoxSpelerNaam.TabIndex = 15;
            this.textBoxSpelerNaam.Text = "Naam invullen";
            // 
            // labelAantalSpelers
            // 
            this.labelAantalSpelers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAantalSpelers.BackColor = System.Drawing.Color.Transparent;
            this.labelAantalSpelers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAantalSpelers.Location = new System.Drawing.Point(449, 220);
            this.labelAantalSpelers.Name = "labelAantalSpelers";
            this.labelAantalSpelers.Size = new System.Drawing.Size(125, 84);
            this.labelAantalSpelers.TabIndex = 14;
            this.labelAantalSpelers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSpeluitleg
            // 
            this.buttonSpeluitleg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpeluitleg.Location = new System.Drawing.Point(449, 411);
            this.buttonSpeluitleg.Name = "buttonSpeluitleg";
            this.buttonSpeluitleg.Size = new System.Drawing.Size(172, 55);
            this.buttonSpeluitleg.TabIndex = 13;
            this.buttonSpeluitleg.Text = "Speluitleg";
            this.buttonSpeluitleg.UseVisualStyleBackColor = true;
            this.buttonSpeluitleg.Click += new System.EventHandler(this.buttonSpeluitleg_Click);
            // 
            // buttonSpelStarten
            // 
            this.buttonSpelStarten.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpelStarten.Location = new System.Drawing.Point(271, 411);
            this.buttonSpelStarten.Name = "buttonSpelStarten";
            this.buttonSpelStarten.Size = new System.Drawing.Size(172, 55);
            this.buttonSpelStarten.TabIndex = 12;
            this.buttonSpelStarten.Text = "Spel starten";
            this.buttonSpelStarten.UseVisualStyleBackColor = true;
            this.buttonSpelStarten.Click += new System.EventHandler(this.buttonSpelStarten_Click);
            // 
            // buttonSpelerVerwijderen
            // 
            this.buttonSpelerVerwijderen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSpelerVerwijderen.Location = new System.Drawing.Point(271, 310);
            this.buttonSpelerVerwijderen.Name = "buttonSpelerVerwijderen";
            this.buttonSpelerVerwijderen.Size = new System.Drawing.Size(172, 29);
            this.buttonSpelerVerwijderen.TabIndex = 11;
            this.buttonSpelerVerwijderen.Text = "Speler verwijderen";
            this.buttonSpelerVerwijderen.UseVisualStyleBackColor = true;
            this.buttonSpelerVerwijderen.Click += new System.EventHandler(this.buttonSpelerVerwijderen_Click);
            // 
            // listBoxSpelers
            // 
            this.listBoxSpelers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxSpelers.FormattingEnabled = true;
            this.listBoxSpelers.ItemHeight = 20;
            this.listBoxSpelers.Location = new System.Drawing.Point(271, 220);
            this.listBoxSpelers.Name = "listBoxSpelers";
            this.listBoxSpelers.Size = new System.Drawing.Size(172, 84);
            this.listBoxSpelers.TabIndex = 10;
            // 
            // buttonCPUSpelerToevoegen
            // 
            this.buttonCPUSpelerToevoegen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCPUSpelerToevoegen.Location = new System.Drawing.Point(627, 310);
            this.buttonCPUSpelerToevoegen.Name = "buttonCPUSpelerToevoegen";
            this.buttonCPUSpelerToevoegen.Size = new System.Drawing.Size(40, 27);
            this.buttonCPUSpelerToevoegen.TabIndex = 19;
            this.buttonCPUSpelerToevoegen.Text = "+";
            this.buttonCPUSpelerToevoegen.UseVisualStyleBackColor = true;
            this.buttonCPUSpelerToevoegen.Click += new System.EventHandler(this.buttonSpelerToevoegen_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(581, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mens";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(627, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "CPU";
            // 
            // FormStartScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Verbeterde_Machi_Koro.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1002, 564);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCPUSpelerToevoegen);
            this.Controls.Add(this.buttonSpelAfsluiten);
            this.Controls.Add(this.buttonMensSpelerToevoegen);
            this.Controls.Add(this.textBoxSpelerNaam);
            this.Controls.Add(this.labelAantalSpelers);
            this.Controls.Add(this.buttonSpeluitleg);
            this.Controls.Add(this.buttonSpelStarten);
            this.Controls.Add(this.buttonSpelerVerwijderen);
            this.Controls.Add(this.listBoxSpelers);
            this.MaximumSize = new System.Drawing.Size(1020, 611);
            this.Name = "FormStartScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStartScherm";
            this.Load += new System.EventHandler(this.FormStartScherm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSpelAfsluiten;
        private System.Windows.Forms.Button buttonMensSpelerToevoegen;
        private System.Windows.Forms.TextBox textBoxSpelerNaam;
        private System.Windows.Forms.Label labelAantalSpelers;
        private System.Windows.Forms.Button buttonSpeluitleg;
        private System.Windows.Forms.Button buttonSpelStarten;
        private System.Windows.Forms.Button buttonSpelerVerwijderen;
        private System.Windows.Forms.ListBox listBoxSpelers;
        private System.Windows.Forms.Button buttonCPUSpelerToevoegen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}