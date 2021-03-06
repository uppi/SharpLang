# Getting started

## Compiling on Windows/Visual Studio

### x86

Note: There are manual steps that should be automated/simplified at some point.

1. Clone SharpLang to `<SharpLang>` with submodules.
2. Download `http://sourceforge.net/projects/mingw-w64/files/Toolchains%20targetting%20Win32/Personal%20Builds/mingw-builds/4.9.2/threads-win32/dwarf/i686-4.9.2-release-win32-dwarf-rt_v3-rev1.7z/download` and extract it in `<SharpLang>\deps`.
3. Download and install [CMake](http://www.cmake.org/cmake/resources/software.html). Alternatively, extract the zip archive and add `bin` directory to PATH.
4. Download and install [python](https://www.python.org/downloads/). Alternatively, set `PYTHON_EXECUTABLE:FILEPATH` variable in `<SharpLang>\deps\llvm\build\CMakeCache.txt` to `<SharpLang>/deps/mingw32/opt/bin/python.exe`.
5. Download [SWIG](http://swig.org/download.html) and extract it in `<SharpLang>\tools\swig`.
6. Run `<SharpLang>\deps\build_llvm_clang_vs2013_x32.bat`. This will build LLVM and Clang both in RelWithDebInfo and Debug mode with VS2013.
7. Run `<SharpLang>\deps\SharpLang.Build.Tasks\build.cmd`. This will build necessary SharpLang build tasks.
8. Open `<SharpLang>\build\vs2013\SharpLang.sln`.
9. Switch Active solution platform to *x86* in Build > Configuration Manager.
10. Build and play with tests. [NUnit Test Adapter](http://visualstudiogallery.msdn.microsoft.com/6ab922d0-21c0-4f06-ab5f-4ecd1fe7175d) extension or [Resharper](http://www.jetbrains.com/resharper/) has to be installed in order to get test cases listed in *Test Explorer*.

*Note: In default mode (Debug and RelWithDebInfo) the build artefacts require about 14 GB of disk space.*

### x64

Apply the same instruction as x86, except that:

2. Download mingw-w64 x86_64 instead, `http://sourceforge.net/projects/mingw-w64/files/Toolchains%20targetting%20Win64/Personal%20Builds/mingw-builds/4.9.2/threads-win32/seh/x86_64-4.9.2-release-win32-seh-rt_v3-rev1.7z/download` and extract it in extract it to `<SharpLang>\deps\mingw64`.
6. Run `<SharpLang>\deps\build_llvm_clang_vs2013_x64.bat`.
9 Switch Active solution to *x64*.
