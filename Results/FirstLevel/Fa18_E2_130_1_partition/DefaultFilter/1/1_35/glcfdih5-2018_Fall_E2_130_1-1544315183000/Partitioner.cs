

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int index = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				int temp = values[i];
				for (int x = i - 1; x >= 0; x--)
				{
					values[x + 1] = values[x];
				}
				values[0] = temp;
				index++;
			}
		}
		return index;
	}
}