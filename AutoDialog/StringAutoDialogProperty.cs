using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class StringAutoDialogProperty : AbstractDialogProperty, IAutoDialogProperty<string>
    {
        TextBox TextBox;
        public StringAutoDialogProperty(Control label, TextBox textBox) : base([label, textBox])
        {
            TextBox = textBox;
        }

        public string Value => TextBox.Text;
    }
}
