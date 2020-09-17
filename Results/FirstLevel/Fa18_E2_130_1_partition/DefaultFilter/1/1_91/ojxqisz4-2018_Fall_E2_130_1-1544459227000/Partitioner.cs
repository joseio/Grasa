

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotIndex = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int temp = values[i];
				values[i] = values[pivotIndex];
				values[pivotIndex] = temp;
				pivotIndex++;
			}
		}
		int temp_1 = values[pivotIndex];
		values[pivotIndex] = pivot;
		pivot = temp_1;
		return pivotIndex;
	}
}