using Cake.Core.IO;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cake.Dart.Tests
{
    [TestFixture]
    public class DartTest
    {
        [TestFixture]
        public class Dart: DartTest
        {
            [Test]
            public void WhenScriptFileIsNull_ThrowsArgumentNullException()
            {
                var fixture = new DartFixture
                {
                    Settings = new DartSettings()
                };

                Assert.Throws<ArgumentNullException>(() => fixture.Run());
            }
            [Test]
            public void WhenSettingsAreEmpty_OnlyScriptFileIsPresent()
            {
                var fixture = new DartFixture
                {
                    Settings = new DartSettings(),
                    ScriptFile = new FilePath("some.dart")
                };

                var actual = fixture.Run();

                Assert.That(actual.Args, Is.EqualTo("C:/Temp/some.dart"));
            }
            [Test]
            public void WhenSettingsAreNotEmpty_ScriptFileAndSettingsArePresent()
            {
                var fixture = new DartFixture
                {
                    Settings = new DartSettings
                    {
                        PauseIsolatesOnExit = true
                    },
                    ScriptFile = new FilePath("some.dart")
                };

                var actual = fixture.Run();

                Assert.That(actual.Args, Is.EqualTo("C:/Temp/some.dart --pause-isolates-on-exit"));
            }
            [Test]
            public void WhenSettingsAndVmOptionsAreNotEmpty_VmOptionsAndScriptFileAndSettingsArePresent()
            {
                var fixture = new DartFixture
                {
                    VmOptions = new Dictionary<string, object> { {"key", true } },
                    Settings = new DartSettings
                    {
                        PauseIsolatesOnExit = true
                    },
                    ScriptFile = new FilePath("some.dart")
                };

                var actual = fixture.Run();

                Assert.That(actual.Args, Is.EqualTo("--key=true C:/Temp/some.dart --pause-isolates-on-exit"));
            }
        }

        static string GetAbsolutePath(FilePath file) => $"{DartFixture.Root}/{file.FullPath}";
    }
}
