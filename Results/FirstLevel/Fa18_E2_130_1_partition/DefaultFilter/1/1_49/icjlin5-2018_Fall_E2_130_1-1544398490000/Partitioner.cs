

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int l = values.Length;
		int pivotPosition = 0;
		int pivot = values[pivotPosition];
		int temp;
		for (int i = 1; i < l; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				temp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = temp;
			}
		}
		temp = values[pivotPosition];
		values[pivotPosition] = pivot;
		values[0] = temp;
		return pivotPosition;
	}
}