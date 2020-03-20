namespace Visor_sql_2015.patrones
{
    partial class FormPatron
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatron));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.TCodigo = new RichTextBoxPrintCtrl.RichTextBoxPrintCtrl();
            this.cTextColor1 = new TextColor.CTextColor(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TxtNombre,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(700, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel1.Text = "Nombre";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton2.Text = "Cerrar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // TCodigo
            // 
            this.TCodigo.AcceptsTab = true;
            this.TCodigo.AutoWordSelection = true;
            this.TCodigo.BackColor = System.Drawing.Color.Navy;
            this.TCodigo.DetectUrls = false;
            this.TCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigo.EnableAutoDragDrop = true;
            this.TCodigo.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.TCodigo.ForeColor = System.Drawing.Color.Yellow;
            this.TCodigo.Location = new System.Drawing.Point(0, 25);
            this.TCodigo.Name = "TCodigo";
            this.TCodigo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.TCodigo.Size = new System.Drawing.Size(700, 486);
            this.TCodigo.TabIndex = 3;
            this.TCodigo.Text = "";
            this.TCodigo.WordWrap = false;
            this.TCodigo.TextChanged += new System.EventHandler(this.TCodigo_TextChanged);
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
            this.cTextColor1.Tiempo = 50;
            this.cTextColor1.OnCambiaFoco += new TextColor.OnCambiaFocoEvent(this.cTextColor1_OnCambiaFoco);
            // 
            // FormPatron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 511);
            this.Controls.Add(this.TCodigo);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormPatron";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propiedades del patrón";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TxtNombre;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private RichTextBoxPrintCtrl.RichTextBoxPrintCtrl TCodigo;
        private TextColor.CTextColor cTextColor1;
    }
}