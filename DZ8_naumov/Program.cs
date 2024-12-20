using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var inputFilePath = "input.txt";
        var outputFilePath = "output.txt";

        try
        {
            var uniqueLines = ProcessFile(inputFilePath);
            SaveToFile(uniqueLines, outputFilePath);
            Console.WriteLine("Уникальные строки сохранены в output.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл {inputFilePath} не найден.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет прав доступа к файлу {outputFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static IEnumerable<string> ProcessFile(string filePath)
    {
        return File.ReadLines(filePath)
                   .Distinct()
                   .OrderBy(line => line);
    }

    static void SaveToFile(IEnumerable<string> lines, string filePath)
    {
        File.WriteAllLines(filePath, lines);
    }
}