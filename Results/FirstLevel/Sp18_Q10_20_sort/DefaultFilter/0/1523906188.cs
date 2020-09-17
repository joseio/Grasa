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
		int n = array.Length;
		for (int i = 0; i < n - 1; i++)
		{
			for (int j = 0; j < n - 1 - i; j++)
			{
				if (array[j] > array[j + 1])
				{
					int tem = array[j];
					array[j] = array[j + 1];
					array[j + 1] = tem;
				}
			}
		}
		return array;
	}
}
