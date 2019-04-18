using Cake.Core;
using Cake.Core.Configuration;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Cake.Dart.Tests
{
    public class DartFixture : ToolFixture<DartSettings>, ICakeContext
    {
        public const string Root = "C:/Temp";
        public string Path { get; set; }
        IFileSystem fileSystem;
        ICakeEnvironment environment;
        IFileSystem ICakeContext.FileSystem => fileSystem;
        ICakeEnvironment ICakeContext.Environment => environment;
        public ICakeLog Log => Log;
        ICakeArguments ICakeContext.Arguments => throw new NotImplementedException();
        IProcessRunner ICakeContext.ProcessRunner => ProcessRunner;
        public IRegistry Registry => Registry;
        public ICakeDataResolver Data => throw new NotImplementedException();
        public FilePath ScriptFile { get; set; }
        public Dictionary<string, object> VmOptions { get; set; }
        ICakeConfiguration ICakeContext.Configuration => throw new NotImplementedException();
        public DartFixture(): base("dart")
        {
            Tools = Substitute.For<IToolLocator>();
            fileSystem = Substitute.For<IFileSystem>();
            environment = Substitute.For<ICakeEnvironment>();
            var toolPath = new FilePath("dart");
            var file = Substitute.For<IFile>();
            file.Exists.Returns(true);
            fileSystem.GetFile(toolPath).Returns(file);
            environment.WorkingDirectory.Returns(Root);
            Tools.Resolve("dart").Returns(toolPath);
            ProcessRunner.Process.SetStandardOutput(new string[] { });
        }
        protected override void RunTool()
        {
            this.DartScript(VmOptions, ScriptFile, Settings);
        }
    }
}
