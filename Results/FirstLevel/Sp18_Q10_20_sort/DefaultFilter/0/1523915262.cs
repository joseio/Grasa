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
		if (array.Length == 0 || array.Length == 1)
		{
			return array;
		}
		else
		{
			int j = array.Length;
			while (j > 1)
			{
				for (int i = 1; i < j; i++)
				{
					if (array[i] < array[i - 1])
					{
						int temp = array[i];
						array[i] = array[i - 1];
						array[i - 1] = temp;
					}
				}
				j--;
			}
			return array;
		}
	}
}
