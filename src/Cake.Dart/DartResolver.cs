using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.Dart
{
    /// <summary>
    /// Dart tool resolver.
    /// </summary>
    public class DartResolver
    {
        /// <summary>
        /// Returns the path of the Dart.exe.
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="environment"></param>
        /// <returns>The path of the latest Dart.exe</returns>
        /// <remarks>Throws if Dart isn't found.</remarks>
        public static FilePath GetDartPath(IFileSystem fileSystem, ICakeEnvironment environment)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }
            var exe = new DirectoryPath(Environment.GetEnvironmentVariable("ProgramFiles"))
                .Combine("Dart")
                .Combine("dart-sdk")
                .CombineWithFilePath("dart.exe");
            return exe;
        }
    }
}
