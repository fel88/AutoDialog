namespace AutoDialog.Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddNumericField("min", "Minimum", 128);
            d.AddNumericField("max", "Maximum", 255);

            if (!d.ShowDialog())
                return;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddOptionsField("color", "Color", new string[] { "Red", "Green", "Blue" }, "Green");            

            if (!d.ShowDialog())
                return;

            var v = d.GetOptionsField("color");
            MessageBox.Show(v);
        }
    }
}