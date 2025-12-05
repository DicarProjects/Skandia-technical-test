using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace interview.Algorithms
{
    public class Algorithms
    {

        //1. Imprimir números 1 - 100 con validaciones;

        public static readonly List<(int Divisor, string Word)> DivisibilityRules = new List<(int, string)>
        {
            (3, "Bin"),
            (5, "Go")
        };

        public static List<string> ReturnNumbers()
        {
            List<string> numbers = new List<string>();


            numbers = Enumerable.Range(1, 100)
                                     .Select(i => ValidateDivisibility(i))
                                     .ToList();

            return numbers;
        }


        private static string ValidateDivisibility(int number)
        {
            string result = string.Empty;

            foreach (var rule in DivisibilityRules)
            {

                if (number % rule.Divisor == 0)
                {
                    result += rule.Word;
                }
            }

            if (result.Equals("BinGo"))
            {
                return "Bingo!";
            }

            return string.IsNullOrEmpty(result) ? number.ToString() : result;
        }

        //2. Imprimir los primeros 50 números primos

        private const int DefaultCount = 50;

        public static List<int> GetPrimesNumbers(int count = DefaultCount)
        {
            var (isValidationNeeded, validationResult) = RunBasicValidations(count);

            if (!isValidationNeeded) return validationResult;

            return GeneratePrimes(count);
        }

        private static (bool countValid, List<int> result) RunBasicValidations(int count)
        {
            if (count <= 0) return (false, new List<int>());
            if (count == 1) return (false, new List<int> { 2 });

            return (true, new List<int>());
        }

        private static List<int> GeneratePrimes(int count)
        {
            var primes = new List<int> { 2 };
            int currentNumber = 3;

            while (primes.Count < DefaultCount)
            {
                bool isPrime = true;
                int limit = (int)Math.Sqrt(currentNumber);


                foreach (var p in primes)
                {
                    if (p > limit) break;
                    if (currentNumber % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) primes.Add(currentNumber);
                currentNumber += 2;
            }

            return primes;
        }

        //3. Cadena de Texto inversa
        public static string GetReversedSentence(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                return string.Empty;

            var words = ExtractWords(sentence);

            if (words.Count == 0) return string.Empty;
            return JoinReversedWords(words);
        }

        private static List<string> ExtractWords(string sentence)
        {
            var words = new List<string>();

            for (int i = 0; i < sentence.Length;)
            {
                if (sentence[i] == ' ')
                {
                    i++;
                    continue;
                }

                int start = i;

                while (i < sentence.Length && sentence[i] != ' ')
                {
                    i++;
                }

                int length = i - start;
                words.Add(sentence.Substring(start, length));
            }

            return words;
        }

        private static string JoinReversedWords(List<string> words)
        {
            var sb = new System.Text.StringBuilder();
            for (int w = words.Count - 1; w >= 0; w--)
            {
                sb.Append(words[w]);
                if (w > 0) sb.Append(' ');
            }

            return sb.ToString();
        }

    }
}
