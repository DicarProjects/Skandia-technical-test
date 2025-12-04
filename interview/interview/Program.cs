
using interview.Algorithms;


//1. Imprimir números 1 - 100 con validaciones;

var numbersResult = Algorithms.ReturnNumbers();
Console.WriteLine(string.Join(", ", numbersResult));

//2. Imprimir los primeros 50 números primos
Console.WriteLine("--------------------------------------------------------------");
var primeNumbers = Algorithms.GetPrimesNumbers();
Console.WriteLine(string.Join(", ", primeNumbers));

//3. Cadena de Texto inversa
