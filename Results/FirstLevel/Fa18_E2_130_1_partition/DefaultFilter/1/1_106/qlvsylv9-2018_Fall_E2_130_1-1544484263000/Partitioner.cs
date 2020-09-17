

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int temp = 0;
		int i = -1;
		for (int j = 1; j < values.Length; j++)
		{
			if (values[j] < pivot)
			{
				i++;
				temp = values[i];
				values[i] = values[j];
				values[j] = temp;
			}
		}
		temp = values[i + 1];
		values[i + 1] = pivot;
		values[values.Length - 1] = temp;
		return (i + 1);
	}
}