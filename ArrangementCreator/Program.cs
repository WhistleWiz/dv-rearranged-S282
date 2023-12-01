using RearrangedS282.Data;

namespace ArrangementCreator
{
	internal class Program
	{
		private const string _wheelFormat = "  {0,10:F4}{1,8:F2}";

		static void Main(string[] args)
		{
			bool doLoop = true;
			List<Arrangement> arrangements = Arrangement.LoadArrangements().ToList();

			Menu current;
			Dictionary<string, Menu> menus = new();

			var resetArrangementOptions = () =>
			{
				menus["display"].ResetOptions(ArrangementsAsOptions(arrangements));
				menus["display"].Options.Add(new MenuOption("Return",
					() => { current = menus["main"]; }));
			};

			menus.Add("main",
				new Menu(PrintTitle,
					new MenuOption("Create arrangement",
						() =>
						{
							Console.Clear();
							arrangements.Add(ArrangementSetup.CreateWizard());
						}),
					new MenuOption("Display all",
						() =>
						{
							resetArrangementOptions();
							current = menus["display"];
						}),
					new MenuOption("Exit",
						() =>
						{
							doLoop = false;
						})));

			menus.Add("display", new Menu());

			current = menus["main"];

			do
			{
				current.Draw();
				current.AwaitInput();
			} while (doLoop);
		}

		internal static void PrintArrangement(Arrangement arrangement)
		{
			Console.WriteLine($"Arrangement: {arrangement.Name}");

			Console.WriteLine("\nFront bogie:");
			PrintBogie(arrangement.FrontBogie);
			Console.WriteLine("\nRear bogie:");
			PrintBogie(arrangement.RearBogie);

			Console.WriteLine($"\nDriver sets: {arrangement.DriverSets.Length}");

			for (int i = 0; i < arrangement.DriverSets.Length; i++)
			{
				Console.WriteLine($"  Driver set {i}");
				PrintDrivers(arrangement.DriverSets[i]);
			}
		}

		private static void PrintBogie(BogieWheelSet bogie)
		{
			Console.WriteLine($"  Bogie position: {bogie.Z}");

			if (!bogie.HasWheels)
			{
				Console.WriteLine("  No wheels.");
				return;
			}

			Console.WriteLine(_wheelFormat, "Position", "Radius");

			for (int i = 0; i < bogie.Wheels.Length; i++)
			{
				Console.WriteLine(_wheelFormat, bogie.Wheels[i].Z, bogie.Wheels[i].Radius);
			}
		}

		private static void PrintDrivers(DriverWheelSet drivers)
		{
			Console.WriteLine($"    Radius: {drivers.Radius}");

			for (int i = 0; i < drivers.Wheels.Length; i++)
			{
				Console.WriteLine($"    Driver {i + 1}: {drivers.Wheels[i].Z}");
			}
		}

		public static void PrintTitle()
		{
			Console.WriteLine(@"
		   ___                                            ____    __          
		  / _ \___ ___ ____________ ____  ___ ____ ____  / __/__ / /___ _____ 
		 / , _/ -_) _ `/ __/ __/ _ `/ _ \/ _ `/ -_) __/ _\ \/ -_) __/ // / _ \
		/_/|_|\__/\_,_/_/ /_/  \_,_/_//_/\_, /\__/_/   /___/\__/\__/\_,_/ .__/
		                                /___/                          /_/
");
		}

		public static MenuOption[] ArrangementsAsOptions(IEnumerable<Arrangement> arrangements)
		{
			return arrangements.Select(x => new MenuOption($"{x.Name} [{x.GetWhyteString()}/{x.GetUicString()}]",
			() =>
			{
				Console.Clear();
				PrintArrangement(x);
				Console.ReadKey();
			})).ToArray();
		}
	}
}
