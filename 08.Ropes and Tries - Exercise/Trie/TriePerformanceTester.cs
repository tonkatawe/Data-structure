using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


public class TriePerformanceTester
{
    private const string VocabularyPath = "vocabulary.txt";

    public static void Main()
    {
     var stringEditor = new StringEditor();
     stringEditor.Login("pesho");
     stringEditor.Prepend("pesho", "stringexample");
     stringEditor.Delete("pesho",3,6);
     stringEditor.Insert("pesho", 3, "asdassdaasd");
     Console.WriteLine(stringEditor.Print("pesho"));
    }

    private static IEnumerable<string> GetAllMatches(char[] chars, int length)
    {
        int[] indexes = new int[length];
        char[] current = new char[length];

        for (int i = 0; i < length; i++)
        {
            current[i] = chars[0];
        }

        do
        {
            yield return new string(current);
        }
        while (Increment(indexes, current, chars));
    }

    private static bool Increment(int[] indexes, char[] current, char[] chars)
    {
        int position = indexes.Length - 1;

        while (position >= 0)
        {
            indexes[position]++;
            if (indexes[position] < chars.Length)
            {
                current[position] = chars[indexes[position]];
                return true;
            }

            indexes[position] = 0;
            current[position] = chars[0];
            position--;
        }

        return false;
    }

    /// <summary>
    /// Returns distinct set of words. <remarks>This method returns 58110 English words.</remarks>
    /// </summary>
    /// <returns>Distinct set of words.</returns>
    private static IEnumerable<string> LoadWords(string fileName)
    {
        string path = Path.Combine(@"..\..\", fileName);
        return File.ReadAllLines(path);
    }
}
