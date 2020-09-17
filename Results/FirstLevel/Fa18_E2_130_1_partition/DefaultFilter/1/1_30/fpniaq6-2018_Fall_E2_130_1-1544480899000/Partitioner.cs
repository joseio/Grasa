

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		if (values.Length == 1)
		{
			return 0;
		}
		int pivot = 1;
		int pivotValue = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				int c = values[i];
				values[i] = values[pivot];
				values[pivot] = c;
				pivot++;
			}
		}
		pivot--;
		int c_1 = values[0];
		values[0] = values[pivot];
		values[pivot] = c_1;
		return pivot;
	}
}