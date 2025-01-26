using System;
using System.Collections.Generic;

class Program
{
    static bool isBalanced(string expr)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> pairs = new Dictionary<char, char> { { '{', '}' }, { '(', ')' }, { '[', ']' } };

        foreach (char ch in expr)
        {
            if (pairs.ContainsKey(ch))
                stack.Push(ch);
            else if (pairs.ContainsValue(ch))
            {
                if (stack.Count == 0 || pairs[stack.Pop()] != ch)
                    return false;
            }
        }

        return stack.Count == 0;
    }

    static void Main(string[] args)
    {
        string expr = "{7+(8*5)-[(9-7)+(4+1)]}";
        if (isBalanced(expr))
            Console.WriteLine("La expresión está balanceada");
        else
            Console.WriteLine("La expresión no está balanceada");
    }
}
