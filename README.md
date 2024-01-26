# Cake.Dart

A Cake AddIn that extends Cake with [Dart](https://www.dartlang.org/) compiler command tools.

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)
[![NuGet](https://img.shields.io/nuget/v/Cake.Dart.svg)](https://www.nuget.org/packages/Cake.Dart)

|Branch|Status|
|------|------|
|Master|[![Build status](https://ci.appveyor.com/api/projects/status/github/cake-contrib/Cake.Dart?branch=master&svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-dart)|
|Develop|[![Build status](https://ci.appveyor.com/api/projects/status/github/cake-contrib/Cake.Dart?branch=develop&svg=true)](https://ci.appveyor.com/project/cakecontrib/cake-dart)|


## Important

1.1.0 References Cake 4.0.0 and supports .net6, 7 and 8

1.0.0 References Cake 1.0.0

0.2.0 References Cake 0.33

0.1.0 References Cake 0.28 and .NET Standard 2.0.

## Including addin
Including addin in cake script is easy.
```
#addin "Cake.Dart"
```
## Usage

Dart has to be installed and it's dart.exe in path.

To use the addin add it to Cake call the aliases and configure any settings you want.

```csharp
#addin "Cake.Dart"
...

// Runs dart agains some.dart file using --pause-isolates-on-exit setting
Task("Dart")
	.Does(() => {
		// or more containers at once
		DartScript(File("some.dart"), new DartSettings{ PauseIsolatesOnExit = true });
	)};
```
Other commands follow same convention.

This version is built against Dart compiler 2.1.0.

## Credits

Brought to you by [Miha Markic](https://github.com/MihaMarkic) ([@MihaMarkic](https://twitter.com/MihaMarkic/)) and contributors.