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
		int[] array1 = new int[array.Length];
		for (int p = 0; p < array.Length; p++)
		{
			array1[p] = array[p];
		}
		for (int i = 1; i < array1.Length; i++)
		{
			int j = i - 1;
			int key = array1[i];
			while (j >= 0 && key < array1[j])
			{
				int temp = array1[j];
				array1[j] = array1[j + 1];
				array1[j + 1] = temp;
				j--;
			}
		}
		return array1;
	}
}
