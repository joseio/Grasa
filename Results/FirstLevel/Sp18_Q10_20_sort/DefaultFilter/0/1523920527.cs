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
		int[] newArray = array;
		int tmp = 0;
		for (int i = 0; i < array.Length - 1; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (newArray[i] > newArray[j])
				{
					tmp = newArray[i];
					newArray[i] = newArray[j];
					newArray[j] = tmp;
				}
			}
		}
		return newArray;
	}
}
