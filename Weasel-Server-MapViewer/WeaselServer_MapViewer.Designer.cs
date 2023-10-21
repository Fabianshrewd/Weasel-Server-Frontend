namespace Weasel_Server_MapViewer
{
    partial class Form_Weasel_Server_Map_Viewer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_Online = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Online
            // 
            this.label_Online.AutoSize = true;
            this.label_Online.Location = new System.Drawing.Point(12, 9);
            this.label_Online.Name = "label_Online";
            this.label_Online.Size = new System.Drawing.Size(43, 13);
            this.label_Online.TabIndex = 0;
            this.label_Online.Text = "Online: ";
            // 
            // Form_Weasel_Server_Map_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 603);
            this.Controls.Add(this.label_Online);
            this.Name = "Form_Weasel_Server_Map_Viewer";
            this.Text = "Weasel Server Mapviewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Online;
    }
}

