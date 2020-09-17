

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = values[0];
		int j = values.Length;
		int temp;
		for (int i = values.Length - 1; i > 0; i--)
		{
			if (values[i] >= pivot)
			{
				j--;
				temp = values[i];
				values[i] = values[j];
				values[j] = temp;
			}
		}
		j--;
		temp = values[0];
		values[0] = values[j];
		values[j] = temp;
		return j;
	}
}