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
		if (array == null)
		{
			return null;
		}
		int[] array1 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array1[i] = array[i];
		}
		for (int i_1 = 0; i_1 < array.Length; i_1++)
		{
			for (int j = 0; j < array.Length - i_1 - 1; j++)
			{
				if (array1[j] > array1[j + 1])
				{
					int temp = array1[j];
					array1[j] = array1[j + 1];
					array1[j + 1] = temp;
				}
			}
		}
		return array1;
	}
}
