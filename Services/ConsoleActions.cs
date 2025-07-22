namespace CheckBackups.Services;

public class ConsoleActions
{
    internal static void GetHelper()
    {
        Console.WriteLine("\n================================================");
        Console.WriteLine("# Проверка SQL/Veeam бэкапов на серверах АСКУЭ #");
        Console.WriteLine("================================================\n");
        Console.WriteLine("Доступные аргументы:\n");
        Console.WriteLine("-h\tСправка");
        Console.WriteLine("-s\tПроверка SQL-бэкапов");
        Console.WriteLine("-v\tПроверка Veeam-бэкапов");
        Console.WriteLine("-i\tДоп. информация\n");
    }

    internal static void GetAdditionalInfo()
    {
        Console.WriteLine("\n- Dev: RadzhabovRI");
        Console.WriteLine("- Github: @woundmee");
        Console.WriteLine("- Version: 2.1\n");
        Console.WriteLine("\nКак пользоваться скриптом?");
        Console.WriteLine("Подробнее расписано в readme.md. Команды вкратце ниже.");
        Console.WriteLine("\n- SQL: \"./CheckBackups -s Folder\", где Folder - это каталог с подкаталогами Day, Month и Year");
        Console.WriteLine("- Veeam: \"./CheckBackups -v Folder\", где Folder - это каталог с бэкап-файлами veeam\n");
    }
}