

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		int pivot = values[pivotIndex];
		int tmp = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotIndex++;
				tmp = values[pivotIndex];
				values[pivotIndex] = values[i];
				values[i] = tmp;
			}
		}
		tmp = values[0];
		values[0] = values[pivotIndex];
		values[pivotIndex] = tmp;
		return pivotIndex;
	}
}