using System.Windows.Forms;

namespace dir_sync
{
    public partial class Form1 : Form
    {
        // functionality
        private bool isDragging = false;
        private Point startPoint = Point.Empty;
        private NotifyIcon notifyIcon;

        // data
        private string sourcePath;
        private string targetPath;

        public Form1()
        {
            InitializeComponent();
            InitializeTitleBarDrag();
            InitializeTematic();
            LoadIcon();
        }

        //icon loader
        private void LoadIcon()
        {
            // Initialize the NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("picture.ico"); // Set the icon to display in the system tray
            notifyIcon.Visible = true;


            // click event
            notifyIcon.Click += NotifyIcon_Click;
        }


        // thematic setup on the initial run
        private void InitializeTematic()
        {
            // margins, colors and what not 



        }


        // event handlers
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // Toggle the form's visibility and state when the NotifyIcon is clicked
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
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

        // Handle other form events and logic...

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Clean up the NotifyIcon when the form is closing
            notifyIcon.Visible = false;
            base.OnFormClosing(e);
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
            this.WindowState = FormWindowState.Minimized;
        }

        // Button: Run in the background
        private void button6_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;

            // Hide the taskbar icon
            this.ShowInTaskbar = false;
        }

        // Button: File Dialog for the source
        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Button: File Dialog for the destination
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Button: turn on file sync thread
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}