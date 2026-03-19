using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace System.Net.Http { }

namespace AutoDialog
{
    public class DialogForm : Form
    {
        public DialogForm()
        {
            InitializeComponent();

            Shown += DialogForm_Shown;
            FormClosing += DialogForm_FormClosing;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button button1;


        public Button ApplyButton => button1;

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


            InitAsSinglePage();
        }

        private void InitAsSinglePage()
        {
            Width = (1 + columnIdx) * ColumnStep;
            
            foreach (var item in CreatedControls.OfType<Control>())
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

        [Obsolete("use AddInt instead")]
        public void AddIntegerNumericField(string key, string caption, double? _default = null, decimal max = 1000, decimal min = 0)
        {
            AddInt(key, caption, _default, min, max);
        }

        public void AddInt(string key, string caption, double? _default = null, decimal min = 0, decimal max = 1000)
        {
            AddNumericField(key, caption, _default, max, min, 0);
        }

        public void AddDouble(string key, string caption, double? _default = null, decimal min = 0, decimal max = 1000, int decimalPlaces = 2)
        {
            Label text = new Label() { Text = caption };

            NumericUpDown m = new NumericUpDown();
            m.Maximum = max;
            m.Minimum = min;
            m.DecimalPlaces = decimalPlaces;
            if (_default != null)
                m.Value = (decimal)_default.Value;


            Locate(text);
            Locate(m, true);
            NewRow();

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        [Obsolete("Use AddDouble")]
        public void AddNumericField(string key, string caption, double? _default = null, decimal max = 1000, decimal min = 0, int decimalPlaces = 2)
        {
            AddDouble(key, caption, _default, min, max, decimalPlaces);
        }

        public void AddStringField(string key, string caption, string _default = "")
        {
            Label text = new Label() { Text = caption };
            var tp = Controls[0] as TableLayoutPanel;

            TextBox m = new TextBox();
            m.Text = _default;

            Locate(text);
            Locate(m, true);
            NewRow();

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        public void AddCustomDialogField(string key, string caption, Action buttonPress)
        {
            Label text = new Label() { Text = caption };




            Button m = new Button();
            m.Click += (ss, ee) => { buttonPress?.Invoke(); };
            //  Label label = new Label();

            //  gb.Controls.Add(label);
            m.Text = "...";

            Locate(text);
            Locate(m, true);
            NewRow();

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        public void AddBoolField(string key, string caption, bool? _default = null)
        {
            Label text = new Label() { Text = caption };

            CheckBox m = new CheckBox();

            if (_default != null)
                m.Checked = (bool)_default.Value;

            Locate(text);
            Locate(m, true);
            NewRow();


            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }


        public void AddOptionsField(string key, string caption, string[] options, string _default = null)
        {
            var text = new Label() { Text = caption };

            ComboBox m = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            m.Items.AddRange(options);

            if (_default != null)
                m.SelectedItem = _default;


            Locate(text);
            Locate(m, true);
            NewRow();

            prms.Add(key, m);
            prms2.Add(key, [text, m]);
        }

        int rowIdx = 0;
        int columnIdx = 0;
        public int? MaxRowsAllowed = 20;

        public void NewRow()
        {
            rowIdx++;
            var targetHeight = button1.Height + StaticGap + rowIdx * RowStep;
            if (MaxRowsAllowed != null && rowIdx > MaxRowsAllowed)
                NewColumn();

            if (Height < targetHeight)            
                Height = targetHeight;            
        }

        public void NewColumn()
        {
            rowIdx = 0;
            columnIdx++;
        }

        public void AddEnumField<T>(string key, string caption, T _default) where T : System.Enum
        {
            AddOptionsField(key, caption, Enum.GetNames(typeof(T)), Enum.GetName(typeof(T), _default));
        }

        public int RowStep = 30;
        public int CellStep = 150;
        public int ColumnStep = 300;

        public void AddOptionsField(string key, string caption, string[] options, int? defaultIdx = null)
        {
            var text = new Label() { Text = caption };            

            ComboBox m = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList };
            m.Items.AddRange(options);

            if (defaultIdx != null)
                m.SelectedIndex = defaultIdx.Value;


            Locate(text);
            Locate(m, true);

            NewRow();

            prms2.Add(key, [text, m]);
            prms.Add(key, m);
        }

        private void Locate(Control control, bool rightPlace = false)
        {
            panel1.Controls.Add(control);
            control.Left = columnIdx * ColumnStep + (rightPlace ? CellStep : 0);
            control.Top = rowIdx * RowStep;
        }

        public double GetDouble(string v)
        {
            return (double)((prms[v] as NumericUpDown).Value);
        }

        [Obsolete("Use GetDouble")]
        public double GetNumericField(string v)
        {
            return GetDouble(v);
        }

        public int GetInt(string v)
        {
            return (int)((prms[v] as NumericUpDown).Value);
        }

        [Obsolete("Use GetInt")]
        public int GetIntegerNumericField(string v)
        {
            return GetInt(v);
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 17);
            this.panel1.TabIndex = 1;
            // 
            // DialogForm
            // 
            this.ClientSize = new System.Drawing.Size(224, 42);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogForm";
            this.tableLayoutPanel1.ResumeLayout(false);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
