

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotIndex = 0;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				temp = values[i];
				values[i] = values[pivotIndex];
				values[pivotIndex] = temp;
				pivotIndex++;
			}
		}
		temp = values[pivotIndex];
		values[pivotIndex] = pivot;
		pivot = temp;
		return pivotIndex;
	}
}