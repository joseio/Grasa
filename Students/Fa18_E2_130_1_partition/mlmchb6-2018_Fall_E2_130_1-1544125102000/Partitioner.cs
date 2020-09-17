

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotValue = values[0];
		int pivot = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (pivotValue > values[i])
			{
				values[pivot] = values[i];
				values[i] = pivotValue;
				if (i > pivot + 1)
				{
					int tmp = pivot + 1;
					values[pivot + 1] = pivotValue;
					for (int j = pivot + 2; j < i; j++)
					{
						values[j] = values[j + 1];
					}
				}
				pivot++;
			}
		}
		return pivot;
	}
}