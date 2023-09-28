using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        // int i;
        // string s;
        // char c;
        // float f;
        // double d;
        // byte b;

        //lists - new keyword
        List<int> myInts = new List<int>();
        myInts.Add(2);
        myInts.Add(55);
        myInts.Remove(1);
        myInts.Insert(1, 34);
        
        var myStrings = new List<string>();
        myStrings.Add("Hello");

        //disable Implicit Usings
        //Add Items

        //Iterate over items
        foreach (var i in myInts)
        {
            Console.WriteLine($"My int = {i}");
        }












    }
}