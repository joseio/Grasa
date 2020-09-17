

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null || values.Length == 0)
		{
			return 0;
		}
		int pivot = values[0];
		int pivotPosition = 0;
		int tempOut = 0;
		for (int i = 1; i < values.Length; i++)
		{
			if (values[i] < pivot)
			{
				pivotPosition++;
				int temp = values[pivotPosition];
				values[pivotPosition] = values[i];
				values[i] = temp;
			}
		}
		tempOut = values[pivotPosition];
		values[pivotPosition] = values[0];
		values[0] = tempOut;
		Console.Write(pivotPosition + ": ");
		foreach (int i in values)
		{
			Console.Write(i + ",");
		}
		Console.Write('\n');
		return pivotPosition;
	}
}