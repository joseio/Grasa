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
		int n = array.Length;
		for (int i = 0; i < n; i++)
		{
			for (int k = 1; k < array.Length; k++)
			{
				if (array[k] < array[k - 1])
				{
					int temp = array[k - 1];
					array[k - 1] = array[k];
					array[k] = temp;
				}
			}
		}
		return array;
	}
}
