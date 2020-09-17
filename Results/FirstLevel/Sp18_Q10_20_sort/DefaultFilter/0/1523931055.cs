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
		int[] jiba = new int[array.Length];
		jiba = array;
		int temp = 0;
		for (int i = 1; i < jiba.Length; i++)
		{
			for (int j = i; j > 0; j--)
			{
				if (jiba[j] < jiba[j - 1])
				{
					temp = jiba[j];
					jiba[j] = jiba[j - 1];
					jiba[j - 1] = temp;
				}
			}
		}
		return jiba;
	}
}
