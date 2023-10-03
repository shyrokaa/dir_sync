using dir_sync.Logging;
using dir_sync.Synchronization;
using System.Threading;
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

        private Logger dataFlowLogger;


        // threads
        private System.Threading.Timer syncTimer;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            // base winforms init
            InitializeComponent();



            // specialized

            InitializeObjects();
            InitializeTitleBarDrag();
        }


        public void InitializeObjects()
        {
            // logger

            dataFlowLogger = new Logger("log.json");

            richTextBox1.Text = dataFlowLogger.PrintLogs();

            // ICONS
            // Initialize the NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("picture.ico"); // Set the icon to display in the system tray
            notifyIcon.Visible = true;

            // click event
            notifyIcon.Click += NotifyIcon_Click;


        }
        private void InitializeTitleBarDrag()
        {
            // Attach mouse event handlers to the panel.
            panel3.MouseDown += PanelTitleBar_MouseDown;
            panel3.MouseMove += PanelTitleBar_MouseMove;
            panel3.MouseUp += PanelTitleBar_MouseUp;
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
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the source folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    label5.Text = folderDialog.SelectedPath;
                    sourcePath = folderDialog.SelectedPath;
                }
            }
        }

        // Button: File Dialog for the destination
        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the destination folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    label6.Text = folderDialog.SelectedPath;
                    targetPath = folderDialog.SelectedPath;
                }
            }
        }

        // Button: turn on file sync thread
        private async void button3_Click(object sender, EventArgs e)
        {
            // Disable the button while synchronization is in progress

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            button7.Enabled = true;

            // Initialize the CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();

            // Start a background task for periodic synchronization
            await Task.Factory.StartNew(() => StartSyncPeriodically(), cancellationTokenSource.Token);
        }

        // Method to start synchronization periodically
        private void StartSyncPeriodically()
        {
            int intervalInMilliseconds = 1000; // Adjust the interval as needed (e.g., 60000ms = 1 minute)

            syncTimer = new System.Threading.Timer(
                async (_) =>
                {
                    // Create a new synchronizer for each sync operation
                    Synchronizer synchronizer = new Synchronizer(sourcePath, targetPath, "log.json");

                    synchronizer.SyncFolders();

                    // Update the UI with the logs on the UI thread
                    richTextBox1.Invoke(new Action(() =>
                    {
                        richTextBox1.Text = dataFlowLogger.PrintLogs();
                    }));
                },
                null,
                TimeSpan.Zero, // Start immediately
                TimeSpan.FromMilliseconds(intervalInMilliseconds)); // Interval between sync operations
        }


        // Button: stops the thread completely, re-enables starting and changing options
        private void button7_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                // Cancel the CancellationTokenSource to signal the thread to stop.
                cancellationTokenSource.Cancel();

                // Optionally, you can wait for the thread to complete if needed.
                // For example, you can use Task.Wait:
                // synchronizationTask.Wait();

                // Re-enable the buttons on the UI thread.
                button7.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button7.Enabled = false; // Disable the "Stop" button
                }));
            }
        }



        // Method to stop the synchronization thread
        private void StopSync()
        {
            if (syncTimer != null)
            {
                syncTimer.Change(Timeout.Infinite, Timeout.Infinite);
                syncTimer.Dispose();
            }
            cancellationTokenSource?.Cancel();

            // Re-enable the button when synchronization is stopped
            button3.Invoke(new Action(() =>
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

            }));
        }


    }
}

