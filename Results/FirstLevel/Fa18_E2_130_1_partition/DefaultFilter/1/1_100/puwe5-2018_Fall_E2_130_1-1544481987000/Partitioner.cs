

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		if (values.Length == 1)
		{
			return 0;
		}
		int low = 0;
		int high = values.Length;
		int pivot = values[low];
		int i = low;
		for (int j = 1; j < high; j++)
		{
			if (values[j] < pivot)
			{
				i++;
				int temp = values[i];
				values[i] = values[j];
				values[j] = temp;
			}
		}
		int tmp = values[i];
		values[i] = values[low];
		values[low] = tmp;
		return i;
	}
}