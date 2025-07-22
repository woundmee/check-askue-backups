using System.Text.Json;

namespace CheckBackups.Services;

public class CheckOsBackups
{
    
    public string Check(string pathToBackupsDirectory, string saveToFile)
    {
        string osBackup = BackupFileRelevance(pathToBackupsDirectory, saveToFile);
        var json = OsBackupJsonResult(osBackup);
        return json;
    }
    
    
    private string BackupFileRelevance(string pathToBackupsDirectory, string saveToFile)
    {
        if (DateTime.Today.DayOfWeek == DayOfWeek.Monday) // бэкап создается в Субботу
        {
            int countExistFiles = 0;

            foreach (var file in FileOperations.GetFileNamesInDirectory(pathToBackupsDirectory))
            {
                if (file.Contains($"System Backup{DateTime.Today.Year}-{DateTime.Today:MM}-{DateTime.Today:dd}"))
                {
                    FileOperations.WriteToFile($"1:{file}", saveToFile);
                }
                else
                {
                    countExistFiles += 1;  // проверка в день совершения бэкапа на отсутствие актуального бэкапа 
                    if (FileOperations.GetFileNamesInDirectory(pathToBackupsDirectory).Count == countExistFiles)
                        FileOperations.WriteToFile($"0: VeeamBackupFileNotAvailable-{DateTime.Today.ToShortDateString()}", saveToFile);
                }
            }
        }
        else
        {
            var readedFile = FileOperations.ReadFromFile(saveToFile);
            return readedFile;
        }

        return FileOperations.ReadFromFile(saveToFile);
    }

    private string OsBackupJsonResult(string fileContent)
    {
        string status = fileContent.Split(':')[0];
        string osBackupName = fileContent.Split(':')[1];
        
        var toJson = new { nameBackupOS = osBackupName, available = status };
        return JsonSerializer.Serialize(toJson);
    }

  
}