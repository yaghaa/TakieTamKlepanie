namespace SKP.KRD
{
    partial class SKPKRD
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
            this.dgvCharacters = new System.Windows.Forms.DataGridView();
            this.pButtons = new System.Windows.Forms.Panel();
            this.bShowAllCharacter = new System.Windows.Forms.Button();
            this.bAddCharacter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).BeginInit();
            this.pButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCharacters
            // 
            this.dgvCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCharacters.Location = new System.Drawing.Point(0, 0);
            this.dgvCharacters.Name = "dgvCharacters";
            this.dgvCharacters.Size = new System.Drawing.Size(560, 666);
            this.dgvCharacters.TabIndex = 1;
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.bAddCharacter);
            this.pButtons.Controls.Add(this.bShowAllCharacter);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButtons.Location = new System.Drawing.Point(0, 0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(560, 84);
            this.pButtons.TabIndex = 2;
            // 
            // bShowAllCharacter
            // 
            this.bShowAllCharacter.Location = new System.Drawing.Point(12, 12);
            this.bShowAllCharacter.Name = "bShowAllCharacter";
            this.bShowAllCharacter.Size = new System.Drawing.Size(147, 23);
            this.bShowAllCharacter.TabIndex = 0;
            this.bShowAllCharacter.Text = "Pokaż wszystkie postaci";
            this.bShowAllCharacter.UseVisualStyleBackColor = true;
            this.bShowAllCharacter.Click += new System.EventHandler(this.bShowAllCharacter_Click);
            // 
            // bAddCharacter
            // 
            this.bAddCharacter.Location = new System.Drawing.Point(199, 12);
            this.bAddCharacter.Name = "bAddCharacter";
            this.bAddCharacter.Size = new System.Drawing.Size(75, 23);
            this.bAddCharacter.TabIndex = 1;
            this.bAddCharacter.Text = "Dodaj postać";
            this.bAddCharacter.UseVisualStyleBackColor = true;
            this.bAddCharacter.Click += new System.EventHandler(this.bAddCharacter_Click);
            // 
            // SKPKRD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 666);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.dgvCharacters);
            this.Name = "SKPKRD";
            this.Text = "SKP.KRD";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCharacters;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button bShowAllCharacter;
        private System.Windows.Forms.Button bAddCharacter;
    }
}

