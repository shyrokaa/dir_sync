namespace dir_sync
{
    public partial class Form1 : Form
    {

        private bool isDragging = false;
        private Point startPoint = Point.Empty;


        public Form1()
        {
            InitializeComponent();
            InitializeTitleBarDrag();
        }

        private void InitializeTitleBarDrag()
        {
            // Attach mouse event handlers to the panel.
            panel3.MouseDown += PanelTitleBar_MouseDown;
            panel3.MouseMove += PanelTitleBar_MouseMove;
            panel3.MouseUp += PanelTitleBar_MouseUp;
        }

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void PanelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = PointToScreen(new Point(e.X, e.Y));
                Location = new Point(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            }
        }

        private void PanelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        // Button handlers

        // Button: Close 
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Button: Taskbar Minimize
        private void button5_Click(object sender, EventArgs e)
        {

        }

        // Button: Run in the background
        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}