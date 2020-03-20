using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

public enum ENUMTipoRetorno
{
	NADA=0,
	LISTA,
	DATO,
    LISTA_GENERICA
};

namespace Visor_sql_2015.Formularios
{
    public partial class AsisTipoRetorno : AsisBase
	{
		private System.Windows.Forms.RadioButton radioButton3;
		private System.ComponentModel.IContainer components = null;

		public AsisTipoRetorno()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // LTitulo
            // 
            this.LTitulo.Size = new System.Drawing.Size(520, 40);
            this.LTitulo.Text = "TIPO DE RETORNO";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(160, 24);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.Text = "Un solo registro especial";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 119);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(164, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Lista Generica Generic.List<>";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // AsisTipoRetorno
            // 
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton3);
            this.Name = "AsisTipoRetorno";
            this.Size = new System.Drawing.Size(520, 288);
            this.Controls.SetChildIndex(this.radioButton3, 0);
            this.Controls.SetChildIndex(this.radioButton1, 0);
            this.Controls.SetChildIndex(this.LTitulo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public override void Muestrate()
		{
			Dock=System.Windows.Forms.DockStyle.Fill;
			this.Visible=true;
			this.EnableAnterio=true;		
			this.EnableSiguiente=true;
			this.EnableCancelar=true;
			Asigname(this);
		}

        private RadioButton radioButton1;
    
		public ENUMTipoRetorno TipoRetornoX
		{
			get
			{
                if (radioButton3.Checked)
				    return ENUMTipoRetorno.DATO;
                return ENUMTipoRetorno.LISTA_GENERICA;
			}
		}
	}
}

