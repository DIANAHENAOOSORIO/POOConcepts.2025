using System;
using POO.Concepts.Core;  

namespace POO.Concepts.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Time t1 = new Time(23, 58, 34, 666);
            Time t2 = new Time(12);
            Time t3 = new Time(5, 45);
            Time t4 = new Time(10, 30, 15);
            Time t5 = new Time();

            Console.WriteLine("Horas:");
            Console.WriteLine($"t1 = {t1}");
            Console.WriteLine($"t2 = {t2}");
            Console.WriteLine($"t3 = {t3}");
            Console.WriteLine($"t4 = {t4}");
            Console.WriteLine($"t5 = {t5}");

            Console.WriteLine("\nSuma de horas con t3:");
            Console.WriteLine($"t1 + t3 = {t1.Add(t3)}");
            Console.WriteLine($"t2 + t3 = {t2.Add(t3)}");
            Console.WriteLine($"t4 + t3 = {t4.Add(t3)}");

            Console.WriteLine("\n¿Pasa al otro día con t4?");
            Console.WriteLine($"t1 + t4 -> {t1.IsOtherDay(t4)}");
            Console.WriteLine($"t2 + t4 -> {t2.IsOtherDay(t4)}");
            Console.WriteLine($"t3 + t4 -> {t3.IsOtherDay(t4)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}