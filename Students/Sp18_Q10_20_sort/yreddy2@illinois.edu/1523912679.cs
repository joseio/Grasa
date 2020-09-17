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
		for (int i = 0; i < sorted.Length - 1; i++)
		{
			for (int i_1 = 0; i_1 < sorted.Length - 1; i_1++)
			{
				if (sorted[i_1] > sorted[i_1 + 1])
				{
					int temp = sorted[i_1];
					sorted[i_1] = sorted[i_1 + 1];
					sorted[i_1 + 1] = temp;
				}
			}
		}
		return sorted;
	}
}
