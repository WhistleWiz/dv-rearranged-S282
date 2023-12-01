using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangementCreator
{
	internal static class ParseHelper
	{
		public static int ParseInt(Func<int, bool> condition, string message)
		{
			int number;

			while (!int.TryParse(Console.ReadLine(), out number) || !condition(number))
			{
				Console.CursorTop--;
				Console.Write(new string(' ', Console.BufferWidth));
				ConsoleColor c = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(message);
				Console.ForegroundColor = c;
				Console.CursorTop -= 2;
			}

			return number;
		}

		public static float ParseFloat(Func<float, bool> condition, string message)
		{
			float number;

			while (!float.TryParse(Console.ReadLine(), out number) || !condition(number))
			{
				Console.CursorTop--;
				Console.Write(new string(' ', Console.BufferWidth));
				ConsoleColor c = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(message);
				Console.ForegroundColor = c;
				Console.CursorTop -= 2;
			}

			return number;
		}
	}
}
