

public class Partitioner
{
	public static int partition(int[] array)
	{
		if (array == null)
		{
			return 0;
		}
		if (array.Length == 0)
		{
			return 0;
		}
		int pivot = array[0];
		int pivotPosition = 0;
		int tmp;
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i] < pivot)
			{
				pivotPosition++;
				tmp = array[i];
				array[i] = array[pivotPosition];
				array[pivotPosition] = tmp;
			}
		}
		tmp = array[pivotPosition];
		array[pivotPosition] = array[0];
		array[0] = tmp;
		return pivotPosition;
	}
}