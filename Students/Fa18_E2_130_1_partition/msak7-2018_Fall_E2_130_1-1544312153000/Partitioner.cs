

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPosition = 0;
		int tem = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				tem = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = tem;
			}
		}
		tem = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[0] = tem;
		return pivotPosition;
	}
}