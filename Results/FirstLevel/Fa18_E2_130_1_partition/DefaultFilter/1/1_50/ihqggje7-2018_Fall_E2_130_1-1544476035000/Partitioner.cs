

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		int pivotValue = values[pivotIndex];
		int tmp;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivotValue)
			{
				pivotIndex++;
				tmp = values[i];
				values[i] = values[pivotIndex];
				values[pivotIndex] = tmp;
			}
		}
		tmp = values[pivotIndex];
		values[pivotIndex] = values[0];
		values[0] = tmp;
		return pivotIndex;
	}
}