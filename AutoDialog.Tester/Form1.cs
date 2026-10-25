using AutoDialog.Extensions;
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
            var minProp = d.AddDouble("Minimum", 128, min: 0, max: 255, decimalPlaces: 0);
            var maxProp = d.AddDouble("Maximum", 255, min: 0, max: 255, decimalPlaces: 0);
            var boolProp = d.AddBool("Check");

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered values: {minProp.Value}  {maxProp.Value} {boolProp.Value}");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var prop = d.AddInt("Integer", 128, -10, 500);

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered value: {prop.Value}");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var strProp1 = d.AddString("String 1");
            var strProp2 = d.AddString("String 2", "default");

            if (!d.ShowDialog())
                return;

            MessageBox.Show($"Entered value: {strProp1.Value}{Environment.NewLine}{strProp2.Value}");
        }

        private void options1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var colorOpt = d.AddOptions("Color", new string[] { "Red", "Green", "Blue" }, "Green");

            if (!d.ShowDialog())
                return;

            MessageBox.Show(colorOpt.Value);
        }

        private void options2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var list = new string[] { "Red", "Green", "Blue", "Red" };
            var colorOpt = d.AddOptions("Color", list, 3);

            if (!d.ShowDialog())
                return;

            var idx = colorOpt.ValueIdx;
            MessageBox.Show($"#{idx} : {list[idx]}");
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
            d.AddInt("num1", "Num 1");
            d.AddInt("num2", "Num 2");
            d.AddValidator("num1", (c) =>
            {
                return d.GetInt("num1") > d.GetInt("num2");
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

            MessageBox.Show($"{d.GetInt("num1")} > {d.GetInt("num2")}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            d.AddCustomDialogField("custom", "Color", () =>
            {
                ColorDialog cd = new ColorDialog();
                cd.Color = this.ForeColor;
                cd.ShowDialog();
                this.ForeColor = cd.Color;
            });
            d.AddCustomDialogField("font", "Font", () =>
            {
                FontDialog f = new FontDialog();
                f.Font = toolStrip1.Font;
                f.ShowDialog();
                toolStrip1.Font = f.Font;
            });

            if (!d.ShowDialog())
                return;
        }

        private void test1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.EditWithAutoDialog();
        }

        private void test2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            //  d.GapPerRow = 20;

            d.AppendPropertiesToDialog(this);
            //d.SetWidth(600);

            d.Init();
            d.ApplyButton.Text = "Save and quit";
            d.ApplyButton.AutoSize = true;
            d.Top = 0;
            if (!d.ShowDialog())
                return;

            d.ExtractPropertiesToObject(this);

        }

        private void enumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            var list = new string[] { "Red", "Green", "Blue", "Red" };

            var prop = d.AddEnum("FormBorderStyle", FormBorderStyle);

            if (!d.ShowDialog())
                return;

            this.FormBorderStyle = prop.Value;
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();

            d.AddDouble("n1", "Num 1");
            d.NewColumn();
            d.AddDouble("n2", "Num 2");

            if (!d.ShowDialog())
                return;

            var n1 = d.GetDouble("n1");
            var n2 = d.GetDouble("n2");
            MessageBox.Show($"{n1},  {n2}");
        }

        private void longLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = DialogHelpers.StartDialog();
            
            d.CellStep += 30;            
            d.ColumnStep += 30;            

            var prop = d.AddDouble("Put_extremely_long_label_here");                        
            var prop2 = d.AddDouble("Num 2");           
            
            if (!d.ShowDialog())
                return;

            var n1 = prop.Value;
            var n2 = prop2.Value;
            MessageBox.Show($"{n1},  {n2}");
        }       
        
    }
}