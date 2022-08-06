namespace DotNetCensus.Tests;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
[TestClass]
public class ConsoleAppTests : BaseTests
{
    [TestMethod]
    public void RunSamplesWithNoParametersTest()
    {
        //Arrange
        if (SamplesPath != null)
        {
            string[] parameters = Array.Empty<string>();
            StringWriter sw = new();
            string expected = @"
Framework  FrameworkFamily  Count  Status
-----------------------------------------

";

            //Act
            Console.SetOut(sw);
            Program.Main(parameters);
            string result = Environment.NewLine + sw.ToString();
            sw.Close();

            //Asset
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected, result);
        }
    }

    //    [TestMethod]
    //    public void RunSamplesWithPathTest()
    //    {
    //        //Arrange
    //        if (SamplesPath != null)
    //        {
    //            string[] parameters = new string[] { "-d", SamplesPath };
    //            StringWriter sw = new();
    //            string expected = @"
    //Framework             FrameworkFamily  Count  Status          
    //--------------------------------------------------------------
    //.NET 5.0              .NET                 1  deprecated      
    //.NET 6.0              .NET                 1  supported       
    //.NET 7.0              .NET                 1  supported       
    //.NET Core 1.0         .NET Core            1  deprecated      
    //.NET Core 1.1         .NET Core            1  deprecated      
    //.NET Core 2.0         .NET Core            1  deprecated      
    //.NET Core 2.1         .NET Core            1  deprecated      
    //.NET Core 3.0         .NET Core            1  deprecated      
    //.NET Core 3.1         .NET Core            3  EOL: 13-Dec-2022
    //.NET Framework 1.0    .NET Framework       1  deprecated      
    //.NET Framework 1.1    .NET Framework       1  deprecated      
    //.NET Framework 2.0    .NET Framework       1  deprecated      
    //.NET Framework 4.6.2  .NET Framework       1  supported       
    //.NET Framework 4.7.1  .NET Framework       1  supported       
    //.NET Framework 4.7.2  .NET Framework       2  supported       
    //.NET Standard 2.0     .NET Standard        1  supported       
    //(Unknown)             (Unknown)            1  unknown         
    //Visual Basic 6        Visual Basic 6       1  deprecated      

    //";

    //            //Act
    //            Console.SetOut(sw);
    //            Program.Main(parameters);
    //            string result = Environment.NewLine + sw.ToString();
    //            sw.Close();

    //            //Asset
    //            Assert.IsNotNull(expected);
    //            Assert.AreEqual(expected, result);
    //        }
    //    }

    //    [TestMethod]
    //    public void RunSamplesWithTotalsTest()
    //    {
    //        //Arrange
    //        if (SamplesPath != null)
    //        {
    //            string[] parameters = new string[] { "-d", SamplesPath, "-t" };
    //            StringWriter sw = new();
    //            string expected = @"
    //Framework             FrameworkFamily  Count  Status          
    //--------------------------------------------------------------
    //.NET 5.0              .NET                 1  deprecated      
    //.NET 6.0              .NET                 1  supported       
    //.NET 7.0              .NET                 1  supported       
    //.NET Core 1.0         .NET Core            1  deprecated      
    //.NET Core 1.1         .NET Core            1  deprecated      
    //.NET Core 2.0         .NET Core            1  deprecated      
    //.NET Core 2.1         .NET Core            1  deprecated      
    //.NET Core 3.0         .NET Core            1  deprecated      
    //.NET Core 3.1         .NET Core            3  EOL: 13-Dec-2022
    //.NET Framework 1.0    .NET Framework       1  deprecated      
    //.NET Framework 1.1    .NET Framework       1  deprecated      
    //.NET Framework 2.0    .NET Framework       1  deprecated      
    //.NET Framework 4.6.2  .NET Framework       1  supported       
    //.NET Framework 4.7.1  .NET Framework       1  supported       
    //.NET Framework 4.7.2  .NET Framework       2  supported       
    //.NET Standard 2.0     .NET Standard        1  supported       
    //(Unknown)             (Unknown)            1  unknown         
    //Visual Basic 6        Visual Basic 6       1  deprecated      
    //total frameworks                          21                  

    //";

    //            //Act
    //            Console.SetOut(sw);
    //            Program.Main(parameters);
    //            string result = Environment.NewLine + sw.ToString();
    //            sw.Close();

    //            //Asset
    //            Assert.IsNotNull(expected);
    //            Assert.AreEqual(expected, result);
    //        }
    //    }

    //    [TestMethod]
    //    public void RunSamplesWithRawResultsTest()
    //    {
    //        //Arrange
    //        if (SamplesPath != null)
    //        {
    //            string? file = null;
    //            string[] parameters = new string[] { "-d", SamplesPath, "--raw" };
    //            //StringWriter sw = new();
    //            string expected = @"
    //FileName                                    Path                                                                             FrameworkCode   FrameworkName         Family          Language  Status          
    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    //Assembly-CSharp.csproj                      \Sample.Unity2020\Assembly-CSharp.csproj                                         v4.7.1          .NET Framework 4.7.1  .NET Framework  csharp    supported       
    //project.json                                \Sample.NetCore1.0.ConsoleApp\project.json                                       netcoreapp1.0   .NET Core 1.0         .NET Core       csharp    deprecated      
    //project.json                                \Sample.NetCore1.1.ConsoleApp\project.json                                       netcoreapp1.1   .NET Core 1.1         .NET Core       csharp    deprecated      
    //Sample.MultipleTargets.ConsoleApp.csproj    \Sample.MultipleTargets.ConsoleApp\Sample.MultipleTargets.ConsoleApp.csproj      netcoreapp3.1   .NET Core 3.1         .NET Core       csharp    EOL: 13-Dec-2022
    //Sample.MultipleTargets.ConsoleApp.csproj    \Sample.MultipleTargets.ConsoleApp\Sample.MultipleTargets.ConsoleApp.csproj      net462          .NET Framework 4.6.2  .NET Framework  csharp    supported       
    //Sample.Net5.ConsoleApp.csproj               \Sample.Net5.ConsoleApp\Sample.Net5.ConsoleApp.csproj                            net5.0          .NET 5.0              .NET            csharp    deprecated      
    //Sample.Net6.ConsoleApp.csproj               \Sample.Net6.ConsoleApp\Sample.Net6.ConsoleApp.csproj                            net6.0          .NET 6.0              .NET            csharp    supported       
    //Sample.Net7.ConsoleApp.csproj               \Sample.Net7.ConsoleApp\Sample.Net7.ConsoleApp.csproj                            net7.0          .NET 7.0              .NET            csharp    supported       
    //Sample.NetCore.ConsoleApp.csproj            \Sample.NetCore3.1.ConsoleApp\Sample.NetCore.ConsoleApp.csproj                   netcoreapp3.1   .NET Core 3.1         .NET Core       csharp    EOL: 13-Dec-2022
    //Sample.NetCore2.0.ConsoleApp.csproj         \Sample.NetCore2.0.ConsoleApp\Sample.NetCore2.0.ConsoleApp.csproj                netcoreapp2.0   .NET Core 2.0         .NET Core       csharp    deprecated      
    //Sample.NetCore2.1.ConsoleApp.csproj         \Sample.NetCore2.1.ConsoleApp\Sample.NetCore2.1.ConsoleApp.csproj                netcoreapp2.1   .NET Core 2.1         .NET Core       csharp    deprecated      
    //Sample.NetCore3.0.ConsoleApp.csproj         \Sample.NetCore3.0.ConsoleApp\Sample.NetCore3.0.ConsoleApp.csproj                netcoreapp3.0   .NET Core 3.0         .NET Core       csharp    deprecated      
    //Sample.NetFramework.ConsoleApp.csproj       \Sample.NetFramework.ConsoleApp\Sample.NetFramework.ConsoleApp.csproj            v4.7.2          .NET Framework 4.7.2  .NET Framework  csharp    supported       
    //Sample.NetFrameworkVBNet.ConsoleApp.vbproj  \Sample.NetFrameworkVBNet.ConsoleApp\Sample.NetFrameworkVBNet.ConsoleApp.vbproj  netcoreapp3.1   .NET Core 3.1         .NET Core       vb.net    EOL: 13-Dec-2022
    //Sample.NetStandard.Class.csproj             \Sample.NetStandard.Class\Sample.NetStandard.Class.csproj                        netstandard2.0  .NET Standard 2.0     .NET Standard   csharp    supported       
    //Sample.SSDT.Database.sqlproj                \Sample.SSDT.Database\Sample.SSDT.Database.sqlproj                               v4.7.2          .NET Framework 4.7.2  .NET Framework  csharp    supported       
    //Sample.VB6.WinApp.vbp                       \Sample.VB6.Calculator\Sample.VB6.WinApp.vbp                                     vb6             Visual Basic 6        Visual Basic 6  vb6       deprecated      
    //VBProj.vbproj                               \Sample.NetFramework1.0.App\VBProj.vbproj                                        v1.0            .NET Framework 1.0    .NET Framework  vb.net    deprecated      
    //VBProj.vbproj                               \Sample.NetFramework1.1.App\VBProj.vbproj                                        v1.1            .NET Framework 1.1    .NET Framework  vb.net    deprecated      
    //VBProj.vbproj                               \Sample.NetFramework2.0.App\VBProj.vbproj                                        v2.0            .NET Framework 2.0    .NET Framework  vb.net    deprecated      
    //VBProj.vbproj                               \Sample.NetFrameworkInvalid.App\VBProj.vbproj                                                    (Unknown)             (Unknown)       vb.net    unknown         

    //";
    //            //var console = new TestConsole().SupportsAnsi(true);

    //            //Act
    //            //AnsiConsole.Record();
    //            //Console.SetOut(sw);
    //            string result = DataAccess.GetRawResults(SamplesPath, null);
    //            //string result = Environment.NewLine + sw.ToString();
    //            //sw.Close();

    //            //Asset
    //            //var test = console.Output.ToString();
    //            //var text = AnsiConsole.ExportText();
    //            //Assert.IsNotNull(text);
    //            //Assert.IsTrue( AnsiConsole.ExportText().Contains("VBProj.vbproj"));
    //            Assert.IsNotNull(expected);
    //            Assert.AreEqual(expected, result);
    //        }
    //    }

    [TestMethod]
    public void RunSamplesWithRawResultsToFileTest()
    {
        //Arrange
        if (SamplesPath != null)
        {
            string file = "test2.txt";
            string[] parameters = new string[] { "-d", SamplesPath, "-r", "-f", file };
            StringWriter sw = new();
            string expected = @"FileName,Path,FrameworkCode,FrameworkName,Family,Language,Status
Assembly-CSharp.csproj,/Sample.Unity2020/Assembly-CSharp.csproj,v4.7.1,.NET Framework 4.7.1,.NET Framework,csharp,supported
Calculator.csproj,/Sample.Net6.MAUI.Calculator/src/Calculator/Calculator.csproj,net6.0-ios,.NET 6.0-ios,.NET,csharp,supported
Calculator.csproj,/Sample.Net6.MAUI.Calculator/src/Calculator/Calculator.csproj,net6.0-android,.NET 6.0-android,.NET,csharp,supported
dotnetapp-3.5.csproj,/Sample.NetFramework3.5.Web/dotnetapp-3.5.csproj,v3.5,.NET Framework 3.5,.NET Framework,csharp,unknown
hello-world-fsharp.fsproj,/Sample.NetCore3.0.fsharp.ConsoleApp/hello-world-fsharp.fsproj,netcoreapp3.0,.NET Core 3.0,.NET Core,fsharp,deprecated
HelloWorld.fsproj,/Sample.NETFramework4.5FSharp.HelloWorld/HelloWorld.fsproj,net461,.NET Framework 4.6.1,.NET Framework,fsharp,unknown
project.json,/Sample.NetCore1.0.ConsoleApp/project.json,netcoreapp1.0,.NET Core 1.0,.NET Core,csharp,deprecated
project.json,/Sample.NetCore1.1.ConsoleApp/project.json,netcoreapp1.1,.NET Core 1.1,.NET Core,csharp,deprecated
Sample.MultipleTargets.ConsoleApp.csproj,/Sample.MultipleTargets.ConsoleApp/Sample.MultipleTargets.ConsoleApp.csproj,netcoreapp3.1,.NET Core 3.1,.NET Core,csharp,EOL: 13-Dec-2022
Sample.MultipleTargets.ConsoleApp.csproj,/Sample.MultipleTargets.ConsoleApp/Sample.MultipleTargets.ConsoleApp.csproj,net462,.NET Framework 4.6.2,.NET Framework,csharp,supported
Sample.Net5.ConsoleApp.csproj,/Sample.Net5.ConsoleApp/Sample.Net5.ConsoleApp.csproj,net5.0,.NET 5.0,.NET,csharp,deprecated
Sample.Net6.ConsoleApp.csproj,/Sample.Net6.ConsoleApp/Sample.Net6.ConsoleApp.csproj,net6.0,.NET 6.0,.NET,csharp,supported
Sample.Net7.ConsoleApp.csproj,/Sample.Net7.ConsoleApp/Sample.Net7.ConsoleApp.csproj,net7.0,.NET 7.0,.NET,csharp,supported
Sample.NetCore.ConsoleApp.csproj,/Sample.NetCore3.1.ConsoleApp/Sample.NetCore.ConsoleApp.csproj,netcoreapp3.1,.NET Core 3.1,.NET Core,csharp,EOL: 13-Dec-2022
Sample.NetCore2.0.ConsoleApp.csproj,/Sample.NetCore2.0.ConsoleApp/Sample.NetCore2.0.ConsoleApp.csproj,netcoreapp2.0,.NET Core 2.0,.NET Core,csharp,deprecated
Sample.NetCore2.1.ConsoleApp.csproj,/Sample.NetCore2.1.ConsoleApp/Sample.NetCore2.1.ConsoleApp.csproj,netcoreapp2.1,.NET Core 2.1,.NET Core,csharp,deprecated
Sample.NetCore2.2.ConsoleApp.csproj,/Sample.NetCore2.2.ConsoleApp/Sample.NetCore2.2.ConsoleApp.csproj,netcoreapp2.2,.NET Core 2.2,.NET Core,csharp,deprecated
Sample.NetCore3.0.ConsoleApp.csproj,/Sample.NetCore3.0.ConsoleApp/Sample.NetCore3.0.ConsoleApp.csproj,netcoreapp3.0,.NET Core 3.0,.NET Core,csharp,deprecated
Sample.NetFramework.ConsoleApp.csproj,/Sample.NetFramework.ConsoleApp/Sample.NetFramework.ConsoleApp.csproj,v4.7.2,.NET Framework 4.7.2,.NET Framework,csharp,supported
Sample.NetFrameworkVBNet.ConsoleApp.vbproj,/Sample.NetFrameworkVBNet.ConsoleApp/Sample.NetFrameworkVBNet.ConsoleApp.vbproj,netcoreapp3.1,.NET Core 3.1,.NET Core,vb.net,EOL: 13-Dec-2022
Sample.NetStandard.Class.csproj,/Sample.NetStandard.Class/Sample.NetStandard.Class.csproj,netstandard2.0,.NET Standard 2.0,.NET Standard,csharp,supported
Sample.SSDT.Database.sqlproj,/Sample.SSDT.Database/Sample.SSDT.Database.sqlproj,v4.7.2,.NET Framework 4.7.2,.NET Framework,csharp,supported
Sample.VB6.WinApp.vbp,/Sample.VB6.Calculator/Sample.VB6.WinApp.vbp,vb6,Visual Basic 6,Visual Basic 6,vb6,deprecated
VBProj.vbproj,/Sample.NetFramework1.0.App/VBProj.vbproj,v1.0,.NET Framework 1.0,.NET Framework,vb.net,deprecated
VBProj.vbproj,/Sample.NetFramework1.1.App/VBProj.vbproj,v1.1,.NET Framework 1.1,.NET Framework,vb.net,deprecated
VBProj.vbproj,/Sample.NetFramework2.0.App/VBProj.vbproj,v2.0,.NET Framework 2.0,.NET Framework,vb.net,deprecated
VBProj.vbproj,/Sample.NetFrameworkInvalid.App/VBProj.vbproj,,(Unknown),(Unknown),vb.net,unknown
WorldBankSample.csproj,/Sample.NetCore1.1.ConsoleApp/Net40/WorldBankSample.csproj,v4.0,.NET Framework 4.0,.NET Framework,csharp,deprecated
WorldBankSample.csproj,/Sample.NetCore1.1.ConsoleApp/Net45/WorldBankSample.csproj,v4.5,.NET Framework 4.5,.NET Framework,csharp,deprecated
WorldBankSample.csproj,/Sample.NetFramework40.WebApp/WorldBankSample.csproj,v4.0,.NET Framework 4.0,.NET Framework,csharp,deprecated
WorldBankSample.csproj,/Sample.NetFramework45.WebApp/WorldBankSample.csproj,v4.5,.NET Framework 4.5,.NET Framework,csharp,deprecated
";

            //Act
            Console.SetOut(sw);
            Program.Main(parameters);
            string result = sw.ToString();
            sw.Close();
            string contents = File.ReadAllText(Directory.GetCurrentDirectory() + "/" + file);

            //Asset
            Assert.AreEqual($"Exported results to 'test2.txt'" + Environment.NewLine, result);
            Assert.AreEqual(expected.Replace("\\", "/"), contents?.Replace("\\", "/"));

        }
    }


    [TestMethod]
    public void RunSamplesWithTotalsToFileTest()
    {
        //Arrange
        if (SamplesPath != null)
        {
            string file = "test.txt";
            string[] parameters = new string[] { "-d", SamplesPath, "-t", "-f", file };
            StringWriter sw = new();
            string expected = @"Framework,FrameworkFamily,Count,Status
.NET 5.0,.NET,1,deprecated
.NET 6.0,.NET,1,supported
.NET 6.0-android,.NET,1,supported
.NET 6.0-ios,.NET,1,supported
.NET 7.0,.NET,1,supported
.NET Core 1.0,.NET Core,1,deprecated
.NET Core 1.1,.NET Core,1,deprecated
.NET Core 2.0,.NET Core,1,deprecated
.NET Core 2.1,.NET Core,1,deprecated
.NET Core 2.2,.NET Core,1,deprecated
.NET Core 3.0,.NET Core,2,deprecated
.NET Core 3.1,.NET Core,3,EOL: 13-Dec-2022
.NET Framework 1.0,.NET Framework,1,deprecated
.NET Framework 1.1,.NET Framework,1,deprecated
.NET Framework 2.0,.NET Framework,1,deprecated
.NET Framework 3.5,.NET Framework,1,unknown
.NET Framework 4.0,.NET Framework,2,deprecated
.NET Framework 4.5,.NET Framework,2,deprecated
.NET Framework 4.6.1,.NET Framework,1,unknown
.NET Framework 4.6.2,.NET Framework,1,supported
.NET Framework 4.7.1,.NET Framework,1,supported
.NET Framework 4.7.2,.NET Framework,2,supported
.NET Standard 2.0,.NET Standard,1,supported
(Unknown),(Unknown),1,unknown
Visual Basic 6,Visual Basic 6,1,deprecated
total frameworks,,31,
";

            //Act
            Console.SetOut(sw);
            Program.Main(parameters);
            string result = sw.ToString();
            sw.Close();
            string contents = File.ReadAllText(Directory.GetCurrentDirectory() + "/" + file);

            //Asset
            Assert.AreEqual($"Exported results to 'test.txt'" + Environment.NewLine, result);
            Assert.AreEqual(expected.Replace("\\", "/"), contents?.Replace("\\", "/"));
        }
    }

    [TestMethod]
    public void RunSamplesWithInvalidParametersTest()
    {
        if (SamplesPath != null)
        {
            try
            {
                //Arrange
                string[] parameters = new string[] { "-d", SamplesPath, "-z" }; //z is an invalid parameter
                StringWriter sw = new();

                //Act
                Console.SetOut(sw);
                Program.Main(parameters);
            }
            catch (Exception ex)
            {
                //Asset
                Assert.IsNotNull(ex);
                Assert.AreEqual("One or more errors occurred. (CommandLine.UnknownOptionError)", ex.Message);
            }
        }
    }
    
}
