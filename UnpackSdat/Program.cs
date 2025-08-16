using DSSTCommon.Formats;
// See https://aka.ms/new-console-template for more information

// UnpackSdat.exe [<folder>] <sdat>
if (Environment.GetCommandLineArgs().Length > 1)
{
    string outputFolder = "\\out";
    if (Environment.GetCommandLineArgs().Length > 2)
    {
        outputFolder = Environment.GetCommandLineArgs()[1];
    }
    string sdatFile = Environment.GetCommandLineArgs().Last();

    if (File.Exists(sdatFile))
    {
        SDAT s = new SDAT(File.OpenRead(sdatFile));
        if (Directory.Exists(outputFolder))
        {
            Directory.Delete(outputFolder, true);
        }
        Directory.CreateDirectory(outputFolder);
        // Now we write all files
        s.ExtractSdat(outputFolder);
    } else
    {
        Console.WriteLine("File " + sdatFile + " does not exist! Terminating runtime!!");
        Environment.Exit(-1);
    }
}
else
{
    Console.WriteLine("Usage: UnpackSdat.exe [folder] <sdat>");
}