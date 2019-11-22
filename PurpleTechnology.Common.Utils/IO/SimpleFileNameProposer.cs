using System;
using System.Collections.Generic;
using System.IO;

namespace PurpleTechnology.Common.Utils.IO
{
    /// <summary>
    /// Generates an unique absolute path or file name based on the input absolute path.
    /// <para>This class is designed for export/copy operation and thread safety.</para>
    /// Use lock applied to inner lock within the class for outer thread safety.
    /// </summary>
    public class SimpleFileNameProposer
    {
        /// <summary>
        /// Thread-safety lock. Use this as a lock for your export/copy operation.
        /// </summary>
        public static Object Lock = new object();

        /// <summary>
        /// An inner lock for unique file name generation operation.
        /// </summary>
        /// <remarks>
        /// Another layer of thread-safety. It reduce danger of the name collision in situation
        /// when the outer lock is not used and another thread is trying to generate an unique file name
        /// in the same path.
        /// </remarks>
        private static object InnerLock { get; } = new object();

        /// <summary>
        /// Returns an unique file name based on the input absolute path.
        /// <para>It adds suffix to file name if the input folder already has the file with the same name.</para>
        /// </summary>
        /// <param name="absolutePath">An valid absolute path to some file.</param>
        /// <param name="getIndex">A suffix function which is added to original file name. The default value: " (n)"</param>
        /// <returns>An unique file name. The suffix is used when necessary.</returns>
        public static string GenerateUniqueFileName(string absolutePath, Func<UInt64, string>? getIndex = null)
        {
            return Path.GetFileName(path: GenerateUniqueAbsolutePath(absolutePath: absolutePath, getIndex: getIndex));
        }

        /// <summary>
        /// Returns an unique absolute path based on the input absolute path.
        /// <para>It adds suffix to file name if the input folder already has the file with the same name.</para>
        /// </summary>
        /// <param name="absolutePath">An valid absolute path to some file.</param>
        /// <param name="getIndex">A suffix function which is added to original file name. The default value: " (n)"</param>
        /// <returns>An unique absolute path. The suffix is used when necessary.</returns>
        public static string GenerateUniqueAbsolutePath(string absolutePath, Func<UInt64, string>? getIndex = null)
        {
            lock (InnerLock)
            {
                // Get file name, extension and destination path
                var fileBase = Path.GetFileNameWithoutExtension(path: absolutePath) ?? String.Empty;
                var ext = Path.GetExtension(path: absolutePath) ?? String.Empty;
                var destinationFolder = Path.GetDirectoryName(path: absolutePath) ?? String.Empty;

                // getIndex suffix
                if (getIndex == null)
                {
                    getIndex = i => $" ({i})";
                }

                // build hash set of file names for performance
                var files = new HashSet<string>(collection: Directory.GetFiles(path: destinationFolder));
                var fullPath = String.Empty;
                for (UInt64 index = 0; index < UInt64.MaxValue; index++)
                {
                    // first try with the original file name, else try incrementally adding an index
                    var name = (index == 0)
                        ? absolutePath
                        : $"{fileBase}{getIndex(arg: index)}{ext}";

                    // check if exists
                    fullPath = Path.Combine(path1: destinationFolder, path2: name);
                    if (!files.Contains(item: fullPath))
                        break;
                }

                return fullPath;
            }
        }

        /// <summary>
        /// Returns an unique absolute path based on the input FilePath.
        /// <para>It adds suffix to file name if the input folder already has the file with the same name.</para>
        /// </summary>
        /// <param name="filePath">An valid FilePath file path to some file.</param>
        /// <param name="getIndex">A suffix function which is added to original file name. The default value: " (n)"</param>
        /// <returns>A new, unique FilePath. The suffix is used when necessary.</returns>
        public static FilePath GenerateUniqueAbsolutePath(FilePath filePath, Func<UInt64, string>? getIndex = null)
        {
            lock (InnerLock)
            {
                var absolutePath = filePath.AbsolutePath;
                return new FilePath(path: GenerateUniqueAbsolutePath(absolutePath: absolutePath, getIndex: getIndex));
            }
        }

        /// <summary>
        /// Returns an unique file name based on the input FilePath.
        /// <para>It adds suffix to file name if the input folder already has the file with the same name.</para>
        /// </summary>
        /// <param name="filePath">An valid FilePath file path to some file.</param>
        /// <param name="getIndex">A suffix function which is added to original file name. The default value: " (n)"</param>
        /// <returns>An unique file name. The suffix is used when necessary.</returns>
        public static string GenerateUniqueFileName(FilePath filePath, Func<UInt64, string>? getIndex = null)
        {
            return GenerateUniqueAbsolutePath(filePath: filePath, getIndex: getIndex).FileName;
        }

    }

}
