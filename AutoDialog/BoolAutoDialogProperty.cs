using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class BoolAutoDialogProperty : IAutoDialogProperty<bool>
    {
        CheckBox CheckBox;
        public BoolAutoDialogProperty(Control label, CheckBox checkBox)
        {
            CheckBox = checkBox;
        }

        public bool Value => CheckBox.Checked;
    }
}
