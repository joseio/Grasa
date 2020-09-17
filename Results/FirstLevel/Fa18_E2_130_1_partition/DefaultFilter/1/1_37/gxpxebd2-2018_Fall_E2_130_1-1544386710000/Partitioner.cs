

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotCounter = 0;
		int temp = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotCounter++;
				temp = values[i];
				values[i] = values[pivotCounter];
				values[pivotCounter] = temp;
			}
		}
		temp = values[pivotCounter];
		values[pivotCounter] = values[0];
		values[0] = temp;
		return pivotCounter;
	}
}