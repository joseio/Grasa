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
		int a = 0;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 1; j < array.Length; j++)
			{
				if (array[j - 1] > array[j])
				{
					a = array[j];
					array[j] = array[j - 1];
					array[j - 1] = a;
				}
			}
		}
		return array;
	}
}
