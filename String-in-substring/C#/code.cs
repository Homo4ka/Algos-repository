using System;
using System.Collections.Generic;

public class StringSearch
{
    public static int FindSubstring(string text, string pattern)
    {
        if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(text))
            return -1;

        int n = text.Length;
        int m = pattern.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j = 0;
            while (j < m && text[i + j] == pattern[j])
            {
                j++;
            }

            if (j == m)
                return i;
        }

        return -1;
    }

    public static List<int> FindAll(string text, string pattern)
    {
        var result = new List<int>();

        if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(text))
            return result;

        int n = text.Length;
        int m = pattern.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j = 0;
            while (j < m && text[i + j] == pattern[j])
            {
                j++;
            }

            if (j == m)
                result.Add(i);
        }

        return result;
    }

    public static List<int> FindWholeWords(string text, string word)
    {
        var result = new List<int>();

        if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(text))
            return result;

        int n = text.Length;
        int m = word.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j = 0;
            while (j < m && text[i + j] == word[j])
            {
                j++;
            }

            if (j == m)
            {
                bool leftOk = (i == 0) || !char.IsLetter(text[i - 1]);
                bool rightOk = (i + m == n) || !char.IsLetter(text[i + m]);

                if (leftOk && rightOk)
                    result.Add(i);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        string text = "кат каталог карта кат";
        string pattern = "кат";

        Console.WriteLine("Первое вхождение: " + StringSearch.FindSubstring(text, pattern));

        Console.WriteLine("Все вхождения: ");
        foreach (var pos in StringSearch.FindAll(text, pattern))
            Console.WriteLine("  позиция " + pos);

        Console.WriteLine("Целые слова: ");
        foreach (var pos in StringSearch.FindWholeWords(text, pattern))
            Console.WriteLine("  позиция " + pos);
    }
}