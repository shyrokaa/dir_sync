using dir_sync.Logging;
using System;
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

        public void SyncFolders()
        {
            // Get a list of files in the source folder.
            string[] sourceFiles = Directory.GetFiles(sourceFolderPath);

            // Get a list of directories in the source folder.
            string[] sourceDirectories = Directory.GetDirectories(sourceFolderPath);

            // Get a list of directories in the destination folder.
            string[] destinationDirectories = Directory.GetDirectories(destinationFolderPath);

            // Create a HashSet to store the names of directories in the source folder.
            HashSet<string> sourceDirectoryNames = new HashSet<string>(
                sourceDirectories.Select(directory => Path.GetFileName(directory)),
                StringComparer.OrdinalIgnoreCase // Use case-insensitive comparison
            );

            foreach (string sourceFilePath in sourceFiles)
            {
                try
                {
                    // Create the destination path by combining the destination folder path
                    // and the file name from the source path.
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                    // Encrypt the source file before copying it to the destination.
                    // You can call your encryption method here.
                    byte[] encryptedData = EncryptFile(sourceFilePath);

                    // Write the encrypted data to the destination file.
                    File.WriteAllBytes(destinationFilePath, encryptedData);

                    // Log the successful file transfer operation.
                    LogFileOperation(sourceFilePath, destinationFilePath, "completed");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the synchronization process.
                    // Log errors using the logger.
                    LogFileOperation(sourceFilePath, "", "failed"); // Log failure status
                    Console.WriteLine($"Error synchronizing file: {ex.Message}");
                }
            }

            // Delete surplus directories in the destination folder.
            foreach (string destinationDirectory in destinationDirectories)
            {
                string directoryName = Path.GetFileName(destinationDirectory);

                if (!sourceDirectoryNames.Contains(directoryName))
                {
                    // Directory in the destination folder does not exist in the source.
                    // You can add code here to delete the surplus directory.
                    Directory.Delete(destinationDirectory, true); // Use 'true' to delete recursively.
                }
            }
        }


        // Placeholder methods for encryption and decryption (implement these in a separate class).
        private byte[] EncryptFile(string sourceFilePath)
        {
            // Implement encryption logic here.
            // Return the encrypted data as a byte array.
            // You should use a real encryption method or library here.
            byte[] sourceData = File.ReadAllBytes(sourceFilePath);
            // Replace this with your actual encryption logic.
            byte[] encryptedData = sourceData; // Placeholder, replace with actual encryption.

            return encryptedData;
        }

        // Placeholder methods for encryption and decryption (implement these in a separate class).
        private byte[] DecryptFile(byte[] encryptedData)
        {
            // Implement decryption logic here.
            // Return the decrypted data as a byte array.
            // You should use a real decryption method or library here.
            // Replace this with your actual decryption logic.
            byte[] decryptedData = encryptedData; // Placeholder, replace with actual decryption.

            return decryptedData;
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
