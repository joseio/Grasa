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
		int[] result = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			result[i] = array[i];
		}
		for (int index = 0; index < array.Length; index++)
		{
			int min = result[index];
			int minIndex = index;
			for (int i_1 = index; i_1 < array.Length; i_1++)
			{
				if (result[i_1] < min)
				{
					min = result[i_1];
					minIndex = i_1;
				}
			}
			int temp = result[index];
			result[index] = result[minIndex];
			result[minIndex] = temp;
		}
		return result;
	}
}
