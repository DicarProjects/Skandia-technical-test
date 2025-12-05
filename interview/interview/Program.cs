
using interview.Algorithms;


//1. Imprimir números 1 - 100 con validaciones;

Console.WriteLine("---------------------------- 100 Primeros Numeros ----------------------------------");
var numbersResult = Algorithms.ReturnNumbers();
Console.WriteLine(string.Join(", ", numbersResult));

//2. Imprimir los primeros 50 números primos
Console.WriteLine("--------------------------- 50 primeros números Primos ------------------------------");
var primeNumbers = Algorithms.GetPrimesNumbers();
Console.WriteLine(string.Join(", ", primeNumbers));

//3. Cadena de Texto inversa

Console.WriteLine("------------------------ Cadena Inversa ---------------------------------------------");
var ReverseWord = Algorithms.GetReversedSentence("prueba de logica  ");
Console.WriteLine(ReverseWord);
