using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class IntAutoDialogProperty : IAutoDialogProperty<int>
    {
        NumericUpDown NumericUpDown;
        public IntAutoDialogProperty(Control label, NumericUpDown numericUpDown)
        {
            NumericUpDown = numericUpDown;
        }

        public int Value => (int)NumericUpDown.Value;
    }
}
