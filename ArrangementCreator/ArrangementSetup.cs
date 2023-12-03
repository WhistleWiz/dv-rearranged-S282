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
			Console.WriteLine("Arrangement name:");
			arrangement.Name = Console.ReadLine();

			Console.WriteLine("\nFront bogie");
			arrangement.FrontBogie = BogieWizard();

			Console.WriteLine("\nRear bogie");
			arrangement.RearBogie = BogieWizard();

			Console.WriteLine("\nNumber of driver sets:");
			int driverCount = ParseHelper.ParseInt(x => x >= 0, "Value needs to be a number >= 0!");

			arrangement.DriverSets = new DriverWheelSet[driverCount];

			for (int i = 0; i < driverCount; i++)
			{
				Console.WriteLine($"Driver set {i + 1}:");
				arrangement.DriverSets[i] = DriverWizard();
			}

			Console.WriteLine("Complete!");
			Console.ReadKey();

			return arrangement;
		}

		private static BogieWheelSet BogieWizard()
		{
			BogieWheelSet bogie = new();

			Console.WriteLine("Position:");
			bogie.Z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!");

			Console.WriteLine("\nNumber of wheels:");
			bogie.Wheels = new AxleData[ParseHelper.ParseInt(x => x >= 0, "Value needs to be a number >= 0!")];

			for (int i = 0; i < bogie.Wheels.Length; i++)
			{
				Console.WriteLine($"\nWheel {i + 1} position:");
				bogie.Wheels[i] = new() { Z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!") };
			}

			return bogie;
		}

		private static DriverWheelSet DriverWizard()
		{
			DriverWheelSet driver = new();

			Console.WriteLine("Position:");
			driver.Z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!");

			Console.WriteLine("\nNumber of wheels:");
			driver.Wheels = new WheelData[ParseHelper.ParseInt(x => x >= 1, "Value needs to be a number >= 1!")];

			Console.WriteLine("\nWheel radius:");
			driver.Radius = ParseHelper.ParseFloat(x => x > 0, "Value needs to be a number > 0!");

			for (int i = 0; i < driver.Wheels.Length; i++)
			{
				Console.WriteLine($"\nWheel {i + 1} position:");
				driver.Wheels[i] = new() { Z = ParseHelper.ParseFloat(x => true, "Value needs to be a number!") };
			}

			Console.WriteLine("\nHide valve gear:");
			driver.HideValveGear = ParseHelper.ParseBool();

			return driver;
		}
	}
}
