

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivotIndex = 0;
		int pointerIndex = pivotIndex + 1;
		int comp = 0;
		for (int i = pointerIndex; i < values.Length; i++)
		{
			if (values[i] < values[pivotIndex])
			{
				comp = values[i];
				values[i] = values[pointerIndex];
				values[pointerIndex] = comp;
				pointerIndex++;
			}
		}
		comp = values[pointerIndex - 1];
		values[pointerIndex - 1] = values[pivotIndex];
		values[pivotIndex] = comp;
		return pointerIndex - 1;
	}
}