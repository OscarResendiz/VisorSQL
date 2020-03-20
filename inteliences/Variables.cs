using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;

namespace Visor_sql_2015
{
    public class Variables : ICompletionData
    {
        #region Miembros de ICompletionData
        public string Description
        {
            get { return "Variable"; }
        }
        public int ImageIndex
        {
            get { return 6; }
        }
        public bool InsertAction(TextArea textArea, char ch)
        {
            textArea.InsertString(Text);
            return false;
        }
        public double Priority
        {
            get { return 1.0; }
        }
        private string _Text;
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        #endregion
        public Variables()
        {
            _Text = "Variable";
        }
        public Variables(string Text)
        {
            this._Text = Text;
        }
    }
}
