using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Informe um número: ");
        int number = int.Parse(Console.ReadLine());

        if (IsFibonacci(number))
        {
            Console.WriteLine($"O número {number} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {number} não pertence à sequência de Fibonacci.");
        }
    }

    static bool IsFibonacci(int num)
    {
        int a = 0, b = 1;

        while (b <= num)
        {
            if (b == num) return true;

            int temp = a;
            a = b;
            b = temp + b;
        }

        return false;
    }
}
