
namespace Verbeterde_Machi_Koro
{
    partial class FormGrotereAfbeelding
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
            this.pictureBoxGrotereKaart = new System.Windows.Forms.PictureBox();
            this.buttonKoopKaart = new System.Windows.Forms.Button();
            this.buttonAnnuleer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrotereKaart)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGrotereKaart
            // 
            this.pictureBoxGrotereKaart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxGrotereKaart.Location = new System.Drawing.Point(251, 134);
            this.pictureBoxGrotereKaart.Name = "pictureBoxGrotereKaart";
            this.pictureBoxGrotereKaart.Size = new System.Drawing.Size(295, 409);
            this.pictureBoxGrotereKaart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGrotereKaart.TabIndex = 0;
            this.pictureBoxGrotereKaart.TabStop = false;
            // 
            // buttonKoopKaart
            // 
            this.buttonKoopKaart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonKoopKaart.Location = new System.Drawing.Point(251, 567);
            this.buttonKoopKaart.Name = "buttonKoopKaart";
            this.buttonKoopKaart.Size = new System.Drawing.Size(295, 48);
            this.buttonKoopKaart.TabIndex = 1;
            this.buttonKoopKaart.Text = "Koop kaart";
            this.buttonKoopKaart.UseVisualStyleBackColor = true;
            this.buttonKoopKaart.Click += new System.EventHandler(this.buttonKoopKaart_Click);
            // 
            // buttonAnnuleer
            // 
            this.buttonAnnuleer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnuleer.Location = new System.Drawing.Point(578, 567);
            this.buttonAnnuleer.Name = "buttonAnnuleer";
            this.buttonAnnuleer.Size = new System.Drawing.Size(211, 48);
            this.buttonAnnuleer.TabIndex = 2;
            this.buttonAnnuleer.Text = "Annuleer";
            this.buttonAnnuleer.UseVisualStyleBackColor = true;
            this.buttonAnnuleer.Click += new System.EventHandler(this.buttonAnnuleer_Click);
            // 
            // FormGrotereAfbeelding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Verbeterde_Machi_Koro.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(818, 653);
            this.Controls.Add(this.buttonAnnuleer);
            this.Controls.Add(this.buttonKoopKaart);
            this.Controls.Add(this.pictureBoxGrotereKaart);
            this.MaximumSize = new System.Drawing.Size(836, 700);
            this.Name = "FormGrotereAfbeelding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGrotereAfbeelding";
            this.Load += new System.EventHandler(this.FormGrotereAfbeelding_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrotereKaart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGrotereKaart;
        private System.Windows.Forms.Button buttonKoopKaart;
        private System.Windows.Forms.Button buttonAnnuleer;
    }
}