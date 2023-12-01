using System;
using System.Collections.Generic;
using System.Text;

namespace RearrangedS282.Data
{
	[Serializable]
	public class DriverWheelSet
	{
		// Same scale has to apply to all wheels, to have a proper animation.
		public float Radius;
		public WheelData[] Wheels;

		public bool HasWheels => Wheels.Length > 0;

		public DriverWheelSet()
		{
			Wheels = Array.Empty<WheelData>();
		}
	}
}
