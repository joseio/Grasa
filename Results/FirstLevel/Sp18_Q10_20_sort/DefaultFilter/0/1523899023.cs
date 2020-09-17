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
		for (int i = 1; i < array.Length; i++)
		{
			int toSwap = array[i];
			for (int j = i - 1; j >= 0; j--)
			{
				if (array[j + 1] < array[j])
				{
					array[j + 1] = array[j];
					array[j] = toSwap;
				}
			}
		}
		return array;
	}
}
