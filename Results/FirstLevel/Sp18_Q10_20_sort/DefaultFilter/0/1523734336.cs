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
		for (int i = 1; i < array.Length; i++)
		{
			int comp = array[i];
			int j = i - 1;
			while (j >= 0 && array[j] > comp)
			{
				array[j + 1] = array[j];
				j--;
			}
			array[j + 1] = comp;
		}
		return array;
	}
}
