This was a test solution to work through the following scenarios to find out what breaks and what works:

## Any CPUEXE
1. AnyCPU EXE referencing AnyCPUDLL
1. AnyCPU EXE referencing x86 DLL
1. AnyCPU EXE referencing x64 DLL (**Bad**)
1. AnyCPU EXE referencing AnyCPU DLL referencing x86 DLL
1. AnyCPU EXE referencing AnyCPU DLL referencing x64 DLL (**Bad**)

## x86EXE
1. x86 EXE referencing AnyCPU DLL
1. x86 EXE referencing x86 DLL
1. x86 EXE referencing x64 DLL (**Bad**)
1. x86 EXE referencing AnyCPU DLL referencing x86 DLL
1. x86 EXE referencing AnyCPU DLL referencing x64 DLL (**Bad**)

## x64EXE
1. x64 EXE referencing AnyCPU DLL
1. x64 EXE referencing x86 DLL (**Bad**)
1. x64 EXE referencing x64 DLL
1. x64 EXE referencing AnyCPU DLL referencing x86 DLL (**Bad**)
1. x64 EXE referencing AnyCPU DLL referencing x64 DLL
