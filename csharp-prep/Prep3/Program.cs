using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

      //  var count = 0;
      //  while (true)
      //  {
           // Console.WriteLine("Still Going");
           // if (count >= 5)
          //  {
            //    break;
          //  }
     //   }
    
    // do while loop
    //    do
    //    {
    //        Console.WriteLine("hit");
    //        Console.WriteLine($"Count = {count++}"); 
    //    
    //    } while (count < 5);

        //for loop
    //    for (var i = 5; count<10; i+=10)
    //}  

    //for each loop
   // var myInts = new int []{10, 20, 30, 40, 50};
   // foreach (var i in myInts)
   // {
   //     Console.WriteLine($"i = {i}");
   // }

   

   // Assignment
   //Ask for random number
   Console.Write("Give me a random number: ");
   string randomNumberString = Console.ReadLine();
   int randomNumber = int.Parse(randomNumberString);

    //Ask for user guess
   Console.Write("Guess the number: ");
   string guessNumberString = Console.ReadLine();
   int guessNumber = int.Parse(guessNumberString);

   //check if guess is higher
   if (guessNumber > randomNumber)
   { 
    Console.WriteLine("You guessed too high");
   }

   //check if guess is lower
   if (guessNumber < randomNumber)
   { 
    Console.WriteLine("You guessed too low");
   }

   //check if guess is a match
      if (guessNumber == randomNumber)
   { 
    Console.WriteLine("You guessed right!!");
   }


    }
}