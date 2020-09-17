

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPos = 0;
		int tmp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPos++;
				tmp = values[pivotPos];
				values[pivotPos] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[pivotPos];
		values[pivotPos] = pivot;
		values[0] = tmp;
		return pivotPos;
	}
}