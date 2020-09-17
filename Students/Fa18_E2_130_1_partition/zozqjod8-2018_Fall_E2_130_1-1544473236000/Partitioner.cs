

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPoint = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPoint++;
				int tmp = values[i];
				values[i] = values[pivotPoint];
				values[pivotPoint] = tmp;
			}
		}
		values[0] = values[pivotPoint];
		values[pivotPoint] = pivot;
		return pivotPoint;
	}
}