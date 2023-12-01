using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RearrangedS282.Data
{
	[Serializable]
	public class WheelData
	{
		public float Z;
		public WheelModel Wheel;

		public Vector3 GetLocalScale(float radius)
		{
			float scale = Helper.RadiusToScale(radius, Helper.GetWheelRadius(Wheel));
			return new Vector3(1, scale, scale);
		}

		public Vector3 GetLocalPosition(float radius)
		{
			return new Vector3(0, radius, Z);
		}
	}
}
