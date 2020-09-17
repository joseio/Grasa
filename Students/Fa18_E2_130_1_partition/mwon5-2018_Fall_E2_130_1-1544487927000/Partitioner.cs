

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = 0;
		int pivotValue = values[pivot];
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
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