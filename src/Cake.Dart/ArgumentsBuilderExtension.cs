using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;

namespace Cake.Dart
{
    /// <summary>
    /// Arguments builder
    /// </summary>
    public static class ArgumentsBuilderExtension
    {
        internal static void AppendAll(this ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, 
            Dictionary<string, object> vmOptions, FilePath dartScriptFile, DartSettings settings)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (dartScriptFile == null)
            {
                throw new ArgumentNullException(nameof(dartScriptFile));
            }
            if (vmOptions != null)
            {
                AppendVmOptionsArguments(builder, cakeEnvironment, vmOptions);
            }
            builder.Append(dartScriptFile.MakeAbsolute(cakeEnvironment).FullPath);
            if (settings != null)
            {
                AppendSettingsArguments(builder, cakeEnvironment, settings);
            }
        }
        static void AppendVmOptionsArguments(ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, Dictionary<string, object> options)
        {
            foreach (var pair in options)
            {
                if (!ReferenceEquals(pair.Value, null) && !string.IsNullOrWhiteSpace(pair.Key))
                {
                    string valueText;
                    switch (pair.Value)
                    {
                        case bool boolValue:
                            valueText = boolValue.ToString().ToLower();
                            break;
                        case string stringValue:
                            valueText = $"'{stringValue}'";
                            break;
                        default:
                            valueText = Convert.ToString(pair.Value);
                            break;
                    }
                    builder.Append($"--{pair.Key}={valueText}");
                }
            }
        }
        static void AppendSettingsArguments(ProcessArgumentBuilder builder, ICakeEnvironment cakeEnvironment, DartSettings settings)
        {
            if (settings.EnableAsserts)
            {
                builder.Append("--enable-asserts");
            }
            if (settings.PackageRoot != null)
            {
                builder.Append($"--package-root='{settings.PackageRoot.MakeAbsolute(cakeEnvironment).FullPath}'");
            }
            if (settings.Packages != null)
            {
                builder.Append($"--packages='{settings.Packages.MakeAbsolute(cakeEnvironment).FullPath}'");
            }
            if (settings.OldGenHeapSize.HasValue)
            {
                builder.Append($"--old_gen_heap_size={settings.OldGenHeapSize}");
            }
            var enableVmServiceSettings = settings.EnableVmService;
            if (enableVmServiceSettings?.IsEnabled ?? false)
            {
                builder.Append($"--enable-vm-service{FromObservatorySettings(enableVmServiceSettings)}");
            }
            if (settings.PauseIsolatesOnExit)
            {
                builder.Append("--pause-isolates-on-exit");
            }
            if (settings.PauseIsolatesOnStart)
            {
                builder.Append("--pause-isolates-on-start");
            }
            var observeSettings = settings.Observe;
            if (observeSettings?.IsEnabled ?? false)
            {
                builder.Append($"--observe{FromObservatorySettings(enableVmServiceSettings)}");
            }
            if (settings.Profile)
            {
                builder.Append("--profile");
            }
            if (settings.Snapshot != null)
            {
                builder.Append($"--snapshot='{settings.Snapshot.MakeAbsolute(cakeEnvironment).FullPath}'");
            }
            if (settings.SnapshotKind.HasValue)
            {
                builder.Append($"--snapshot-kind={(settings.SnapshotKind == SnapshotKind.Kernel ? "kernel": "app-jit")}");
            }
            if (settings.RootCertsFile != null)
            {
                builder.Append($"--root-certs-file='{settings.RootCertsFile.MakeAbsolute(cakeEnvironment).FullPath}'");
            }
            if (settings.RootCertsCache != null)
            {
                builder.Append($"--root-certs-cache='{settings.RootCertsFile.MakeAbsolute(cakeEnvironment).FullPath}'");
            }
        }
        internal static string FromObservatorySettings(ObservatorySettings settings)
        {
            if (!settings.Port.HasValue)
            {
                return null;
            }
            string result = $"={settings.Port}";
            if (string.IsNullOrWhiteSpace(settings.BindAddress))
            {
                return result;
            }
            else
            {
                return $"{result}/{settings.BindAddress}";
            }
        }
    }
}
