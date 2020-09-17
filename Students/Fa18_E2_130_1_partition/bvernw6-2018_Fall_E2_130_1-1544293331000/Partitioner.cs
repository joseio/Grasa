

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
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				int tmp = values[i];
				values[i] = values[pivotPosition];
				values[pivotPosition] = tmp;
			}
		}
		int tmp_1 = values[0];
		values[0] = values[pivotPosition];
		values[pivotPosition] = tmp_1;
		return pivotPosition;
	}
}