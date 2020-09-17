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
		if (array.Length == 0 || array.Length == 1)
		{
			return array;
		}
		bool swap = true;
		while (swap)
		{
			swap = false;
			for (int i = 1; i < n; i++)
			{
				if (array[i] < array[i - 1])
				{
					int temp = array[i];
					array[i] = array[i - 1];
					array[i - 1] = temp;
					swap = true;
				}
			}
		}
		return array;
	}
}
