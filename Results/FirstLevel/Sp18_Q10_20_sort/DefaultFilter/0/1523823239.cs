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
		for (int i_1 = 0; i_1 < newArray.Length; i_1++)
		{
			for (int j = i_1 + 1; j < newArray.Length; j++)
			{
				if (newArray[i_1] > newArray[j])
				{
					int temp = newArray[i_1];
					newArray[i_1] = newArray[j];
					newArray[j] = temp;
				}
			}
		}
		return newArray;
	}
}
