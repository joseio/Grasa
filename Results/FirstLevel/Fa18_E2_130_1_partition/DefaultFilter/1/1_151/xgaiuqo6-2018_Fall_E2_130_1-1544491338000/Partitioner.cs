

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		int pivot = values[0];
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotIndex++;
				int tmp = values[i];
				for (int j = i; j > 0; j--)
				{
					values[j] = values[j - 1];
				}
				values[0] = tmp;
			}
		}
		return pivotIndex;
	}
}