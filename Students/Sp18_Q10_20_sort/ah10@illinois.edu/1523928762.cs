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
		for (int i = 0; i < sorted.Length; i++)
		{
			for (int j = i + 1; j < sorted.Length; j++)
			{
				if (sorted[i] > sorted[j])
				{
					int temp = sorted[j];
					sorted[j] = sorted[i];
					sorted[i] = temp;
				}
			}
		}
		return sorted;
	}
}
