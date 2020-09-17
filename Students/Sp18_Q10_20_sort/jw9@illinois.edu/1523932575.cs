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
		int[] a = array;
		int temp = 0;
		for (int i = 0; i < a.Length; i++)
		{
			for (int j = 0; j < a.Length - 1; j++)
			{
				for (int k = j + 1; k < a.Length; k++)
				{
					if (a[j] > a[k])
					{
						temp = a[i];
						a[i] = a[j];
						a[j] = temp;
					}
				}
			}
		}
		return a;
	}
}
