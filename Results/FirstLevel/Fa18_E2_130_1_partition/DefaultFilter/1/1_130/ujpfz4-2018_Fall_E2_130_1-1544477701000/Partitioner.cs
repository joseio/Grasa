

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		if (values.Length == 0)
		{
			return 0;
		}
		int pivot = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[0])
			{
				pivot++;
				temp = values[i];
				values[i] = values[pivot];
				values[pivot] = temp;
			}
		}
		temp = values[0];
		values[0] = values[pivot];
		values[pivot] = temp;
		return pivot;
	}
}