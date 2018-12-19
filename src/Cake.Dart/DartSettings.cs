using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Dart
{
    /// <summary>
    /// Dart settings.
    /// </summary>
    public class DartSettings : ToolSettings
    {
        /// <summary>
        /// Enable assert statements.
        /// </summary>
        public bool EnableAsserts { get; set; }
        /// <summary>
        ///  Where to find packages, that is, "package:..." imports.
        /// </summary>
        public FilePath PackageRoot { get; set; }
        /// <summary>
        ///  Where to find a package spec file.
        /// </summary>
        public FilePath Packages { get; set; }
        /// <summary>
        /// Sets the upper limit of old space to num MB.
        /// </summary>
        public int? OldGenHeapSize { get; set; }

        /// <summary>
        /// Enables Observatory on localhost port 8181.
        /// </summary>
        public ObservatorySettings EnableVmService { get; set; }
        /// <summary>
        /// Causes the VM to pause each isolate that would otherwise exit. If your standalone app executes quickly, it might exit before you can open Observatory. 
        /// To avoid this situation, specify this flag on startup. You must explicitly release all isolates in the Observatory debugger.
        /// </summary>
        public bool PauseIsolatesOnExit { get; set; }
        /// <summary>
        /// Causes the VM to pause before starting any isolate. You must explicitly start each isolate in the Observatory debugger.
        /// </summary>
        public bool PauseIsolatesOnStart { get; set; }
        /// <summary>
        /// A shortcut that combines <see cref="EnableVmService"/> and <see cref="PauseIsolatesOnExit"/>.
        /// </summary>
        public ObservatorySettings Observe { get; set; }
        /// <summary>
        /// On Windows, Observatory’s CPU Profiler screen is disabled by default. Use this option to enable it.
        /// </summary>
        public bool Profile { get; set; }

        /// <summary>
        /// Generates a snapshot in the specified file. For information on generating and running snapshots, see Snapshots on GitHub.
        /// </summary>
        public FilePath Snapshot { get; set; }
        /// <summary>
        /// snapshot-kind controls the kind of snapshot.
        /// </summary>
        public SnapshotKind? SnapshotKind { get; set; }
        /// <summary>
        /// Enables tracing of library and script loading.
        /// </summary>
        public bool TraceLoading { get; set; }
        /// <summary>
        /// The path to a file containing the trusted root certificates to use for secure socket connections.
        /// </summary>
        public FilePath RootCertsFile { get; set; }
        /// <summary>
        /// The path to a cache directory containing the trusted root certificates to use for secure socket connections.
        /// </summary>
        public FilePath RootCertsCache { get; set; }
    }
}
