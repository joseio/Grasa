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
		int fixes = 1;
		while (fixes > 0)
		{
			fixes = 0;
			for (int i_1 = 0; i_1 < array.Length - 1; i_1++)
			{
				if (newArray[i_1] > newArray[i_1 + 1])
				{
					int temp = newArray[i_1];
					newArray[i_1] = newArray[i_1 + 1];
					newArray[i_1 + 1] = temp;
					fixes++;
				}
			}
		}
		return newArray;
	}
}
