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
        private string selectedHash;
        private Logger dataFlowLogger;


        // threads
        private Task synchronizationTask;
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

        // Button: turn on file sync
        private void button3_Click(object sender, EventArgs e)
        {
            // Check if sourcePath or targetPath is null or empty
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(targetPath))
            {
                MessageBox.Show("Source or target path is missing.");
                return;
            }

            selectedHash = comboBox1.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedHash))
            {
                // Handle the case where no item is selected.
                MessageBox.Show("No hash selected.");
                return;
            }

            // Disable the button while synchronization is in progress
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button7.Enabled = true;

            // Call the synchronization method directly without starting a background task
            StartSyncPeriodically();
        }

        // Method to start synchronization periodically
        private void StartSyncPeriodically()
        {
            int intervalInMilliseconds = 1000; // Adjust the interval as needed (e.g., 60000ms = 1 minute)

            cancellationTokenSource = new CancellationTokenSource();

            synchronizationTask = Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Create a new synchronizer for each sync operation
                    Synchronizer synchronizer = new Synchronizer(sourcePath, targetPath, "log.json");

                    synchronizer.SyncFolders(selectedHash);

                    // Update the UI with the logs on the UI thread
                    richTextBox1.Invoke(new Action(() =>
                    {
                        richTextBox1.Text = dataFlowLogger.PrintLogs();
                    }));

                    await Task.Delay(intervalInMilliseconds);
                }
            }, cancellationTokenSource.Token);
        }

        // Button: stops the thread completely, re-enables starting and changing options
        private async void button7_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                // Cancel the CancellationTokenSource to signal the thread to stop.
                cancellationTokenSource.Cancel();

                // Optionally, you can wait for the task to complete if needed.
                if (synchronizationTask != null)
                {
                    await synchronizationTask;
                }

                // Re-enable the buttons on the UI thread.
                this.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button7.Enabled = false; // Disable the "Stop" button
                }));
            }
        }

        // Button : clears up the log file
        private void button8_Click(object sender, EventArgs e)
        {
            dataFlowLogger.WipeLogs();
            richTextBox1.Text = dataFlowLogger.PrintLogs();
        }
    }
}

