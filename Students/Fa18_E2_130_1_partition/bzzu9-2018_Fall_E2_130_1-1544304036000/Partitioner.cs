

public class Partitioner
{
	//increment then swap
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int temp;
		int pivotIndex = 0;
		int pivot = values[0];
		for (int currentIndex = 1; currentIndex < values.Length; currentIndex++)
		{
			if (values[currentIndex] < pivot)
			{
				pivotIndex++;
				temp = values[pivotIndex];
				values[pivotIndex] = values[currentIndex];
				values[currentIndex] = temp;
			}
		}
		temp = values[pivotIndex];
		values[pivotIndex] = values[0];
		values[0] = temp;
		return pivotIndex;
	}
}