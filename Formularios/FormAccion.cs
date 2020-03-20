using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visor_sql_2005.Formularios
{
	/// <summary>
	/// Summary description for FormAccion.
	/// </summary>
    public partial class FormAccion : FormBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TMensaje;
		private System.Windows.Forms.Button BAceptar;
		private System.Windows.Forms.Button BCancelar;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RadioButton RElimiar;
		private System.Windows.Forms.RadioButton RVerificar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox THija;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TComentario;
		private System.ComponentModel.IContainer components;
		private int Modo;
		public FormAccion(int modo)
		{
			Modo=modo;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.RElimiar = new System.Windows.Forms.RadioButton();
			this.RVerificar = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.TMensaje = new System.Windows.Forms.TextBox();
			this.BAceptar = new System.Windows.Forms.Button();
			this.BCancelar = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.THija = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TComentario = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// RElimiar
			// 
			this.RElimiar.Checked = true;
			this.RElimiar.Location = new System.Drawing.Point(8, 32);
			this.RElimiar.Name = "RElimiar";
			this.RElimiar.Size = new System.Drawing.Size(136, 24);
			this.RElimiar.TabIndex = 2;
			this.RElimiar.TabStop = true;
			this.RElimiar.Text = "Eliminar en cascada";
			// 
			// RVerificar
			// 
			this.RVerificar.Location = new System.Drawing.Point(8, 64);
			this.RVerificar.Name = "RVerificar";
			this.RVerificar.Size = new System.Drawing.Size(136, 24);
			this.RVerificar.TabIndex = 3;
			this.RVerificar.Text = "Verificar registros";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 96);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Mensaje de error";
			// 
			// TMensaje
			// 
			this.TMensaje.Location = new System.Drawing.Point(104, 96);
			this.TMensaje.Name = "TMensaje";
			this.TMensaje.Size = new System.Drawing.Size(304, 20);
			this.TMensaje.TabIndex = 0;
			this.TMensaje.Text = "";
			// 
			// BAceptar
			// 
			this.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BAceptar.Location = new System.Drawing.Point(336, 8);
			this.BAceptar.Name = "BAceptar";
			this.BAceptar.TabIndex = 4;
			this.BAceptar.Text = "Aceptar";
			// 
			// BCancelar
			// 
			this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BCancelar.Location = new System.Drawing.Point(336, 40);
			this.BCancelar.Name = "BCancelar";
			this.BCancelar.TabIndex = 5;
			this.BCancelar.Text = "Cancelar";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 6;
			this.label2.Text = "Tabla Relacionada";
			// 
			// THija
			// 
			this.THija.Location = new System.Drawing.Point(104, 8);
			this.THija.Name = "THija";
			this.THija.ReadOnly = true;
			this.THija.Size = new System.Drawing.Size(224, 20);
			this.THija.TabIndex = 6;
			this.THija.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 120);
			this.label3.Name = "label3";
			this.label3.TabIndex = 7;
			this.label3.Text = "Comentarios";
			// 
			// TComentario
			// 
			this.TComentario.Location = new System.Drawing.Point(72, 120);
			this.TComentario.Name = "TComentario";
			this.TComentario.Size = new System.Drawing.Size(336, 20);
			this.TComentario.TabIndex = 1;
			this.TComentario.Text = "";
			// 
			// FormAccion
			// 
			this.AcceptButton = this.BAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BCancelar;
			this.ClientSize = new System.Drawing.Size(424, 152);
			this.Controls.Add(this.TComentario);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.THija);
			this.Controls.Add(this.TMensaje);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BCancelar);
			this.Controls.Add(this.BAceptar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RVerificar);
			this.Controls.Add(this.RElimiar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAccion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Accion a seguir";
			this.Load += new System.EventHandler(this.FormAccion_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			bool ok=true;
			if(RVerificar.Checked==true)
			{
				TMensaje.Enabled=true;
				if(TMensaje.Text.Trim()=="")
					ok=false;
			}
			else
			{
				TMensaje.Enabled=false;
			}
			this.BAceptar.Enabled=ok;
		}

		private void FormAccion_Load(object sender, System.EventArgs e)
		{
			if(Modo==1)
			{
				RElimiar.Enabled=true;
				RVerificar.Enabled=true;
			}
			else
			{
				RElimiar.Enabled=false;
				RVerificar.Enabled=true;
				RVerificar.Checked=true;
			}
		}
	
		public bool Eliminar
		{
			set
			{
				RVerificar.Checked=!value;
				RElimiar.Checked=value;
			}
			get
			{
				return RElimiar.Checked;
			}
		}
		public string Mensaje
		{
			get
			{
				return this.TMensaje.Text;
			}
			set
			{
				TMensaje.Text=value;
			}
		}
		public string Tabla
		{
			get
			{
				return this.THija.Text;
			}
			set
			{
				THija.Text=value;
			}
		}
		public string Comentarios
		{
			get
			{
				return TComentario.Text;
			}
			set
			{
				this.TComentario.Text=value;
			}
		}
	}
}
