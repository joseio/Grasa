

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotP = values[0];
		int pivot = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivotP)
			{
				pivot++;
				temp = values[pivot];
				values[pivot] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pivot];
		values[pivot] = values[0];
		values[0] = temp;
		return pivot;
	}
}