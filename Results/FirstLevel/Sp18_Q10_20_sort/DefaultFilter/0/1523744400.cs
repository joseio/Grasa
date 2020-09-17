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
		int[] newArray = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			newArray[i] = array[i];
		}
		for (int i_1 = 0; i_1 < array.Length; i_1++)
		{
			newArray = baseBubble(newArray);
		}
		return newArray;
	}

	public static int[] baseBubble(int[] array)
	{
		for (int j = 1; j < array.Length; j++)
		{
			if (array[j] < array[j - 1])
			{
				int temp = array[j - 1];
				array[j - 1] = array[j];
				array[j] = temp;
			}
		}
		return array;
	}
}
