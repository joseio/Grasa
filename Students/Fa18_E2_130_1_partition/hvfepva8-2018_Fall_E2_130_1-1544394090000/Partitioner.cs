

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int position = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				for (int j = i; j > position; j--)
				{
					int temp = values[j];
					values[j] = values[j - 1];
					values[j - 1] = temp;
				}
				position++;
			}
		}
		return position;
	}
}