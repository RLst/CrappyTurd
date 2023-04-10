using UnityEngine;

namespace Pokoro
{
	//! Utility class and functions
	public class Utils
	{
		public static float Remap(float value, float inMin, float inMax, float outMin, float outMax, bool clamp = true)
		{
			var result = (outMax - outMin) * (value - inMin) / (inMax - inMin) + outMin;
			return clamp ? Mathf.Clamp(result, outMin, outMax) : result;		//! Ternary Operator
		}
	}
}