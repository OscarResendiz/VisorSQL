using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Linq;

namespace Visor_sql_2015
{
    public partial class EditorGenerico : UserControl
    {
        public EditorGenerico()
        {
            InitializeComponent();
        }
        public virtual void Guardar()
        {
        }
        #region Opciones de Edicion
        public virtual void EdicionCopiar()
        {
        }
        public virtual void EdicionPegar()
        {
        }
        public virtual void EdicionCortar()
        {
        }
        #endregion
        #region Deshacer y rehacer
        public virtual void EdicionDeshacer()
        {
        }
        public virtual void EdicionReHacer()
        {
        }
        #endregion
        public virtual void Ejecutar()
        {
        }
        public virtual void Comentar()
        {
        }
        public virtual void DesComentar()
        {
        }
        public virtual Editor.TextRange FindNext(bool viaF3, bool searchBackward, string messageIfNotFound, string TextoBuscar, bool CaseSensitive, bool WholeWords)
        {
            return null;
        }
        public virtual void ReemplazarSiguiente(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
        }
        public virtual void RemplazarTodo(string textoBuscar, string TextoRemplazar, bool CaseSensitive, bool WholeWords)
        {
        }
        public virtual void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar)
        {
        }
        public virtual void VistaPrevia()
        {
        }
        public virtual void ConfigurarPagina()
        {
        }
        public virtual void Imprimir()
        {
        }
        public virtual void SetFocus()
        {
        }
    }
}
