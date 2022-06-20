# ReadyToRunPerformanceTest
This is a sample project that demonstrates the difference between NGen.exe in .NET Framework and ReadyToRun images in .NET 6 Winforms.  
The Load Assemblies button loads DevExpress binaries. If no native images are generated, this causes the JIT compiler to process many DevExpress types and methods, affecting the loading speed.
Orginal: https://github.com/AlexChuev/ReadyToRunPerformanceTest/
## Testing .NET Framework + NGen.exe
Build the **NgenPerformanceTest** project and run its Release version without an attached debugger:  
*\NgenPerformanceTest\bin\Release\NgenPerformanceTest.exe*  
Run the NGen.exe tool using the Install Native Images button and compare how long it takes to load assemblies with and without Native Images.
## Testing .NET 6 + ReadyToRun images
Open the **ReadyToRunPerformanceTest** project and wait for NuGet packages to resolve (this may take some time). Build the project and select the Publish option in Visual Studio to generate ReadyToRun images. Compare how long it takes to load assemblies with and without ReadyToRun images:  
*\ReadyToRunPerformanceTest\bin\Release\net6.0-windows\publish\ReadyToRunPerformanceTest.exe*
*\ReadyToRunPerformanceTest\bin\Release\net6.0-windows_r2r\publish\ReadyToRunPerformanceTest.exe*