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
			int temp = array[i];
			int tempIndex = i;
			for (int j = i; j < array.Length; j++)
			{
				if (temp > array[j])
				{
					temp = array[j];
					tempIndex = j;
				}
			}
			array[tempIndex] = array[i];
			array[i] = temp;
		}
		return array;
	}
}
