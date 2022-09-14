using System.Linq.Expressions;
using System.Text;

namespace Hangman
{
    internal class Program
    {
        private static readonly string[] HangmanWords = 
        {
            "HANGMAN", "APPLE", "TOWER", "SMARTPHONE", "PROGRAMMING", "AWKWARD", "BANJO",
            "DWARVES", "FISHHOOK", "JAZZY", "JUKEBOX", "MEMENTO", "MYSTIFY", "OXYGEN", "PIXEL",
            "ZOMBIE", "NUMBSKULL", "BAGPIPES", "COMPUTER", "EASTER", "CHRISTMAS", "COFFEE"
        };
        private static string WordPicker()
        {
            Random rnd = new Random();
            int temp = rnd.Next(0, HangmanWords.Length);
            string word = HangmanWords[temp];

            return word;
        }
        //private static bool IsInputCorrect(string input, string word)
        //{
        //    if (input == word)
        //    {
        //        return true;
        //    } else if (input.Length == 1)
        //    {
        //        return charGuess(input, word);
        //    } else
        //    {
        //        return false;
        //    }
        //}
        //private static bool charGuess(string input, string word)
        //{
        //    if (word.Contains(input))
        //    {
        //        return true;
        //    } else
        //    {
        //        return false;
        //    }
        //}
        static void Main(string[] args)
        {
            bool end = false;
            int guesses = 10;

            string answer = WordPicker();
            answer = answer.ToUpper();
            char[] cAnswer = answer.ToCharArray();
            StringBuilder answerAsStringBuilder = new StringBuilder(answer);

            char[] hiddenLineArray = answer.ToCharArray();
            StringBuilder hiddenLineAsStringBuilder = new StringBuilder(answer);

            Console.WriteLine(hiddenLineArray); // DEBUG
            for (int i = 0; i < hiddenLineArray.Length; i++)
            {
                hiddenLineArray[i] = '_';
                hiddenLineAsStringBuilder[i] = '_';
            }
            Console.WriteLine(hiddenLineArray);            

            StringBuilder wrong = new StringBuilder();
            StringBuilder correct = new StringBuilder();
            StringBuilder gameMap = new StringBuilder();

            while (end == false)
            {
                try
                {
                    Console.WriteLine("Enter your guess: ");
                    string? input = Console.ReadLine();
                    input = input.ToUpper();
                    char[] cInput = input.ToCharArray();
                    StringBuilder sbInput = new StringBuilder(input);

                    if (guesses > 0)
                    {
                        for (int i = 0; i < cInput.Length; i++)
                        {
                            for (int j = 0; j < cAnswer.Length; j++)
                            {
                                if (answer.Contains(cInput[i]))
                                {
                                    if (cInput[i] == cAnswer[j])
                                    {
                                        hiddenLineAsStringBuilder[j] = cInput[i];
                                        Console.WriteLine(hiddenLineAsStringBuilder);
                                        correct.Insert(correct.Length, cInput[i]);
                                        if (hiddenLineAsStringBuilder.ToString() == answer)
                                        {
                                            Console.WriteLine("Winner!");
                                            end = true;
                                        }
                                    }
                                }
                                else if (!answer.Contains(cInput[i]))
                                {
                                    wrong.Insert(wrong.Length, cInput[i]);
                                    guesses--;
                                    break;
                                }
                                
                            }
                        }
                        Console.WriteLine("Correct : " + "[" + correct + "]");
                        Console.WriteLine("Wrong : " + "[" + wrong + "]");
                        Console.WriteLine("Guesses: " + guesses);
                        Console.WriteLine("The word: " + hiddenLineAsStringBuilder);
                    } else if (guesses == 0)
                    {
                        Console.WriteLine("Game is over.");
                    }
                    

                    //if (cInput.Length == 1)
                    //{
                    //    //do char check
                    //    for (int i = 0; i < answer.Length; i++)
                    //    {
                    //        if (answer[i] == cInput[0])
                    //        {
                    //            correct.Append(answer[i]);
                    //            Console.WriteLine("Correct : " + "[" + correct + "]");
                    //        }
                    //    }
                    //} else if (cInput.Length > 1)
                    //{
                    //    //do word check
                    //}



                    //for (int i = 0; i < cAnswer.Length; i++)
                    //{
                    //    gameMap = new StringBuilder();
                    //    if (correct.Length > 0)
                    //    {

                    //    }
                    //    gameMap.Insert(i, "_");
                    //}
                    //Console.WriteLine(gameMap);

                    //Console.WriteLine("Enter your guess: ");
                    //string? input = Console.ReadLine();
                    //char[] cInput = input.ToCharArray();

                    //for (int i = 0; i < cInput.Length; i++)
                    //{
                    //    for (int j = 0; j < cAnswer.Length; j++)
                    //    {
                    //        if (cInput[i] == cAnswer[i])
                    //        {
                    //            Console.WriteLine("Yep");
                    //        }
                    //    }
                    //}

                    //

                    //int random = (new Random()).Next(words.Length);
                    ////Console.WriteLine(words[random]);
                    ////Console.WriteLine(words[random].Length);
                    //int guesses = 0;
                    //char[] word = new char[words[random].Length];
                    //for (int index = 0; index < word.Length; index++)
                    //{
                    //    word[index] = '_';
                    //}
                    //StringBuilder guessed = new StringBuilder();
                    //Console.WriteLine(string.Format("Program choosing a word with {0} length.", word.Length));



                    //do
                    //{
                    //    Console.WriteLine("\nplease enter your guess :");
                    //    string? entry = Console.ReadLine();
                    //    bool isWord = entry.Length != 1;
                    //    if (isWord)
                    //    {
                    //        if (words[random] == entry)
                    //        {
                    //            word = words[random].ToCharArray();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        int index = 0;
                    //        foreach (char character in words[random])
                    //        {
                    //            if (char.Parse(entry) == character)
                    //            {
                    //                word[index] = character;
                    //            }
                    //            index++;
                    //        }
                    //    }
                    //}

                    //





                    //foreach (char c in cInput) // För varje bokstav i gissningen.
                    //{
                    //    for (int i = 0; i < cAnswer.Length; i++) // För varje bokstav i svaret.
                    //    {
                    //        if (c == cAnswer[i])
                    //        {

                    //        }
                    //    }
                    //}



                    //foreach (char c in cInput)
                    //{
                    //    for (int j = 0; j < cAnswer.Length; j++)
                    //    {
                    //        if (c == cAnswer[j])
                    //        {
                    //            Console.WriteLine("Correct");
                    //        }
                    //    }
                    //}
                    //int attempts = 0;

                    //if (attempts >= 10)
                    //{
                    //    end = true;
                    //} else if (attempts < 10)
                    //{
                    //    string? input = Console.ReadLine();
                    //    if (IsInputCorrect(input, answer))
                    //    {
                    //        end = true;
                    //        Console.WriteLine("Winner!");
                    //        Console.WriteLine(answer);
                    //        Console.ReadLine();
                    //    }
                    //    else if (charGuess(input, answer))
                    //    {
                    //        correctGuesses.Add(input);
                    //        Console.WriteLine(correctGuesses);
                    //    } 
                    //}
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}


