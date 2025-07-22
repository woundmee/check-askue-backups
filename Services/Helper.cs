namespace CheckBackups.Services;

public class Helper
{
    internal static void GetHelper()
    {
        Console.WriteLine("================================================");
        Console.WriteLine("# Проверка SQL/Veeam бэкапов на серверах АСКУЭ #");
        Console.WriteLine("================================================\n");
        Console.WriteLine("Доступные аргументы:\n");
        Console.WriteLine("-h\tСправка");
        Console.WriteLine("-s\tПроверка SQL-бэкапов");
        Console.WriteLine("-v\tПроверка Veeam-бэкапов");
        Console.WriteLine("-i\tДоп. информация\n");
    }
}