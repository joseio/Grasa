

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotTracker = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotTracker++;
				swap(values, i, pivotTracker);
			}
		}
		swap(values, 0, pivotTracker);
		return pivotTracker;
	}

	private static void swap(int[] val, int a, int b)
	{
		int temp = val[a];
		val[a] = val[b];
		val[b] = temp;
	}
}