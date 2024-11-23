using System.Collections.Immutable;

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
            d.AddNumericField("min", "Minimum", 128, min: 0, max: 255, decimalPlaces: 0);
            d.AddNumericField("max", "Maximum", 255, min: 0, max: 255, decimalPlaces: 0);

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered values: {d.GetIntegerNumericField("min")}  {d.GetIntegerNumericField("max")}");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddIntegerNumericField("int", "Integer", 128, 500, -10);

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered value: {d.GetIntegerNumericField("int")}");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddStringField("str1", "String 1");
            d.AddStringField("str2", "String 2", "default");

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered value: {d.GetStringField("str1")}{Environment.NewLine}{d.GetStringField("str2")}");
        }

        private void options1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddOptionsField("color", "Color", new string[] { "Red", "Green", "Blue" }, "Green");

            if (!d.ShowDialog())
                return;

            var v = d.GetOptionsField("color");
            MessageBox.Show(v);
        }

        private void options2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var list = new string[] { "Red", "Green", "Blue", "Red" };
            d.AddOptionsField("color", "Color", list, 3);

            if (!d.ShowDialog())
                return;

            var v = d.GetOptionsFieldIdx("color");
            MessageBox.Show($"#{v} : {list[v]}");
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddStringField("str1", "String 1");
            d.AddStringField("str2", "String 2", "default");
            d.AddValidator("str1", (c) =>
            {
                return !string.IsNullOrEmpty(((TextBox)c).Text);
            });

            d.OnValidationStart = () =>
            {
                foreach (var item in d.CreatedControls.Keys)
                {
                    d.CreatedControls[item][0].ForeColor = Color.Black;
                }
            };

            d.OnValidationFailed = (keys) =>
            {
                foreach (var item in keys)
                {
                    d.CreatedControls[item][0].ForeColor = Color.Red;
                }
                if (keys.Contains("str1"))
                {
                    MessageBox.Show("String 1 not filled", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered value: {d.GetStringField("str1")}{Environment.NewLine}{d.GetStringField("str2")}");
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddIntegerNumericField("num1", "Num 1");
            d.AddIntegerNumericField("num2", "Num 2");
            d.AddValidator("num1", (c) =>
            {
                return d.GetIntegerNumericField("num1") > d.GetIntegerNumericField("num2");
            });

            d.OnValidationStart = () =>
            {
                foreach (var item in d.CreatedControls.Keys)
                {
                    d.CreatedControls[item][0].ForeColor = Color.Black;
                }
            };

            d.OnValidationFailed = (keys) =>
            {
                foreach (var item in keys)
                {
                    d.CreatedControls[item][0].ForeColor = Color.Red;
                }
                if (keys.Contains("num1"))
                {
                    MessageBox.Show("Num 1 should be greater than Num 2", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"{d.GetIntegerNumericField("num1")} > {d.GetIntegerNumericField("num2")}");
        }
    }
}