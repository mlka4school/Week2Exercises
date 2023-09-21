using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// init all of this
            double value1 = 0;
            double value2 = 0;

            var line = "";
            FirstVal: Console.WriteLine("Add your first number and press ENTER");

            line = Console.ReadLine();

            // attempt a convert
            if (!AttemptConvert(line, ref value1)) goto FirstVal;

            SecondVal:  Console.WriteLine("Add your second number and press ENTER");

            line = Console.ReadLine();

            // attempt another convert
            if (!AttemptConvert(line, ref value2)) goto SecondVal;

            Operator: Console.WriteLine("Select an operator to use: +, -, *, or /");

            line = Console.ReadLine();

            Console.WriteLine(""); // line break

            switch (line)
            {
                case "+":
					Console.WriteLine(value1.ToString()+" + "+value2.ToString()+" = "+(value1+value2).ToString());
                break;
				case "-":
					Console.WriteLine(value1.ToString()+" - "+value2.ToString()+" = "+(value1-value2).ToString());
					break;
				case "*":
					Console.WriteLine(value1.ToString()+" * "+value2.ToString()+" = "+(value1*value2).ToString());
					break;
				case "/":
					if (value2 == 0)
					{
						Console.WriteLine(value1.ToString()+" / "+value2.ToString()+" = A black hole (can't div by 0)");
					}
					else
					{
						Console.WriteLine(value1.ToString()+" / "+value2.ToString()+" = "+(value1/value2).ToString());
					}
					break;
				default:
                    Console.WriteLine("That doesn't seem to be a valid operator...");
				goto Operator;
            }

			Console.WriteLine(""); // line break
			Console.WriteLine("Keep going? Y/N");
			var keepGoing = (Console.ReadLine()).ToLower();

			if (keepGoing == "y")
			{ // the user wants to keep going, so return them to the start of the goto loop
				Console.WriteLine(""); // line break
				goto FirstVal;
			}

			// otherwise, the user likely wants to leave the program, so we'll end our loop here.
        }

        static bool AttemptConvert(string tryLine, ref double setValue)
        {
            var convertAttempt = 0D;
            // would this convert cleanly?
            try
            {
                convertAttempt = Convert.ToDouble(tryLine);
            }
            catch
            {
                return false;
            }

            // we are probably fine. return true and set value
            setValue = convertAttempt;
            return true;
        }
    }
}
