using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class OptionsAutoDialogProperty : IAutoDialogProperty<string>
    {
        ComboBox ComboBox;
        public OptionsAutoDialogProperty(Control label, ComboBox comboBox)
        {
            ComboBox = comboBox;
        }

        public string Value => (string)ComboBox.SelectedItem;
        public int ValueIdx => ComboBox.SelectedIndex;
    }
    public class EnumOptionsAutoDialogProperty<T> : IAutoDialogProperty<T> where T : System.Enum
    {
        ComboBox ComboBox;
        public EnumOptionsAutoDialogProperty(Control label, ComboBox comboBox)
        {
            ComboBox = comboBox;
        }

        public T Value => (T)Enum.Parse(typeof(T), (string)((ComboBox).SelectedItem));

    }
}
