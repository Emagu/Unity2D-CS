using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtension
{
	public static int RangeIn(this int originValue, int maxValue, int minValue)
	{
		return Mathf.Min(maxValue, Mathf.Max(originValue, minValue));
	}
	
	public static float Rate(this int originValue)
	{
		return (float)originValue / 100;
	}
}
