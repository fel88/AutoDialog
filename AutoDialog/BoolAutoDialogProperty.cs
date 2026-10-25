using AutoDialog.Interfaces;
using System.Windows.Forms;

namespace AutoDialog
{
    public class BoolAutoDialogProperty : AbstractDialogProperty, IAutoDialogProperty<bool>
    {
        CheckBox CheckBox;
        public BoolAutoDialogProperty(Control label, CheckBox checkBox) : base([label, checkBox])
        {
            CheckBox = checkBox;            
        }

        public bool Value => CheckBox.Checked;
    }
}
