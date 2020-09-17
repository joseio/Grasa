

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotPosition = 0;
		int pivot = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int tmp = values[pivotPosition + 1];
				values[pivotPosition + 1] = values[i];
				values[i] = tmp;
				pivotPosition++;
			}
		}
		int tmp_1 = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[0] = tmp_1;
		return pivotPosition;
	}
}