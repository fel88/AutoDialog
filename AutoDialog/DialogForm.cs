﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace System.Net.Http { }

namespace AutoDialog
{
    public class DialogForm : Form
    {
        public DialogForm()
        {
            Shown += DialogForm_Shown;
            FormClosing += DialogForm_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            tp = new TableLayoutPanel();
            tp.Dock = DockStyle.Fill;
            Controls.Add(tp);

            ok = new Button() { Text = "apply" };
            tp.Controls.Add(ok, 0, tp.RowCount - 1);
            ok.Click += Ok_Click;

        }
        Button ok;
        public Button ApplyButton => ok;
        TableLayoutPanel tp;
        private void DialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            OnValidationStart?.Invoke();

            List<string> failedKeys = new List<string>();
            foreach (var item in Validators)
            {
                if (!item.Predicate(prms[item.Key]))
                {
                    failedKeys.Add(item.Key);
                    e.Cancel = true;
                }
            }
            OnValidationFailed?.Invoke(failedKeys.ToArray());
        }

        public Action<string[]> OnValidationFailed;
        public Action OnValidationStart;

        public void AddValidator(string key, Func<Control, bool> p)
        {
            Validators.Add(new Validator() { Key = key, Predicate = p });
        }

        public List<Validator> Validators = new List<Validator>();


        private void Apply()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Apply();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Apply();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public new bool ShowDialog()
        {
            return base.ShowDialog() == DialogResult.OK;
        }

        public int StaticGap = 50;
        public int GapPerRow = 30;
        bool inited = false;
        public void Init()
        {
            if (inited)
                return;

            inited = true;

            var tp = Controls[0] as TableLayoutPanel;

            Height = (tp.RowCount + 1) * GapPerRow + StaticGap;
            foreach (var item in tp.Controls.OfType<Control>())
            {
                if (item is TextBox b || item is NumericUpDown || item is ComboBox)
                {
                    item.Focus();
                    if (item is TextBox tb)
                    {
                        tb.SelectAll();
                    }
                    if (item is NumericUpDown n)
                    {
                        n.Select(0, n.Text.Length);
                    }
                    break;
                }
            }
        }

        private void DialogForm_Shown(object sender, System.EventArgs e)
        {
            Init();
        }

        public void AddIntegerNumericField(string key, string caption, double? _default = null, decimal max = 1000, decimal min = 0)
        {
            AddNumericField(key, caption, _default, max, min, 0);
        }

        public void AddNumericField(string key, string caption, double? _default = null, decimal max = 1000, decimal min = 0, int decimalPlaces = 2)
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            NumericUpDown m = new NumericUpDown();
            m.Maximum = max;
            m.Minimum = min;
            m.DecimalPlaces = decimalPlaces;
            if (_default != null)
                m.Value = (decimal)_default.Value;

            NewRow();

            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        public void AddStringField(string key, string caption, string _default = "")
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            TextBox m = new TextBox();
            m.Text = _default;

            NewRow();

            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        public void AddCustomDialogField(string key, string caption, Action buttonPress)
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            Panel gb = new Panel();

            Button m = new Button();
            m.Click += (ss, ee) => { buttonPress?.Invoke(); };
            //  Label label = new Label();
            gb.Controls.Add(m);
            //  gb.Controls.Add(label);
            m.Text = "...";

            NewRow();

            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(gb, 1, tp.RowCount - 1);

            prms.Add(key, gb);
            prms2.Add(key, [text, gb]);
        }

        public void AddBoolField(string key, string caption, bool? _default = null)
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            CheckBox m = new CheckBox();

            if (_default != null)
                m.Checked = (bool)_default.Value;

            NewRow();

            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        public void AddOptionsField(string key, string caption, string[] options, string _default = null)
        {
            var text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            ComboBox m = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            m.Items.AddRange(options);

            if (_default != null)
                m.SelectedItem = _default;

            NewRow();

            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        private void NewRow()
        {
            tp.RowStyles.Add(new RowStyle(SizeType.Absolute, GapPerRow));
            tp.RowCount++;
        }

        public void AddEnumField<T>(string key, string caption, T _default) where T : System.Enum
        {
            AddOptionsField(key, caption, Enum.GetNames(typeof(T)), Enum.GetName(typeof(T), _default));
        }

        public void AddOptionsField(string key, string caption, string[] options, int? defaultIdx = null)
        {
            var text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            ComboBox m = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            m.Items.AddRange(options);

            if (defaultIdx != null)
                m.SelectedIndex = defaultIdx.Value;

            NewRow();
            tp.Controls.Add(text, 0, tp.RowCount - 1);
            tp.Controls.Add(m, 1, tp.RowCount - 1);

            prms2.Add(key, [text, m]);
            prms.Add(key, m);
        }

        public double GetNumericField(string v)
        {
            return (double)((prms[v] as NumericUpDown).Value);
        }

        public int GetIntegerNumericField(string v)
        {
            return (int)((prms[v] as NumericUpDown).Value);
        }

        public string GetOptionsField(string v)
        {
            return (string)((prms[v] as ComboBox).SelectedItem);
        }

        public T GetEnumField<T>(string v) where T : System.Enum
        {
            return (T)Enum.Parse(typeof(T), (string)((prms[v] as ComboBox).SelectedItem));
        }

        public int GetOptionsFieldIdx(string v)
        {
            return ((prms[v] as ComboBox).SelectedIndex);
        }

        public bool GetBoolField(string v)
        {
            return (prms[v] as CheckBox).Checked;
        }

        public string GetStringField(string v)
        {
            return (prms[v] as TextBox).Text;
        }

        Dictionary<string, Control> prms = new Dictionary<string, Control>();
        Dictionary<string, Control[]> prms2 = new Dictionary<string, Control[]>();

        public IReadOnlyDictionary<string, Control[]> CreatedControls => prms2;
        public IReadOnlyDictionary<string, Control> InputControls => prms;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DialogForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DialogForm";
            this.ResumeLayout(false);

        }

        public void SetWidth(int v)
        {
            Width = v;
            foreach (var item in CreatedControls.Keys)
            {
                CreatedControls[item][0].Width = v / 2;
                CreatedControls[item][1].Left = v / 2;
            }
        }
    }
}
