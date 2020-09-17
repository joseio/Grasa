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
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[i] > array[j])
				{
					swap(array, i, j);
				}
			}
		}
		return array;
	}

	public static void swap(int[] array, int i, int j)
	{
		int temp = 0;
		temp = array[j];
		array[j] = array[i];
		array[i] = temp;
	}
}
