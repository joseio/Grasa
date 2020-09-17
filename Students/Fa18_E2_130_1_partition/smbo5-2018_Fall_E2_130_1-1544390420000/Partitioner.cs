

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int position = 1;
		int temp;
		for (int i = 1; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				temp = values[i];
				values[i] = values[position - 1];
				values[position - 1] = temp;
				position++;
			}
		}
		temp = values[position - 1];
		values[position - 1] = pivot;
		pivot = temp;
		return position - 1;
	}
}