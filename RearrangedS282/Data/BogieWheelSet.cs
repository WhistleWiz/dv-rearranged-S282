using System;
using System.Collections.Generic;
using System.Text;

namespace RearrangedS282.Data
{
	[Serializable]
	public class BogieWheelSet
	{
		public AxleData[] Wheels;
		public float Z;

		public bool HasWheels => Wheels.Length > 0;

		public BogieWheelSet()
		{
			Wheels = Array.Empty<AxleData>();
			Z = 0;
		}
	}
}
