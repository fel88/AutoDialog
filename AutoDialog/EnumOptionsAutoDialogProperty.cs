using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class EnumOptionsAutoDialogProperty<T> : AbstractDialogProperty, IAutoDialogProperty<T> where T : System.Enum
    {
        ComboBox ComboBox;
        public EnumOptionsAutoDialogProperty(Control label, ComboBox comboBox) : base([label, comboBox])
        {
            ComboBox = comboBox;
        }

        public T Value => (T)Enum.Parse(typeof(T), (string)((ComboBox).SelectedItem));

    }
}
