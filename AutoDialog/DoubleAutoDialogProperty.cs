using AutoDialog.Interfaces;

namespace AutoDialog
{
    public class DoubleAutoDialogProperty : AbstractDialogProperty, IAutoDialogProperty<double>
    {
        NumericUpDown NumericUpDown;
        public DoubleAutoDialogProperty(Control label, NumericUpDown numericUpDown) : base([label, numericUpDown])
        {
            NumericUpDown = numericUpDown;            
        }

        public double Value => (double)NumericUpDown.Value;
    }
}
