using System;

public class Program
{
	/// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	public static bool isSorted(int[] array)
	{
		int[] sorted = new int[array.Length];
		for (int x = 0; x < array.Length; x++)
		{
			sorted[x] = array[x];
		}
		int temp = 0;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < array.Length - 1; j++)
			{
				if (sorted[j] < sorted[j + 1])
				{
					temp = sorted[j];
					sorted[j] = sorted[j + 1];
					sorted[j + 1] = temp;
				}
			}
		}
		bool ans = true;
		for (int y = 0; y < array.Length; y++)
		{
			if (sorted[y] != array[y])
			{
				ans = false;
			}
		}
		return ans;
	}
}
