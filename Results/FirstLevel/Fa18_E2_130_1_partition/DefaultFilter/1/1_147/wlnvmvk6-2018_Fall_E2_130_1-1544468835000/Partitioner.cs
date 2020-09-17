

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotP = 0;
		for (int k = 1; k < values.Length; k++)
		{
			if (values[k] < pivot)
			{
				pivotP++;
				swap(values, k, pivotP);
			}
		}
		swap(values, 0, pivotP);
		return pivotP;
	}

	public static void swap(int[] values, int first, int second)
	{
		int temp = values[first];
		values[first] = values[second];
		values[second] = temp;
	}
}