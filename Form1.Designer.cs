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
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            panel4 = new Panel();
            button3 = new Button();
            panel2 = new Panel();
            splitter2 = new Splitter();
            splitter1 = new Splitter();
            panel3 = new Panel();
            button5 = new Button();
            button4 = new Button();
            panel5 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(30, 7);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(264, 7);
            button2.Name = "button2";
            button2.Size = new Size(100, 40);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(285, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 240);
            panel1.TabIndex = 2;
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
            button3.Location = new Point(145, 7);
            button3.Name = "button3";
            button3.Size = new Size(100, 40);
            button3.TabIndex = 4;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(splitter2);
            panel2.Controls.Add(splitter1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(3, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 50);
            panel2.TabIndex = 2;
            // 
            // splitter2
            // 
            splitter2.Dock = DockStyle.Right;
            splitter2.Location = new Point(370, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(24, 50);
            splitter2.TabIndex = 3;
            splitter2.TabStop = false;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(24, 50);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button4);
            panel3.Location = new Point(12, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 30);
            panel3.TabIndex = 3;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(618, 2);
            button5.Name = "button5";
            button5.Size = new Size(25, 25);
            button5.TabIndex = 6;
            button5.Text = "_";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(648, 2);
            button4.Name = "button4";
            button4.Size = new Size(25, 25);
            button4.TabIndex = 5;
            button4.Text = "x";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDark;
            panel5.Controls.Add(textBox1);
            panel5.Location = new Point(12, 48);
            panel5.Name = "panel5";
            panel5.Size = new Size(270, 240);
            panel5.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InfoText;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(3, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 234);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(57, 18);
            label1.TabIndex = 4;
            label1.Text = "DirSync";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 15);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 100);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(700, 300);
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
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Splitter splitter2;
        private Splitter splitter1;
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
    }
}