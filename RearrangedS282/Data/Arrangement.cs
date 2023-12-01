using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RearrangedS282.Data
{
	[Serializable]
	public class Arrangement
	{
		public static readonly string FileLocation = @"Mods\RearrangedS282\arrangements.xml";

		public string Name;
		public BogieWheelSet FrontBogie;
		public BogieWheelSet RearBogie;
		public DriverWheelSet[] DriverSets;

		public Arrangement()
		{
			Name = string.Empty;
			FrontBogie = new BogieWheelSet() { Z = 5 };
			RearBogie = new BogieWheelSet() { Z = -5 };
			DriverSets = new DriverWheelSet[0];
		}

		public string GetWhyteString()
		{
			StringBuilder sb = new();

			sb.Append(FrontBogie.Wheels.Length);

			if (DriverSets.Length == 0)
			{
				sb.Append("-0");
			}
			else
			{
				for (int i = 0; i < DriverSets.Length; i++)
				{
					sb.Append("-").Append(DriverSets[i].Wheels.Length);
				}
			}

			sb.Append("-").Append(RearBogie.Wheels.Length);

			return sb.ToString();
		}

		public string GetUicString()
		{
			StringBuilder sb = new();

			if (FrontBogie.Wheels.Length > 0)
			{
				sb.Append(FrontBogie.Wheels.Length);
			}

			for (int i = 0; i < DriverSets.Length; i++)
			{
				sb.Append((char)(DriverSets[i].Wheels.Length + 64));
			}

			if (RearBogie.Wheels.Length > 0)
			{
				sb.Append(RearBogie.Wheels.Length);
			}

			return sb.ToString();
		}

		public static Arrangement[] LoadArrangements()
		{
			if (!File.Exists(Path.GetFullPath(FileLocation)))
			{
				return Array.Empty<Arrangement>();
			}

			XmlSerializer serializer = new XmlSerializer(typeof(Arrangement));
			FileStream fs = new(Path.GetFullPath(FileLocation), FileMode.Open);

			return (Arrangement[])serializer.Deserialize(fs);
		}

		public static void SaveArrangements(Arrangement[] arrangements)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Arrangement));
			FileStream fs = new(Path.GetFullPath(FileLocation), FileMode.Create);

			serializer.Serialize(fs, arrangements);
		}

		public static Arrangement[] DefaultArrangements = new Arrangement[]
		{

		};
	}
}
