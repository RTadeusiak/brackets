using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static bool Solution(string input)
    {
        Stack<char> brackets = new Stack<char>();  // nawiasy
        Dictionary<char, char> chars = new Dictionary<char, char>()
    {
        {'{', '}'},
        {'(', ')'},
        {'<', '>'},
        {'[', ']'}
    };

        try
        {
            foreach (var mark in input)
            {
                if (chars.ContainsKey(mark))
                {
                    brackets.Push(mark); // dodajemy znak na wierzch stosu 
                }
                else if (chars.ContainsValue(mark))
                {
                    if (chars[brackets.Peek()] == mark) //pobieramy znak ze szczytu stosu i sprawdzamy (peek - zerknij)
                    {                                   // czy jest to odpowiadający znak otwierający dla klamry zamykającej
                        brackets.Pop(); // usuwa 
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        catch (InvalidOperationException)// Nieprawidłowy wyjątek operacji
        {
            return false;
        }
        return brackets.Count() == 0;
    }
    public static void Main(string[] args)
    {
        string[] arr =
        {
            "(({}[]<><{ }[]>{ }))",
            "{ }[()])<>{ } ([]){ })[()] { }",
            " [()]}<>{ {<> (([]))} [()]}<[] > (([]))[]{ }",
            "((((((((((((((()))))))))))))))",
            "((<{ { [[()]]} }>)())({ })<>[]{ }",
            "[()] { }",
            " { (())}<>{ }<>{ { { } } }",
            "[()] { }",
            "({ [{ [()]}]})<>[]{ { } (()[()])}",
            " { (())({ })}<> ()({ }",
        };
        foreach (string s in arr)
        {
            Console.WriteLine($"{s}: {Solution(s)}");
        }

    }
}
