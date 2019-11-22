using System;
using System.IO;

namespace PurpleTechnology.Common.Utils.IO
{
    /// <summary>
    /// Creates an immutable object which represents a file path.
    /// <para>This is an implementation of the Facade pattern.</para>
    /// </summary>
    public class FilePath
    {
        /// <summary>
        /// Gets a file name. This includes absolute path and extension.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets a file extension.
        /// </summary>
        public string FileExtension { get; }

        /// <summary>
        /// Gets an absolute path to a file.
        /// </summary>
        public string AbsolutePath { get; }

        /// <summary>
        /// Initializes a new instance of FilePath class.
        /// </summary>
        /// <param name="path">A path to a file.</param>
        public FilePath(string path)
        {
            // Get file name, extension and destination path
            FileName = Path.GetFileName(path: path) ?? String.Empty;
            FileExtension = Path.GetExtension(path: path) ?? String.Empty;
            AbsolutePath = Path.GetDirectoryName(path: path) ?? String.Empty;
        }

        public static explicit operator FilePath(string s)
        {
            return new FilePath(path: s);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj switch
            {
                null => false,
                FilePath temp when ReferenceEquals(objA: this, objB: temp) => true,
                FilePath temp => Equals(left: this, right: temp),
                _ => false
            };
        }


        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">An object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public bool Equals(FilePath other)
        {
            return other switch
            {
                null => false,
                FilePath temp when ReferenceEquals(objA: this, objB: temp) => true,
                _ => Equals(left: this, right: other)
            };
        }

        /// <summary>
        /// Determines whether the specified FilePath objects are equal.
        /// </summary>
        /// <param name="left">A left hand side operand for equality comparision.</param>
        /// <param name="right">A right hand side operand for equality comparision.</param>
        /// <returns>A true if the FilePath objects represent a same FilePath, false otherwise.</returns>
        public static bool Equals(FilePath left, FilePath right)
        {
            return Equals(objA: $"{left?.AbsolutePath}{left?.FileName}", objB: $"{right?.AbsolutePath}{right?.FileName}");
        }

        /// <summary>
        /// Determines whether the specified FilePath objects are equal.
        /// </summary>
        /// <param name="left">A left hand side operand for equality comparision.</param>
        /// <param name="right">A right hand side operand for equality comparision.</param>
        /// <returns>A true if the FilePath objects represent a same FilePath, false otherwise.</returns>
        public static bool operator ==(FilePath left, FilePath right)
        {
            return Equals(left: left, right: right);
        }

        /// <summary>
        /// Determines whether the specified FilePath objects are not equal.
        /// </summary>
        /// <param name="left">A left hand side operand for inequality comparision.</param>
        /// <param name="right">A right hand side operand for inequality comparision.</param>
        /// <returns>A true if the FilePath objects represent a same FilePath, false otherwise.</returns>
        public static bool operator !=(FilePath left, FilePath right)
        {
            return !Equals(left: left, right: right);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return $"{AbsolutePath}{FileName}".GetHashCode(); // TODO: Maybe a valid platform agnostic path => GetHashCode()
        }
    }
}