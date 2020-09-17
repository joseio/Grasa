

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int x = 0;
		int pivot = values[0];
		if (values.Length == 1)
		{
			return 0;
		}
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				moveUp(values, i);
				x++;
			}
		}
		return x;
	}

	public static void moveUp(int[] array, int count)
	{
		int save = array[count];
		for (int i = count; i > 0; i--)
		{
			array[i] = array[i - 1];
		}
		array[0] = save;
	}
}