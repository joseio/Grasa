

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < values[pivotIndex])
			{
				for (int j = i; j > pivotIndex; j--)
				{
					int temp = values[j];
					values[j] = values[j - 1];
					values[j - 1] = temp;
				}
				pivotIndex++;
			}
		}
		return pivotIndex;
	}
}