using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class StringAutoDialogProperty : IAutoDialogProperty<string>
    {
        TextBox TextBox;
        public StringAutoDialogProperty(Control label, TextBox textBox)
        {
            TextBox = textBox;
        }

        public string Value => TextBox.Text;
    }
}
