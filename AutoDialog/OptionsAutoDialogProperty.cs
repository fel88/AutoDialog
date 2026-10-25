using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class OptionsAutoDialogProperty : AbstractDialogProperty, IAutoDialogProperty<string>
    {
        ComboBox ComboBox;
        public OptionsAutoDialogProperty(Control label, ComboBox comboBox) : base([label, comboBox])
        {
            ComboBox = comboBox;
        }

        public string Value => (string)ComboBox.SelectedItem;
        public int ValueIdx => ComboBox.SelectedIndex;
    }
}
