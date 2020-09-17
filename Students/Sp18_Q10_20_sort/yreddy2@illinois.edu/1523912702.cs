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
		for (int j = 0; j < sorted.Length - 1; j++)
		{
			for (int i = 0; i < sorted.Length - 1; i++)
			{
				if (sorted[i] > sorted[i + 1])
				{
					int temp = sorted[i];
					sorted[i] = sorted[i + 1];
					sorted[i + 1] = temp;
				}
			}
		}
		return sorted;
	}
}
