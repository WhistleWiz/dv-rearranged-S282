using System;
using System.Collections.Generic;
using System.Text;

namespace RearrangedS282
{
	public static class Helper
	{
		public static float RadiusToScale(float newRadius, float defaultRadius)
		{
			return newRadius / defaultRadius;
		}

		public static float GetAxleRadius(AxleModel axle)
		{
			switch (axle)
			{
				case AxleModel.S282FrontAxle:
					return 0.354f;
				case AxleModel.S282RearAxle:
					return 0.578f;
				default:
					throw new ArgumentOutOfRangeException(nameof(axle));
			}
		}

		public static float GetWheelRadius(WheelModel wheel)
		{
			switch (wheel)
			{
				case WheelModel.S282Driver1:
				case WheelModel.S282Driver2:
				case WheelModel.S282Driver3:
				case WheelModel.S282Driver4:
					return 0.712f;
				case WheelModel.S060Driver1:
				case WheelModel.S060Driver2:
				case WheelModel.S060Driver3:
					return 0.712f;
				case WheelModel.DM3Driver1:
				case WheelModel.DM3Driver2:
				case WheelModel.DM3Driver3:
					return 0.536f;
				default:
					throw new ArgumentOutOfRangeException(nameof(wheel));
			}
		}
	}
}
