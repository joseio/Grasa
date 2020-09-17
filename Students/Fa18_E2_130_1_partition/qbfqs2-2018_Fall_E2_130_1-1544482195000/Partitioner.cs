

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int j = values.Length - 1;
		int pivot = values[0];
		for (int i = values.Length - 1; i > 0; i--)
		{
			if (values[i] >= pivot)
			{
				int temp = values[i];
				values[i] = values[j];
				values[j] = temp;
				j--;
			}
		}
		int temp_1 = values[j];
		values[j] = values[0];
		values[0] = temp_1;
		return j;
	}
}