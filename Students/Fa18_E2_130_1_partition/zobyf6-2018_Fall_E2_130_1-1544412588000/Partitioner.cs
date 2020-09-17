

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int start = 0;
		int end = values.Length;
		int i = end;
		int pivot = values[start];
		for (int j = end - 1; j > start; j--)
		{
			if (values[j] >= pivot)
			{
				i--;
				int temp = values[i];
				values[i] = values[j];
				values[j] = temp;
			}
		}
		int temp_1 = values[i - 1];
		values[i - 1] = pivot;
		values[start] = temp_1;
		return i - 1;
	}
}