

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pIndex = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int temp = values[i];
				values[i] = values[pIndex];
				values[pIndex] = temp;
				pIndex++;
			}
		}
		int temp_1 = values[pIndex];
		values[pIndex] = pivot;
		pivot = temp_1;
		return pIndex;
	}
}