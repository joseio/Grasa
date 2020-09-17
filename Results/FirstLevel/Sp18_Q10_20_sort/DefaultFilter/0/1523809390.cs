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
		int n = array.Length;
		int[] narray = new int[n];
		for (int i = 0; i < n; i++)
		{
			narray[i] = array[i];
		}
		for (int i_1 = 0; i_1 < n; i_1++)
		{
			for (int j = 1; j < n - i_1; j++)
			{
				if (narray[j - 1] > narray[j])
				{
					int temp = narray[j - 1];
					narray[j - 1] = narray[j];
					narray[j] = temp;
				}
			}
		}
		return narray;
	}
}
