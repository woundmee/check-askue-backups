// dev: RadzhabovRI
// github: @woundmee
// last update: 22.07.2025
// version: 2.0

using CheckBackups.Services;

namespace CheckBackups;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
            ConsoleActions.GetHelper();
        else
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-h":
                        ConsoleActions.GetHelper();
                        break;
                    case "-s":
                        var dbBackups = new CheckDatabaseBackups();
                        var dbCheck = dbBackups.Check(args[i + 1]);
                        break;
                    case "-v":
                        var osBackup = new CheckOsBackups();
                        var osCheck = osBackup.Check(args[i + 1], args[i + 2]);
                        break;
                    case "-i":
                        ConsoleActions.GetAdditionalInfo();
                        break;
                    // default:
                    //     Console.WriteLine("Аргументы не заданы или заданы некорректно.");
                    //     break;
                }
            }
        }


        // ============
        //     // Database backup
        // var dbBackups = new CheckDatabaseBackups();
        // var dbCheck = dbBackups.Check("dbBackupsFolder");
        // Console.WriteLine(dbCheck);
        //
        //     // OS backup
        // var osBackup = new CheckOsBackups();
        // var osCheck = osBackup.Check("osBackupsFolder", "");
        // Console.WriteLine(osCheck);
        //
        //     Console.WriteLine();
        //     
        //     Helper.GetHelper();
    }
}