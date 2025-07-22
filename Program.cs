using CheckBackups.Services;

namespace CheckBackups;

class Program
{
    static void Main()
    {
        // Database backup
        var dbBackups = new CheckDatabaseBackups();
        var dbCheck = dbBackups.Check("dbBackupsFolder");
        Console.WriteLine(dbCheck);
        
        // OS backup
        var osBackup = new CheckOsBackups();
        var osCheck = osBackup.Check("osBackupsFolder", "");
        Console.WriteLine(osCheck);

        Console.WriteLine();
        
        Helper.GetHelper();
    }
}

