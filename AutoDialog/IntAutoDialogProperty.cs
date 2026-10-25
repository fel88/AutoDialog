using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class IntAutoDialogProperty : AbstractDialogProperty, IAutoDialogProperty<int>
    {
        NumericUpDown NumericUpDown;
        public IntAutoDialogProperty(Control label, NumericUpDown numericUpDown) : base([label, numericUpDown])
        {
            NumericUpDown = numericUpDown;
        }

        public int Value => (int)NumericUpDown.Value;
    }
}
