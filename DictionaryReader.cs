using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class DictionaryReader
{
    private string _filePath;
    private string _playedWordsFilePath;

    public DictionaryReader(string filePath, string playedWordsFilePath)
    {
        _filePath = filePath;
        _playedWordsFilePath = playedWordsFilePath;
    }

    public List<string> ReadWords()
    {
        List<string> words = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader(_filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(line.Trim());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return words;
    }

    public List<string> ReadPlayedWords()
    {
        List<string> playedWords = new List<string>();
        try
        {
            if (File.Exists(_playedWordsFilePath))
            {
                using (StreamReader sr = new StreamReader(_playedWordsFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        playedWords.Add(line.Trim());
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The played words file could not be read:");
            Console.WriteLine(e.Message);
        }
        return playedWords;
    }

    public void SavePlayedWord(string word)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(_playedWordsFilePath, true))
            {
                sw.WriteLine(word);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The played word could not be saved:");
            Console.WriteLine(e.Message);
        }
    }
}
