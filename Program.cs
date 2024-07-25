using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "dictionary.txt";
        string playedWordsFilePath = "played_words.txt"; 

        DictionaryReader reader = new DictionaryReader(filePath, playedWordsFilePath);
        List<string> words = reader.ReadWords();
        List<string> playedWords = reader.ReadPlayedWords();

        List<string> newWords = words.Except(playedWords).ToList();

        if (newWords.Count > 0)
        {
            Random random = new Random();
            string randomWord = newWords[random.Next(newWords.Count)];
            int maxAttempts = randomWord.Length + 5; 
            WordGuesser wordGuesser = new WordGuesser(randomWord, maxAttempts);

            Console.WriteLine("Угадайте слово!");

            while (!wordGuesser.IsWordGuessed() && wordGuesser.HasTriesLeft())
            {
                Console.WriteLine(wordGuesser.GetMaskedWord());
                Console.Write("> ");
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    char guessedLetter = input[0];
                    if (!wordGuesser.GuessLetter(guessedLetter))
                    {
                        Console.WriteLine($"No, there is no such letter in this word. Your number of tries left: {wordGuesser.TriesLeft}");
                    }
                }
                else
                {
                    if (wordGuesser.GuessWord(input))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Это неверное слово! Your number of tries left: {wordGuesser.TriesLeft}");
                    }
                }
            }

            if (wordGuesser.IsWordGuessed())
            {
                Console.WriteLine($"Вы выиграли! Слово было \"{randomWord}\". Вы угадали за {wordGuesser.Attempts} попыток.");
            }
            else
            {
                Console.WriteLine($"Game over! The word was \"{randomWord}\".");
            }

            reader.SavePlayedWord(randomWord);
        }
        else
        {
            Console.WriteLine("Нет новых слов для игры. Все слова были сыграны.");
        }
    }
}
