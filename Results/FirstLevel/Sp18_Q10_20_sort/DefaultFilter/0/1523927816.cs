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
		int value = 0;
		int count = 0;
		for (int y = 0; y < array.Length - 1; y++)
		{
			for (int j = 0; j < array.Length - 1; j++)
			{
				if (array[j] >= array[j + 1])
				{
					value = array[j];
					array[j] = array[j + 1];
					array[j + 1] = value;
				}
				else
				{
					count = count + 1;
				}
			}
		}
		return array;
	}
}
