namespace CheckBackups.Services;

public class FileOperations
{
    internal static List<string> GetFileNamesInDirectory(string pathToDirectory)
    {
        var files = new List<string>();
        foreach (var file in Directory.GetFiles(pathToDirectory))
            files.Add(Path.GetFileName(file));

        return files;
    }

    internal static void WriteToFile(string content, string path)
    {
        using StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(content);
    }

    internal static string ReadFromFile(string path)
    {
        using StreamReader sr = new StreamReader(path);
        return sr.ReadLine() ?? "Null";
    }
}