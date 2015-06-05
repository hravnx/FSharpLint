[![Issue Stats](http://issuestats.com/github/fsprojects/FSharpLint/badge/issue)](http://issuestats.com/github/fsprojects/FSharpLint)
[![Issue Stats](http://issuestats.com/github/fsprojects/FSharpLint/badge/pr)](http://issuestats.com/github/fsprojects/FSharpLint)

#FSharpLint [![NuGet Status](http://img.shields.io/nuget/v/FSharpLint.svg?style=flat)](https://www.nuget.org/packages/FSharpLint/)


FSharpLint is a style checking tool for F#. It points out locations where a set of rules on how F# is to be styled have been broken.
The tool is configurable via XML and can be run from a console app, or as an MSBuild task. It also provides an interface to easily integrate the tool into other software.

The project aims to let the user know of problems through [matching user defined hints](http://fsprojects.github.io/FSharpLint/Hints.html) a la [HLint](http://community.haskell.org/~ndm/hlint/), and also by using custom rules written in F# similar to the rules in [Mascot](http://mascot.x9c.fr/manual.html) and [StyleCop](http://stylecop.codeplex.com/).

The tool in use (running as an MSBuild task with TreatWarningsAsErrors set to true):

![Example](http://i.imgur.com/D4c9g1m.png)

###Documentation

Each directory aims to contain a README.md file with a brief technical overview of the code. 

The [docs](http://fsprojects.github.io/FSharpLint/) contains an overview of the tool and how to use it.

###Nuget

A [package is availiable on nuget](https://www.nuget.org/packages/FSharpLint/) - it sets up msbuild to run the tool after build on any projects the package is installed onto.

###Support

* Mono 3.10.0 - [![Mono CI Build Status](https://travis-ci.org/fsprojects/FSharpLint.svg?branch=master "Build Status")](https://travis-ci.org/fsprojects/FSharpLint)
* .NET - [![Windows CI Build status](https://ci.appveyor.com/api/projects/status/l4d22kby012cb7jf "Build Status")](https://ci.appveyor.com/project/duckmatt/fsharplint-231)

###Licensing

The project is licensed under GPLv3. For more information on the license see the LICENSE file and http://www.gnu.org/licenses/quick-guide-gplv3.html.

###Contact

Feel free to post an issue on [github](../../issues) if you have any questions, have suggestions, or have found a defect.

### Maintainer(s)

- [@duckmatt](https://github.com/duckmatt)

The default maintainer account for projects under "fsprojects" is [@fsprojectsgit](https://github.com/fsprojectsgit) - F# Community Project Incubation Space (repo management)
