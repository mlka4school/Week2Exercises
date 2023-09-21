using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TempConvert
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Start: Console.Clear();
			Console.WriteLine("Select a conversion method:");
			Console.WriteLine("a. Celsius to Fahrenheit");
			Console.WriteLine("b. Fahrenheit to Celsius");
			Console.WriteLine("c. Celsius to Kelvin");
			Console.WriteLine("d. Kelvin to Celsius");
			Console.WriteLine("e. Fahrenheit to Kelvin");
			Console.WriteLine("f. Kelvin to Fahrenheit");
			Console.WriteLine("g. Exit");

			var sselect = Console.ReadLine().ToLower();

			var convertType = "g";
				switch (sselect){
					case "a": case "b": case "c": case "d": case "e":	case "f":
						convertType = sselect; // set the convertType var to nselect
					break;
					case "g":
						// this is a blank case to exit the program comfortably.
					break;
					default: // this isn't real. loop back
					goto Start;
				}

			if (convertType != "g"){ // 
				// ask for an input
				Console.WriteLine("Insert the number you want to convert...");
				sselect = Console.ReadLine();

				var nselect = -1D; // "Unnecessary assignment of a value to 'nselect'" LOL ok
				// make sure this actually converts correctly
				try{
					nselect = Convert.ToDouble(sselect);
				}catch{
					// yeah this isn't a number
					goto Start;
				}

				// now convert based on what we've been given.
				var convselect = -1D;
				var convertSymbol1 = "C";
				var convertSymbol2 = "F";
				switch (convertType){
					case "a": // c->f
						convselect = (nselect * 9/5)+32;
					break;
					case "b": // f->c
						convselect = (nselect - 32)*5/9;
						convertSymbol1 = "F";
						convertSymbol2 = "C";
					break;
					case "c": // c->k
						convselect = nselect + 273.15;
						convertSymbol2 = "K";
					break;
					case "d": // k->c
						convselect = nselect - 273.15;
						convertSymbol1 = "K";
						convertSymbol2 = "C";
					break;
					case "e": // f->k
						convselect = ((nselect - 32)*5/9) + 273.15;
						convertSymbol1 = "F";
						convertSymbol2 = "K";
					break;
					case "f": // k->f
						convselect = ((nselect * 9/5)+32) - 273.15;
						convertSymbol1 = "K";
						convertSymbol2 = "F";
					break;
				}

				// note that with the kelvin conversions it seems there are floating point errors. whoops

				Console.WriteLine(nselect.ToString()+convertSymbol1+" - - - > "+convselect.ToString()+convertSymbol2);

				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
				goto Start;
			}
		}
	}
}
