

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int tmp;
		int pivot = values[0];
		int pivotPosition = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (pivot > values[i])
			{
				tmp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = tmp;
				pivotPosition++;
			}
		}
		tmp = values[pivotPosition];
		values[pivotPosition] = pivot;
		pivot = tmp;
		return pivotPosition;
	}
	//return pivot position 
}