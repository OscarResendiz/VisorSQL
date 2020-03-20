namespace Visor_sql_2008
{
    partial class LoadingInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LAction = new System.Windows.Forms.Label();
            this.ProgressShower = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LDB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LAction
            // 
            this.LAction.BackColor = System.Drawing.Color.Transparent;
            this.LAction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LAction.Location = new System.Drawing.Point(85, 104);
            this.LAction.Name = "LAction";
            this.LAction.Size = new System.Drawing.Size(321, 21);
            this.LAction.TabIndex = 9;
            this.LAction.Text = "Accion Realizandose";
            // 
            // ProgressShower
            // 
            this.ProgressShower.Location = new System.Drawing.Point(88, 78);
            this.ProgressShower.Name = "ProgressShower";
            this.ProgressShower.Size = new System.Drawing.Size(318, 23);
            this.ProgressShower.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressShower.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(152, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LDB
            // 
            this.LDB.BackColor = System.Drawing.Color.Transparent;
            this.LDB.Location = new System.Drawing.Point(85, 60);
            this.LDB.Name = "LDB";
            this.LDB.Size = new System.Drawing.Size(321, 15);
            this.LDB.TabIndex = 6;
            this.LDB.Text = "Base de Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(190, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Extrayendo Informacion";
            // 
            // LoadingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LAction);
            this.Controls.Add(this.ProgressShower);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LDB);
            this.Controls.Add(this.label1);
            this.Name = "LoadingInfo";
            this.Size = new System.Drawing.Size(490, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LAction;
        private System.Windows.Forms.ProgressBar ProgressShower;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LDB;
        private System.Windows.Forms.Label label1;
    }
}
