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
		// boolean sorted = false;
		// while (!sorted) {
		//     sorted = true;
		//     for (int i = 0; i < array.length - 1; i++) {
		//         if (array[i] > array[i + 1]) {
		//             int tmp = array[i + 1];
		//             array[i] = array[i + 1];
		//             array[i + 1] = tmp;
		//         }
		//         sorted = false;
		//     }
		// }
		// return array
		for (int i = 0; i < array.Length; i++)
		{
			int a = array[i];
			for (int j = i; j > 0; j--)
			{
				if (array[j - 1] > array[j])
				{
					array[j] = array[j - 1];
					array[j - 1] = a;
				}
				else
				{
					break;
				}
			}
		}
		return array;
	}
}
