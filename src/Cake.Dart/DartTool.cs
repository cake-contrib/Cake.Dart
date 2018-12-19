using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.Dart
{
    /// <summary>
    /// Dart tool.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public class DartTool : Tool<DartSettings>
    {
        readonly ICakeEnvironment environment;
        readonly IFileSystem fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="DartTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        public DartTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            this.fileSystem = fileSystem;
            this.environment = environment;
        }

        /// <summary>
        /// Runs given <paramref name="command"/> using given <paramref name="settings"/>.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="additional">Additional arguments.</param>
        public void Run(Dictionary<string, object> vmOptions, FilePath dartScriptFile, DartSettings settings)
        {
            Run(settings, GetArguments(vmOptions, dartScriptFile, settings));
        }
        ProcessArgumentBuilder GetArguments(Dictionary<string, object> vmOptions, FilePath dartScriptFile, DartSettings settings)
        {
            var builder = new ProcessArgumentBuilder();
            builder.AppendAll(environment, vmOptions, dartScriptFile, settings);
            return builder;
        }
        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Dart";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "dart.exe", "dart" };
        }
        /// <summary>
        /// Finds the proper Dart executable path.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>A single path to Dart executable.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(DartSettings settings)
        {
            var path = DartResolver.GetDartPath(fileSystem, environment);
            if (path != null)
            {
                return new FilePath[] { path };
            }
            else
            {
                return new FilePath[0];
            }
        }
    }
}
