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
		int len = array.Length;
		for (int i = 1; i < len; i++)
		{
			int key = array[i];
			int j = i - 1;
			while (j >= 0 && array[j] > key)
			{
				array[j + 1] = array[j];
				j--;
			}
			array[j + 1] = key;
		}
		return array;
	}
}
