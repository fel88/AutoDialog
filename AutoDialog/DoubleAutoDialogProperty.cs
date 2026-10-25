using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class DoubleAutoDialogProperty : IAutoDialogProperty<double>
    {
        NumericUpDown NumericUpDown;
        public DoubleAutoDialogProperty(Control label, NumericUpDown numericUpDown)
        {
            NumericUpDown = numericUpDown;
        }

        public double Value => (double)NumericUpDown.Value;
    }
}
