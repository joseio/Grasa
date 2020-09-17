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
		int[] sorted = array;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 1; j < array.Length - i; j++)
			{
				if (sorted[j] < sorted[j - 1])
				{
					int temp = sorted[j];
					sorted[j] = sorted[j - 1];
					sorted[j - 1] = temp;
				}
			}
		}
		return sorted;
	}
}
