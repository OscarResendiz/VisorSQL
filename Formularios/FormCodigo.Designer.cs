namespace Visor_sql_2005.Formularios
{
    partial class FormCodigoX
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
            this.components = new System.ComponentModel.Container();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TCodigo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cTextColor1 = new TextColor.CTextColor(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(53, 6);
            this.TNombre.Name = "TNombre";
            this.TNombre.ReadOnly = true;
            this.TNombre.Size = new System.Drawing.Size(323, 20);
            this.TNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 488);
            this.panel2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TCodigo);
            this.splitContainer1.Size = new System.Drawing.Size(586, 488);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 1;
            // 
            // TCodigo
            // 
            this.TCodigo.AcceptsTab = true;
            this.TCodigo.BackColor = System.Drawing.Color.Navy;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCodigo.ForeColor = System.Drawing.Color.Yellow;
            this.TCodigo.Location = new System.Drawing.Point(0, 0);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.TCodigo.Size = new System.Drawing.Size(586, 452);
            this.TCodigo.TabIndex = 0;
            this.TCodigo.Text = "";
            this.TCodigo.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TNombre);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 36);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cTextColor1
            // 
            this.cTextColor1.BackColor = System.Drawing.Color.Navy;
            this.cTextColor1.ColorCadena = System.Drawing.Color.White;
            this.cTextColor1.ColorComentario = System.Drawing.Color.Red;
            this.cTextColor1.ColorIdentificador = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorNumero = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cTextColor1.ColorOtro = System.Drawing.Color.Yellow;
            this.cTextColor1.ColorPalabraRserevada = System.Drawing.Color.Lime;
            this.cTextColor1.ColorSimbolo = System.Drawing.Color.Cyan;
            this.cTextColor1.ColorVariable = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cTextColor1.RichTextBox = this.TCodigo;
            // 
            // FormCodigoX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormCodigoX";
            this.Text = "FormCodigo";
            this.Load += new System.EventHandler(this.FormCodigo_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox TCodigo;
        private TextColor.CTextColor cTextColor1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}