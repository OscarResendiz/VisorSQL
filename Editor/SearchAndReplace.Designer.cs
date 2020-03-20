namespace Visor_sql_2015.Editor
{
    partial class SearchAndReplace
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.TxtReplace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CaseSensitive = new System.Windows.Forms.CheckBox();
            this.WholeWords = new System.Windows.Forms.CheckBox();
            this.Prior = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.ReplaceAll = new System.Windows.Forms.Button();
            this.ReplaceOne = new System.Windows.Forms.Button();
            this.MarkAll = new System.Windows.Forms.Button();
            this.formOpacador1 = new Opacador.FormOpacador(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto a Buscar:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(140, 4);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(284, 23);
            this.TxtSearch.TabIndex = 1;
            // 
            // TxtReplace
            // 
            this.TxtReplace.Location = new System.Drawing.Point(140, 30);
            this.TxtReplace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtReplace.Name = "TxtReplace";
            this.TxtReplace.Size = new System.Drawing.Size(284, 23);
            this.TxtReplace.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reemplazar Texto con:";
            // 
            // CaseSensitive
            // 
            this.CaseSensitive.AutoSize = true;
            this.CaseSensitive.BackColor = System.Drawing.Color.Transparent;
            this.CaseSensitive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CaseSensitive.Location = new System.Drawing.Point(140, 57);
            this.CaseSensitive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CaseSensitive.Name = "CaseSensitive";
            this.CaseSensitive.Size = new System.Drawing.Size(230, 19);
            this.CaseSensitive.TabIndex = 4;
            this.CaseSensitive.Text = "Sensitivo a mayusculas y minusculas";
            this.CaseSensitive.UseVisualStyleBackColor = false;
            // 
            // WholeWords
            // 
            this.WholeWords.AutoSize = true;
            this.WholeWords.BackColor = System.Drawing.Color.Transparent;
            this.WholeWords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.WholeWords.Location = new System.Drawing.Point(140, 80);
            this.WholeWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WholeWords.Name = "WholeWords";
            this.WholeWords.Size = new System.Drawing.Size(137, 19);
            this.WholeWords.TabIndex = 5;
            this.WholeWords.Text = "Palabras Completas";
            this.WholeWords.UseVisualStyleBackColor = false;
            // 
            // Prior
            // 
            this.Prior.BackColor = System.Drawing.Color.Black;
            this.Prior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Prior.Location = new System.Drawing.Point(7, 108);
            this.Prior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Prior.Name = "Prior";
            this.Prior.Size = new System.Drawing.Size(143, 42);
            this.Prior.TabIndex = 6;
            this.Prior.Text = "Buscar Anterior";
            this.Prior.UseVisualStyleBackColor = false;
            this.Prior.Click += new System.EventHandler(this.btnFindPrevious_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.Black;
            this.Next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Next.Location = new System.Drawing.Point(155, 108);
            this.Next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(143, 42);
            this.Next.TabIndex = 7;
            this.Next.Text = "Buscar Siguiente";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Black;
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Close.Location = new System.Drawing.Point(304, 108);
            this.Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(120, 135);
            this.Close.TabIndex = 8;
            this.Close.Text = "Cerrar Ventana";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // ReplaceAll
            // 
            this.ReplaceAll.BackColor = System.Drawing.Color.Black;
            this.ReplaceAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ReplaceAll.Location = new System.Drawing.Point(155, 155);
            this.ReplaceAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReplaceAll.Name = "ReplaceAll";
            this.ReplaceAll.Size = new System.Drawing.Size(143, 42);
            this.ReplaceAll.TabIndex = 10;
            this.ReplaceAll.Text = "Reemplazar Todos";
            this.ReplaceAll.UseVisualStyleBackColor = false;
            this.ReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // ReplaceOne
            // 
            this.ReplaceOne.BackColor = System.Drawing.Color.Black;
            this.ReplaceOne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ReplaceOne.Location = new System.Drawing.Point(7, 155);
            this.ReplaceOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReplaceOne.Name = "ReplaceOne";
            this.ReplaceOne.Size = new System.Drawing.Size(143, 42);
            this.ReplaceOne.TabIndex = 9;
            this.ReplaceOne.Text = "Reemplazar Siguiente";
            this.ReplaceOne.UseVisualStyleBackColor = false;
            this.ReplaceOne.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // MarkAll
            // 
            this.MarkAll.BackColor = System.Drawing.Color.Black;
            this.MarkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MarkAll.Location = new System.Drawing.Point(49, 201);
            this.MarkAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MarkAll.Name = "MarkAll";
            this.MarkAll.Size = new System.Drawing.Size(249, 42);
            this.MarkAll.TabIndex = 11;
            this.MarkAll.Text = "Marcar todas las coincidencias";
            this.MarkAll.UseVisualStyleBackColor = false;
            this.MarkAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // formOpacador1
            // 
            this.formOpacador1.AutoCerrar = true;
            this.formOpacador1.Degradado = true;
            this.formOpacador1.Formulario = this;
            this.formOpacador1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.formOpacador1.PrimerColor = System.Drawing.Color.Black;
            this.formOpacador1.SegundoColor = System.Drawing.Color.White;
            this.formOpacador1.Tiempo = 1;
            this.formOpacador1.Visible = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(12, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(36, 41);
            this.panel1.TabIndex = 12;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SearchAndReplace
            // 
            this.AcceptButton = this.Next;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Close;
            this.ClientSize = new System.Drawing.Size(430, 244);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MarkAll);
            this.Controls.Add(this.ReplaceAll);
            this.Controls.Add(this.ReplaceOne);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Prior);
            this.Controls.Add(this.WholeWords);
            this.Controls.Add(this.CaseSensitive);
            this.Controls.Add(this.TxtReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SearchAndReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda y/o reemplazo de texto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.TextBox TxtReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CaseSensitive;
        private System.Windows.Forms.CheckBox WholeWords;
        private System.Windows.Forms.Button Prior;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button ReplaceAll;
        private System.Windows.Forms.Button ReplaceOne;
        private System.Windows.Forms.Button MarkAll;
        private Opacador.FormOpacador formOpacador1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}