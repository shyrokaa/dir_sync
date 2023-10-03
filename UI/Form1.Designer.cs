namespace dir_sync
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            button3 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            button6 = new Button();
            label1 = new Label();
            button5 = new Button();
            button4 = new Button();
            panel5 = new Panel();
            textBox1 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(192, 192, 255);
            button1.Location = new Point(24, 7);
            button1.Margin = new Padding(24, 3, 3, 3);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 4;
            button1.Text = "Source";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(192, 192, 255);
            button2.Location = new Point(270, 7);
            button2.Margin = new Padding(3, 3, 24, 3);
            button2.Name = "button2";
            button2.Size = new Size(100, 40);
            button2.TabIndex = 5;
            button2.Text = "Destination";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(label7);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(288, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 240);
            panel1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.FromArgb(192, 192, 255);
            label7.Location = new Point(123, 84);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 9;
            label7.Text = "Used hash";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Black;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(123, 102);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 23);
            comboBox1.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(273, 54);
            label6.Name = "label6";
            label6.Size = new Size(12, 15);
            label6.TabIndex = 7;
            label6.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 54);
            label5.Name = "label5";
            label5.Size = new Size(12, 15);
            label5.TabIndex = 6;
            label5.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(192, 192, 255);
            label3.Location = new Point(273, 18);
            label3.Name = "label3";
            label3.Size = new Size(104, 23);
            label3.TabIndex = 5;
            label3.Text = "Destination";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(192, 192, 255);
            label2.Location = new Point(27, 18);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 4;
            label2.Text = "Source";
            // 
            // panel4
            // 
            panel4.Controls.Add(button3);
            panel4.Location = new Point(3, 187);
            panel4.Name = "panel4";
            panel4.Size = new Size(394, 50);
            panel4.TabIndex = 3;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.FromArgb(192, 192, 255);
            button3.Location = new Point(24, 7);
            button3.Name = "button3";
            button3.Size = new Size(346, 40);
            button3.TabIndex = 6;
            button3.Text = "Start";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 50);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button4);
            panel3.Location = new Point(12, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 40);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(203, 181, 221);
            panel6.Location = new Point(81, 18);
            panel6.Margin = new Padding(3, 18, 3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(421, 4);
            panel6.TabIndex = 5;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.FromArgb(192, 192, 255);
            button6.Location = new Point(564, 8);
            button6.Margin = new Padding(3, 8, 3, 3);
            button6.Name = "button6";
            button6.Size = new Size(50, 24);
            button6.TabIndex = 2;
            button6.Text = ">";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(76, 24);
            label1.TabIndex = 4;
            label1.Text = "DirSync";
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.FromArgb(192, 192, 255);
            button5.Location = new Point(508, 8);
            button5.Margin = new Padding(3, 8, 3, 3);
            button5.Name = "button5";
            button5.Size = new Size(50, 24);
            button5.TabIndex = 1;
            button5.Text = "_";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.FromArgb(192, 192, 255);
            button4.Location = new Point(620, 8);
            button4.Margin = new Padding(3, 8, 3, 3);
            button4.Name = "button4";
            button4.Size = new Size(50, 24);
            button4.TabIndex = 3;
            button4.Text = "x";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(textBox1);
            panel5.ForeColor = SystemColors.ControlText;
            panel5.Location = new Point(12, 48);
            panel5.Name = "panel5";
            panel5.Size = new Size(270, 240);
            panel5.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(3, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 234);
            textBox1.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(315, 291);
            label4.Name = "label4";
            label4.Size = new Size(56, 18);
            label4.TabIndex = 5;
            label4.Text = "version";
            label4.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(700, 310);
            Controls.Add(label4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button button3;
        private Button button5;
        private Button button4;
        private Panel panel5;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button button6;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboBox1;
        private Panel panel6;
    }
}