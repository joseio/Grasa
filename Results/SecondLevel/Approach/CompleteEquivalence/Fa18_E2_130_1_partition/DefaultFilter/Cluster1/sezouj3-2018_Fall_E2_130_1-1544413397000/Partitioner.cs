

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int[] newarr = values;
		int i = 0;
		int j = values.Length - 1;
		for (int k = 1; k < newarr.Length; k++)
		{
			if (newarr[k] < pivot)
			{
				values[i] = newarr[k];
				i++;
			}
			else if (newarr[k] >= pivot)
			{
				values[j] = newarr[k];
				j--;
			}
			if (i >= j)
			{
				break;
			}
		}
		Console.WriteLine(pivot);
		foreach (int k in values)
		{
			Console.Write(k + " ");
		}
		Console.WriteLine();
		values[i] = pivot;
		return i;
	}
}