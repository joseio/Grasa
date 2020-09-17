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
		int tempj;
		int tempi;
		int[] sor = array;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 1; j < array.Length - i; j++)
			{
				if (sor[j + i] < sor[i])
				{
					tempj = sor[i];
					tempi = sor[j + i];
					sor[j + i] = tempj;
					sor[i] = tempi;
				}
			}
		}
		return sor;
	}
}
