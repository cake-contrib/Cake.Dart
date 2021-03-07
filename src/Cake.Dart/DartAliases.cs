using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Dart
{
    /// <summary>
    /// Contains functionality for working with Dart commands.
    /// </summary>
    [CakeAliasCategory("Dart")]
    public static partial class DartAliases
    {
        /// <summary>
        /// Runs Dart
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="vmOptions">VM options</param>
        /// <param name="dartScriptFile">File to execute.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DartScript(this ICakeContext context, Dictionary<string, object> vmOptions, FilePath dartScriptFile, DartSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (dartScriptFile == null)
            {
                throw new ArgumentNullException(nameof(dartScriptFile));
            }
            var runner = new DartTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(vmOptions, dartScriptFile, settings);
        }
        /// <summary>
        /// Runs Dart
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dartScriptFile">File to execute.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void DartScript(this ICakeContext context, FilePath dartScriptFile, DartSettings settings) =>
            DartScript(context, vmOptions: null, dartScriptFile, settings);
        /// <summary>
        /// Runs Dart
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dartScriptFile">File to execute.</param>
        [CakeMethodAlias]
        public static void DartScript(this ICakeContext context, FilePath dartScriptFile) =>
            DartScript(context, vmOptions: null, dartScriptFile, settings: null);

    }
}
