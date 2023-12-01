using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RearrangedS282.Data
{
	[Serializable]
	public class AxleData
	{
		public float Z;
		public float Radius;
		public AxleModel Axle;

		public Vector3 GetLocalScale()
		{
			float scale = Helper.RadiusToScale(Radius, Helper.GetAxleRadius(Axle));
			return new Vector3(1, scale, scale);
		}

		public Vector3 GetLocalPosition()
		{
			return new Vector3(0, Radius, Z);
		}
	}
}
