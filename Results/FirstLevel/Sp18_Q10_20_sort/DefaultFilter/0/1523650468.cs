using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static int[] sort(int[] array)
	{
		int[] arraya = array;
		for (int i = 1; i < arraya.Length; i++)
		{
			for (int j = 1; j < arraya.Length; j++)
			{
				if (array[j] < arraya[j - 1])
				{
					int temp = arraya[j];
					arraya[j] = arraya[j - 1];
					arraya[j - 1] = temp;
				}
			}
		}
		return arraya;
	}
}
