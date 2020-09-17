

public class Partitioner
{
	public static void swap(int[] values, int one, int two)
	{
		int temp = values[one];
		values[one] = values[two];
		values[two] = temp;
	}

	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPos = 0;
		int pivot = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				pivotPos++;
				swap(values, i, pivotPos);
			}
		}
		swap(values, 0, pivotPos);
		return pivotPos;
	}
}