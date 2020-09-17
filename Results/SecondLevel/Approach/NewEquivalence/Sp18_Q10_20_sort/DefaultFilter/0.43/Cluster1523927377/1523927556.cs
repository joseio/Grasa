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
		for (int i = array.Length - 1; i >= 0; i--)
		{
			for (int j = i; j >= 0; j--)
			{
				if (array[i] > array[j])
				{
					int temp = array[j];
					array[j] = array[i];
					array[i] = array[j];
				}
			}
		}
		return array;
	}
}
