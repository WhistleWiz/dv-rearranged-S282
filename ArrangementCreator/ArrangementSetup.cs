using RearrangedS282.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangementCreator
{
	internal class ArrangementSetup
	{

		public static Arrangement CreateWizard()
		{
			Arrangement arrangement = new();

			Console.WriteLine("Creating new arrangement...\n");
			Console.Write("Arrangement name: ");
			arrangement.Name = Console.ReadLine();

			Console.WriteLine("\nFront bogie");
			arrangement.FrontBogie = BogieWizard();

			Console.WriteLine("\nRear bogie");
			arrangement.RearBogie = BogieWizard();

			Console.WriteLine("Complete!");
			Console.ReadKey();

			return arrangement;
		}

		private static BogieWheelSet BogieWizard()
		{
			BogieWheelSet bogie = new();

			Console.WriteLine("Position:");

			float z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!");
			Console.Write(new string(' ', Console.BufferWidth));
			bogie.Z = z;

			Console.WriteLine("Number of wheels:");

			int count = ParseHelper.ParseInt(x => x >= 0, "Value needs to be a number >= 0!");
			Console.Write(new string(' ', Console.BufferWidth));
			bogie.Wheels = new AxleData[count];

			for (int i = 0; i < count; i++)
			{
				Console.WriteLine($"Wheel {i + 1} position:");

				z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!");
				Console.Write(new string(' ', Console.BufferWidth));
				bogie.Wheels[i] = new() { Z = z };
			}

			return bogie;
		}
	}
}
