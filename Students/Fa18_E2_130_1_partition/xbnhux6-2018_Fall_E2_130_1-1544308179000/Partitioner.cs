

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
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				if (i - pivotIndex == 1)
				{
					values[pivotIndex] = values[i];
					values[i] = pivot;
					pivotIndex++;
				}
				else
				{
					values[pivotIndex] = values[pivotIndex + 1];
					values[pivotIndex + 1] = pivot;
					int temp = values[pivotIndex];
					values[pivotIndex] = values[i];
					values[i] = temp;
					pivotIndex++;
				}
			}
		}
		return pivotIndex;
	}
}