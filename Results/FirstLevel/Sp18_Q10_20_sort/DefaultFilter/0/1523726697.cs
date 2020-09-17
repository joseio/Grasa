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
			for (int j = 0; j < i; j++)
			{
				int current = array[i];
				if (current < array[j])
				{
					array[i] = array[j];
					array[j] = current;
				}
			}
		}
		return array;
	}
}
