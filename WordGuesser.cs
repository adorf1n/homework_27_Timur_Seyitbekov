using System;
using System.Collections.Generic;

public class WordGuesser
{
    private string _wordToGuess;
    private char[] _maskedWord;
    private List<char> _guessedLetters;
    private int _attempts;
    private int _maxAttempts;

    public int Attempts => _attempts;
    public int MaxAttempts => _maxAttempts;
    public int TriesLeft => _maxAttempts - _attempts;

    public WordGuesser(string word, int maxAttempts)
    {
        _wordToGuess = word;
        _maskedWord = new string('*', word.Length).ToCharArray();
        _guessedLetters = new List<char>();
        _attempts = 0;
        _maxAttempts = maxAttempts;
    }

    public bool GuessLetter(char letter)
    {
        _attempts++;
        bool isCorrect = false;
        if (!_guessedLetters.Contains(letter))
        {
            _guessedLetters.Add(letter);
            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                if (_wordToGuess[i] == letter)
                {
                    _maskedWord[i] = letter;
                    isCorrect = true;
                }
            }
        }
        return isCorrect;
    }

    public bool GuessWord(string word)
    {
        _attempts++;
        if (_wordToGuess.Equals(word, StringComparison.OrdinalIgnoreCase))
        {
            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                _maskedWord[i] = _wordToGuess[i];
            }
            return true;
        }
        return false;
    }

    public string GetMaskedWord()
    {
        return new string(_maskedWord);
    }

    public bool IsWordGuessed()
    {
        return _wordToGuess.Equals(GetMaskedWord());
    }

    public bool HasTriesLeft()
    {
        return _attempts < _maxAttempts;
    }
}
