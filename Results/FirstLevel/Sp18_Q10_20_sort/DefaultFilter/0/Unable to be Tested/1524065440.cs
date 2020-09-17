using System;

public class Program
{
	/// <summary>Sort the array in ascending order.</summary>
	/// <remarks>
	/// Sort the array in ascending order.
	/// You may return either a reference to a new array or to the passed array.
	/// Note that you may not use java.util.Arrays.
	/// </remarks>
	public static bool isSorted(int[] array)
	{
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i] > array[i + 1])
			{
				return false;
			}
		}
		return true;
	}

	public static int[] sort(int[] arraya)
	{
		if (arraya.Length < 2)
		{
			return arraya;
		}
		int[] array = arraya;
		while (isSorted(array) == false)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] > array[i + 1])
				{
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
				}
			}
		}
		return array;
	}
}
