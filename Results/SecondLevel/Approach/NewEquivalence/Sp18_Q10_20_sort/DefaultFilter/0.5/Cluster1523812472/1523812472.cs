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
		for (int i = 0; i < newArray.Length; i++)
		{
			int max = i;
			for (int j = i + 1; j < newArray.Length; j++)
			{
				if (newArray[max] < newArray[j])
				{
					max = j;
				}
			}
			int tmp = newArray[max];
			newArray[max] = newArray[i];
			newArray[i] = tmp;
		}
		return newArray;
	}
}
