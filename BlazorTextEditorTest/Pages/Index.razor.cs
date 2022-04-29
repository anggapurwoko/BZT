using Blazored.TextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTextEditorTest.Pages
{
    public partial class Index
    {
        public bool _showDialog { get; set; } = false;
        public string _notes { get; set; } = "hello <b>world</b>";
        BlazoredTextEditor noteTextEditor { get; set; }

        public async Task SetTextEditorAsync(string s)
        {
            try
            {
                await this.noteTextEditor.LoadHTMLContent(s);
                StateHasChanged();
            }
            catch (Exception e)
            {
            }
        }
        public async Task CloseDialogAsync()
        {
            _showDialog = false;

            /// the noteTextEditor control is not binded to _notes variable, we need to retrieve the value using GetHTML method
            this._notes = await this.noteTextEditor.GetHTML();
        }
        public void OpenDialog()
        {
            _showDialog = true;
        } 
    }
}
