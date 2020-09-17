

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = 0;
		for (int n = 1; n < values.Length; n++)
		{
			if (values[n] < values[pivot])
			{
				values = swap(values, pivot, n);
				pivot = n;
			}
			else
			{
				for (int p = pivot; p < values.Length; p++)
				{
					if (values[p] < values[pivot])
					{
						values = swap(values, pivot + 1, p);
						values = swap(values, pivot, n);
						pivot = n;
					}
				}
			}
		}
		return pivot;
	}

	private static int[] swap(int[] values, int n, int k)
	{
		int temp = values[n];
		values[n] = values[k];
		values[k] = temp;
		return values;
	}
}