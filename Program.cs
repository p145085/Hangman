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

            for (int i = 0; i < hiddenLineArray.Length; i++)
            {
                hiddenLineArray[i] = '_';
                hiddenLineAsStringBuilder[i] = '_';
            }
            Console.WriteLine(hiddenLineArray);            

            StringBuilder wrong = new StringBuilder();
            StringBuilder correct = new StringBuilder();

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
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}


