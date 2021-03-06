using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NSubstitute;

namespace Cake.Dart.Tests
{
    public class DartFixture : ToolFixture<DartSettings>, ICakeContext
    {
        public const string Root = "C:/Temp";
        public string[] Services { get; set; } = new string[0];
        IFileSystem ICakeContext.FileSystem => FileSystem;
        ICakeEnvironment environment;
        ICakeEnvironment ICakeContext.Environment => environment;
        public ICakeLog Log => Log;
        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();
        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;
        public IRegistry Registry => Registry;
        public ICakeDataResolver Data => throw new NotImplementedException();
        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();
        public FilePath ScriptFile { get; set; }
        public Dictionary<string, object> VmOptions { get; set; }
        public DartFixture(): base("dart")
        {
            environment = Substitute.For<ICakeEnvironment>();
            environment.WorkingDirectory.Returns(Root);
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DartScript(VmOptions, ScriptFile, Settings);
        }
    }
}
