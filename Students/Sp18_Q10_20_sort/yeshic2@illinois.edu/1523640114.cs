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
		int[] sorted = new int[array.Length];
		int temp = 0;
		bool isSorted = false;
		for (int cnt = 0; cnt < array.Length; cnt++)
		{
			sorted[cnt] = array[cnt];
		}
		while (!isSorted)
		{
			isSorted = true;
			temp = sorted[0];
			for (int cnt_1 = 0; cnt_1 < array.Length; cnt_1++)
			{
				if (temp > sorted[cnt_1])
				{
					isSorted = false;
				}
			}
			for (int cnt_2 = 0; cnt_2 < sorted.Length - 1; cnt_2++)
			{
				if (sorted[cnt_2] > sorted[cnt_2] + 1)
				{
					temp = sorted[cnt_2];
					sorted[cnt_2] = sorted[cnt_2 + 1];
					sorted[cnt_2 + 1] = temp;
				}
			}
		}
		return sorted;
	}
}
