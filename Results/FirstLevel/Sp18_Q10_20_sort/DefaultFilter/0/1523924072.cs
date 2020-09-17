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
		for (int m = 0; m <= array.Length; m++)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				int k = i + 1;
				if (newArray[i] > newArray[k])
				{
					int temp = newArray[i];
					newArray[i] = newArray[k];
					newArray[k] = temp;
				}
			}
		}
		return newArray;
	}
}
