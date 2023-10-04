using dir_sync.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dir_sync.Synchronization
{
    internal class Synchronizer
    {
        private string sourceFolderPath;
        private string destinationFolderPath;
        private Logger logger;

        /// <summary>
        /// Synchronizer object construction that requires source and destination paths.
        /// </summary>
        /// <param name="sourcePath">The path of the source folder.</param>
        /// <param name="destinationPath">The path of the destination folder.</param>
        public Synchronizer(string sourcePath, string destinationPath, string logFilePath)
        {
            this.sourceFolderPath = sourcePath;
            this.destinationFolderPath = destinationPath;
            this.logger = new Logger(logFilePath);
        }

        // Function that does the synchronization based on the provided paths and the chosen hash algorithm.
        public void SyncFolders(string chosenHash)
        {
            if (string.IsNullOrEmpty(sourceFolderPath) || string.IsNullOrEmpty(destinationFolderPath))
            {
                MessageBox.Show("Source or target folder path is missing.");
                return;
            }

            if (!Directory.Exists(sourceFolderPath) || !Directory.Exists(destinationFolderPath))
            {
                MessageBox.Show("Source or target folder does not exist.");
                return;
            }

            HasherBase hasher;

            // Determine which hash algorithm to use based on the chosenHash variable.
            if (string.Equals(chosenHash, "MD5", StringComparison.OrdinalIgnoreCase))
            {
                hasher = new MD5Hash();
            }
            else if (string.Equals(chosenHash, "SHA-256", StringComparison.OrdinalIgnoreCase))
            {
                hasher = new SHA256Hash();
            }
            else
            {
                MessageBox.Show("Invalid hash algorithm specified.");
                return;
            }

            // Sync files and directories
            SyncFilesAndDirectories(sourceFolderPath, destinationFolderPath, hasher);
        }


        // Helper method to sync files and directories recursively.
        private void SyncFilesAndDirectories(string sourcePath, string destinationPath, HasherBase hasher)
        {
            // Get a list of files in the source directory.
            string[] sourceFiles = Directory.GetFiles(sourcePath);

            // Get a list of directories in the source directory.
            string[] sourceDirectories = Directory.GetDirectories(sourcePath);

            // Create a HashSet to store the names of directories in the source directory.
            HashSet<string> sourceDirectoryNames = new HashSet<string>(
                sourceDirectories.Select(directory => Path.GetFileName(directory)),
                StringComparer.OrdinalIgnoreCase // Use case-insensitive comparison
            );

            // Sync files in the source directory.
            foreach (string sourceFilePath in sourceFiles)
            {
                try
                {
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationFilePath = Path.Combine(destinationPath, fileName);

                    // Check if the destination file already exists and has the same content.
                    bool filesAreEqual = FilesHaveSameHash(sourceFilePath, destinationFilePath, hasher);

                    if (!filesAreEqual)
                    {
                        // Ensure the destination directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));

                        // Copy the source file to the destination.
                        File.Copy(sourceFilePath, destinationFilePath, true);

                        // Log the successful file transfer operation.
                        LogFileOperation(sourceFilePath, destinationFilePath, "completed");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the synchronization process.
                    // Log errors using the logger.
                    LogFileOperation(sourceFilePath, "", "failed"); // Log failure status
                    MessageBox.Show($"Error synchronizing file: {ex.Message}");
                }
            }

            // Sync subdirectories in the source directory.
            foreach (string sourceDir in sourceDirectories)
            {
                string dirName = Path.GetFileName(sourceDir);
                string destinationDir = Path.Combine(destinationPath, dirName);

                if (!Directory.Exists(destinationDir))
                {
                    // If the destination directory does not exist, create it.
                    Directory.CreateDirectory(destinationDir);
                }

                // Recursively sync files and subdirectories in the source subdirectory.
                SyncFilesAndDirectories(sourceDir, destinationDir, hasher);
            }

            // Delete surplus files and directories in the destination directory.
            foreach (string destinationFile in Directory.GetFiles(destinationPath))
            {
                string fileName = Path.GetFileName(destinationFile);

                // Check if the destination file does not exist in the source directory.
                if (!sourceFiles.Contains(Path.Combine(sourcePath, fileName)))
                {
                    File.Delete(destinationFile);
                }
            }

            foreach (string destinationDir in Directory.GetDirectories(destinationPath))
            {
                string dirName = Path.GetFileName(destinationDir);

                if (!sourceDirectoryNames.Contains(dirName))
                {
                    Directory.Delete(destinationDir, true);
                }
            }
        }


        // Helper method to compare files based on their hash values.
        private bool FilesHaveSameHash(string filePath1, string filePath2, HasherBase hasher)
        {
            if (!File.Exists(filePath1))
            {
                // Check if the first file exists, if not, return false.
                return false;
            }

            if (!File.Exists(filePath2))
            {
                // Check if the second file exists, if not, return false.
                return false;
            }

            byte[] file1 = File.ReadAllBytes(filePath1);
            byte[] file2 = File.ReadAllBytes(filePath2);

            // Calculate the hash of each file.
            byte[] hash1 = hasher.CalculateHash(file1);
            byte[] hash2 = hasher.CalculateHash(file2);

            // Compare the hash values.
            return StructuralComparisons.StructuralEqualityComparer.Equals(hash1, hash2);
        }

        /// <summary>
        /// Logs a file operation in the JSON log file.
        /// </summary>
        /// <param name="sourcePath">The path of the source file.</param>
        /// <param name="destinationPath">The path of the destination file.</param>
        /// <param name="status">The status of the operation (e.g., "completed").</param>
        public void LogFileOperation(string sourcePath, string destinationPath, string status)
        {
            LogEntry logEntry = new LogEntry
            {
                TimeCreated = DateTime.UtcNow,
                SourcePath = sourcePath,
                DestinationPath = destinationPath,
                FileSizeBytes = new FileInfo(sourcePath).Length,
                Status = status
            };

            logger.UpdateLogs(logEntry);
        }
    }

}
