using System.Text.Json;

namespace CheckBackups.Services;

class CheckDatabaseBackups
{
    enum BackupType
    {
        Daily,
        Monthly,
        Yearly
    }

    public string Check(string pathToBackupsDirectory)
    {
        int daily = BackupFileRelevance($"{pathToBackupsDirectory}/Day/", BackupType.Daily);
        int monthly = BackupFileRelevance($"{pathToBackupsDirectory}/Month/", BackupType.Monthly);
        int yearly = BackupFileRelevance($"{pathToBackupsDirectory}/Year/", BackupType.Yearly);

        var toJson = new { Daily = daily, Monthly = monthly, Yearly = yearly };
        string json = JsonSerializer.Serialize(toJson);

        return json;
    }


    // проверка актуальности бэкапа
    private int BackupFileRelevance(string backupFileName, BackupType backupType)
    {
        foreach (var file in FileOperations.GetFileNamesInDirectory(backupFileName))
        {
            var filename = GetDateFromFile(Path.GetFileName(file));

            bool isRelevant = backupType switch
            {
                BackupType.Daily => filename == DateOnly.Parse(DateTime.Today.ToShortDateString()),
                BackupType.Monthly => filename.Month == DateTime.Today.Month && filename.Day == 1,
                BackupType.Yearly => filename.Year == DateTime.Today.Year,
                _ => throw new ArgumentOutOfRangeException(nameof(backupType), "Неизвестный тип бэкапа.")
            };

            if (isRelevant) return 1;
        }

        return 0;
    }


    private DateOnly GetDateFromFile(string filename)
    {
        // Pyramid2_backup_Day_2025_07_18.txt
        string day = filename.Split('.')[0].Split('_')[^1];
        string month = filename.Split('.')[0].Split('_')[^2];
        string year = filename.Split('.')[0].Split('_')[^3];

        var date = DateOnly.Parse($"{day}.{month}.{year}");
        return date;
    }
}