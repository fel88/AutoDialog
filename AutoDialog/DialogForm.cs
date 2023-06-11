using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoDialog
{
    public class DialogForm : Form
    {
        public DialogForm()
        {
            Shown += DialogForm_Shown;
        }

        public new bool ShowDialog()
        {
            return base.ShowDialog() == DialogResult.OK;
        }

        const int gap = 50;
        private void DialogForm_Shown(object sender, System.EventArgs e)
        {
            var tp = Controls[0] as TableLayoutPanel;
            Height = (tp.RowCount + 1) * 30 + gap;
        }

        public void AddNumericField(string key, string caption, double? _default = null)
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            NumericUpDown m = new NumericUpDown();
            m.Maximum = 5000;
            m.Minimum = -5000;
            m.DecimalPlaces = 2;
            if (_default != null)
                m.Value = (decimal)_default.Value;

            tp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tp.RowCount++;
            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);

        }

        public void AddBoolField(string key, string caption, bool? _default = null)
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            CheckBox m = new CheckBox();

            if (_default != null)
                m.Checked = (bool)_default.Value;

            tp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tp.RowCount++;
            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
        }

        public void AddOptionsField(string key, string caption, string[] options, string _default = null)
        {
            var text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            ComboBox m = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            m.Items.AddRange(options);

            if (_default != null)
                m.SelectedItem = _default;

            tp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            tp.RowCount++;
            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
        }

        public double GetNumericField(string v)
        {
            return (double)((prms[v] as NumericUpDown).Value);
        }

        public string GetOptionsField(string v)
        {
            return (string)((prms[v] as ComboBox).SelectedItem);
        }

        public bool GetBoolField(string v)
        {
            return (bool)((prms[v] as CheckBox).Checked);
        }

        Dictionary<string, Control> prms = new Dictionary<string, Control>();
    }
}
