

public class Partitioner
{
	public static int partition(int[] array)
	{
		if (array == null || array.Length == 0)
		{
			return 0;
		}
		int pivotPosition = 0;
		int pivot = array[pivotPosition];
		int tmp;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < pivot)
			{
				pivotPosition++;
				tmp = array[pivotPosition];
				array[pivotPosition] = array[i];
				array[i] = tmp;
			}
		}
		tmp = array[pivotPosition];
		array[pivotPosition] = array[0];
		array[0] = tmp;
		return pivotPosition;
	}
}