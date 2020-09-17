

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[pivot])
			{
				int temp = values[pivot];
				values[pivot] = values[i];
				values[i] = temp;
				if (values[pivot + 1] > values[i])
				{
					temp = values[pivot + 1];
					values[pivot + 1] = values[i];
					values[i] = temp;
				}
				pivot++;
			}
		}
		return pivot;
	}
}