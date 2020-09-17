

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		bool swapped = true;
		while (swapped)
		{
			int tmp;
			swapped = false;
			for (int i = 0; i < values.Length - 1; i++)
			{
				if (values[i] > values[i + 1])
				{
					tmp = values[i + 1];
					values[i + 1] = values[i];
					values[i] = tmp;
					swapped = true;
				}
			}
		}
		int toReturn = 0;
		for (int i = 0; i < values.Length; i++)
		{
			if (pivot == values[i])
			{
				return i;
			}
		}
		return toReturn;
	}
}