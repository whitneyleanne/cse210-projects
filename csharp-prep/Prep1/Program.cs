using System;

Console.WriteLine("Hello Prep1 World!");

//string interpolation
int myInt = 5;
Console.WriteLine("my int = " + {myInt});
Console.WriteLine($"my int = {myInt}")

//read line
Console.Write("What is your name? ");
string name = Console.ReadLine();
Console.WriteLine($"name = {name}");


//conditionals
if (name == "Whitney")
{
    Console.WriteLine("Hey that's me!");
}
else
{
    Console.WriteLine($"Hi there {name}");
}
