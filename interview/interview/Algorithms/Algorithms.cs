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

        public readonly List<(int Divisor, string Word)> DivisibilityRules = new List<(int, string)>
        {
            (3, "Bin"),
            (5, "Go")
        };

        public List<string> ReturnNumbers()
        {
            List<string> numbers = new List<string>();


            numbers = Enumerable.Range(1, 100)
                                     .Select(i => ValidateDivisibility(i))
                                     .ToList();

            return numbers;
        }



        private string ValidateDivisibility(int number)
        {
            string result = string.Empty;

            foreach (var rule in DivisibilityRules) {

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

        //3. Cadena de Texto inversa
    }
}
