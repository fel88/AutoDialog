namespace AutoDialog.Tester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            options1ToolStripMenuItem = new ToolStripMenuItem();
            options2ToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            test1ToolStripMenuItem = new ToolStripMenuItem();
            test2ToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton2 = new ToolStripButton();
            toolStripDropDownButton3 = new ToolStripDropDownButton();
            test1ToolStripMenuItem1 = new ToolStripMenuItem();
            test2ToolStripMenuItem1 = new ToolStripMenuItem();
            enumToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripDropDownButton1, toolStripButton3, toolStripButton4, toolStripDropDownButton2, toolStripButton2, toolStripDropDownButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(700, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(46, 22);
            toolStripButton1.Text = "simple";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { options1ToolStripMenuItem, options2ToolStripMenuItem, enumToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(60, 22);
            toolStripDropDownButton1.Text = "options";
            // 
            // options1ToolStripMenuItem
            // 
            options1ToolStripMenuItem.Name = "options1ToolStripMenuItem";
            options1ToolStripMenuItem.Size = new Size(180, 22);
            options1ToolStripMenuItem.Text = "options 1";
            options1ToolStripMenuItem.Click += options1ToolStripMenuItem_Click;
            // 
            // options2ToolStripMenuItem
            // 
            options2ToolStripMenuItem.Name = "options2ToolStripMenuItem";
            options2ToolStripMenuItem.Size = new Size(180, 22);
            options2ToolStripMenuItem.Text = "options 2";
            options2ToolStripMenuItem.Click += options2ToolStripMenuItem_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(48, 22);
            toolStripButton3.Text = "integer";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(41, 22);
            toolStripButton4.Text = "string";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { test1ToolStripMenuItem, test2ToolStripMenuItem });
            toolStripDropDownButton2.Image = (Image)resources.GetObject("toolStripDropDownButton2.Image");
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(72, 22);
            toolStripDropDownButton2.Text = "validation";
            // 
            // test1ToolStripMenuItem
            // 
            test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            test1ToolStripMenuItem.Size = new Size(102, 22);
            test1ToolStripMenuItem.Text = "test 1";
            test1ToolStripMenuItem.Click += test1ToolStripMenuItem_Click;
            // 
            // test2ToolStripMenuItem
            // 
            test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            test2ToolStripMenuItem.Size = new Size(102, 22);
            test2ToolStripMenuItem.Text = "test 2";
            test2ToolStripMenuItem.Click += test2ToolStripMenuItem_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(51, 22);
            toolStripButton2.Text = "custom";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripDropDownButton3
            // 
            toolStripDropDownButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton3.DropDownItems.AddRange(new ToolStripItem[] { test1ToolStripMenuItem1, test2ToolStripMenuItem1 });
            toolStripDropDownButton3.Image = (Image)resources.GetObject("toolStripDropDownButton3.Image");
            toolStripDropDownButton3.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            toolStripDropDownButton3.Size = new Size(82, 22);
            toolStripDropDownButton3.Text = "from object";
            // 
            // test1ToolStripMenuItem1
            // 
            test1ToolStripMenuItem1.Name = "test1ToolStripMenuItem1";
            test1ToolStripMenuItem1.Size = new Size(102, 22);
            test1ToolStripMenuItem1.Text = "test 1";
            test1ToolStripMenuItem1.Click += test1ToolStripMenuItem1_Click;
            // 
            // test2ToolStripMenuItem1
            // 
            test2ToolStripMenuItem1.Name = "test2ToolStripMenuItem1";
            test2ToolStripMenuItem1.Size = new Size(102, 22);
            test2ToolStripMenuItem1.Text = "test 2";
            test2ToolStripMenuItem1.Click += test2ToolStripMenuItem1_Click;
            // 
            // enumToolStripMenuItem
            // 
            enumToolStripMenuItem.Name = "enumToolStripMenuItem";
            enumToolStripMenuItem.Size = new Size(180, 22);
            enumToolStripMenuItem.Text = "enum";
            enumToolStripMenuItem.Click += enumToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(toolStrip1);
            IsMdiContainer = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AutoDialog.Tester";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem options1ToolStripMenuItem;
        private ToolStripMenuItem options2ToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem test1ToolStripMenuItem;
        private ToolStripMenuItem test2ToolStripMenuItem;
        private ToolStripButton toolStripButton2;
        private ToolStripDropDownButton toolStripDropDownButton3;
        private ToolStripMenuItem test1ToolStripMenuItem1;
        private ToolStripMenuItem test2ToolStripMenuItem1;
        private ToolStripMenuItem enumToolStripMenuItem;
    }
}