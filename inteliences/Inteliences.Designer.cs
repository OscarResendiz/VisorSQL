namespace Visor_sql_2015
{
    partial class Inteliences
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inteliences));
            this.PopIList = new System.Windows.Forms.ImageList(this.components);
            this.cAnaLex1 = new AnalizadorLexico.CAnaLex(this.components);
            // 
            // PopIList
            // 
            this.PopIList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PopIList.ImageStream")));
            this.PopIList.TransparentColor = System.Drawing.Color.Transparent;
            this.PopIList.Images.SetKeyName(0, "Table_24.png");
            this.PopIList.Images.SetKeyName(1, "Glasses_22.png");
            this.PopIList.Images.SetKeyName(2, "24_Lighting.png");
            this.PopIList.Images.SetKeyName(3, "24_Field.png");
            this.PopIList.Images.SetKeyName(4, "ShortCut_24.png");
            this.PopIList.Images.SetKeyName(5, "22_PKey.png");
            this.PopIList.Images.SetKeyName(6, "16_@.png");
            this.PopIList.Images.SetKeyName(7, "22_Snippet.png");
            this.PopIList.Images.SetKeyName(8, "Database_24.png");
            // 
            // cAnaLex1
            // 
            this.cAnaLex1.Texto = null;

        }

        #endregion

        private System.Windows.Forms.ImageList PopIList;
        private AnalizadorLexico.CAnaLex cAnaLex1;
    }
}
