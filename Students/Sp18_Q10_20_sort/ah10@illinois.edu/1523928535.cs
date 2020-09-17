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
		int[] question = array;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 1; j < array.Length; j++)
			{
				if (question[i] > question[j])
				{
					int temp = question[j];
					question[j] = question[i];
					question[i] = temp;
				}
			}
		}
		return question;
	}
}
