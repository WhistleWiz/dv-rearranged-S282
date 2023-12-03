using System;
using System.Collections.Generic;
using System.Text;

namespace RearrangedS282.Data
{
	[Serializable]
	public class DriverWheelSet
	{
		public float Z;
		// Same scale has to apply to all wheels, to have a proper animation.
		public float Radius;
		public WheelData[] Wheels;
		public bool HideValveGear;

		public bool HasWheels => Wheels.Length > 0;

		public DriverWheelSet()
		{
			Z = 0;
			Wheels = Array.Empty<WheelData>();
			HideValveGear = false;
		}
	}
}
