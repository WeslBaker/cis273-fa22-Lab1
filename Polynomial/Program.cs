﻿using System.Runtime.InteropServices;

namespace Polynomial;
class Program
{
    static void Main(string[] args)
    {
        Polynomial polynomial = new Polynomial();
        Term term1 = new Term(2, 0.0);
        polynomial.AddTerm(term1.Coefficient, term1.Power);
        Console.WriteLine(polynomial);
    }
}

