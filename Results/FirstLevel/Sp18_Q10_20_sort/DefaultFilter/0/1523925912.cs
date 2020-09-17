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
		int[] sort = new int[array.Length];
		int temp = 0;
		for (int i = 0; i <= array.Length - 1; i++)
		{
			for (int j = i + 1; j <= array.Length - 1; j++)
			{
				if (array[i] > array[j])
				{
					temp = array[i];
					array[i] = array[j];
					array[j] = temp;
					sort = array;
				}
			}
		}
		return array;
	}
}
