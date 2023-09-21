using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rnGen = new Random(); // we're really doing this already huh? alright..
			int curntGuess = 0;
			int guessCount = 0;
			int randNumber = 0;

			int numCount = 0;

			RNumber: Console.WriteLine("I'll pick a number between 1 and... (type your number)");

			try{
				numCount = Convert.ToInt32(Console.ReadLine());
			}catch{
				Console.WriteLine("That's not a number..");
				goto RNumber;
			}

			if (numCount <= 1){
				Console.WriteLine("That seems illogical...");
				goto RNumber;
			}
			
			Console.WriteLine("OK! 1 and "+numCount.ToString()+"! Get to guessing...");

			// init everything and go!
			curntGuess = -1;
			guessCount = 0;
			randNumber = (rnGen.Next(numCount))+1; // this is done because random generates between 0 and randNumber-1 which we don't want. supposedly?

			while (curntGuess != randNumber){
				++guessCount; // prematurely increment this. just because we can

				// call a guess in a trycatch
				try{
					curntGuess = Convert.ToInt32(Console.ReadLine());
				}catch{
					Console.WriteLine("That's not a number..");
					continue;
				}

				if (curntGuess == randNumber){
					Console.WriteLine("Bingo!");
				}else if (curntGuess > randNumber){
					Console.WriteLine("Lower...");
				}else{ // assume this is curntGuess < randNumber
					Console.WriteLine("Higher...");
				}
			}
			
			// really don't need to do this but the grammar hurts me on a spiritual level
			if (guessCount == 1){
				Console.WriteLine("That took you just 1 try! Go again? Y/N");
			}else{
				Console.WriteLine("That took you "+guessCount+" tries. Go again? Y/N");
			}
			
			var againLine = Console.ReadLine();
			if (againLine.ToLower() == "y"){
				Console.WriteLine(""); // line break too
				goto RNumber;
			}
		}
	}
}
