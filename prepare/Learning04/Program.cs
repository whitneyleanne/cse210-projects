using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Whitney Hansen", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        MathAssign a2 = new MathAssign("Kathy Osorio", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WriteAssign a3 = new WriteAssign("Tara Shelters", "Writing and Reasoning Foundations", "Knowing Fallacies");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}

