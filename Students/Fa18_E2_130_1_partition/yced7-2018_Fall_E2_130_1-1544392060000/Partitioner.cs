

public class Partitioner
{
	public static int partition(int[] values)
	{
		if (values == null)
		{
			return 0;
		}
		Console.Write("[ ");
		foreach (int current in values)
		{
			Console.Write(current + " ");
		}
		Console.Write("] ");
		int pivotIndex = 0;
		for (int i = pivotIndex; i < values.Length; i++)
		{
			Console.WriteLine(values[pivotIndex]);
			if (values[i] < values[pivotIndex])
			{
				refactor(values, i);
				pivotIndex++;
				i = pivotIndex;
			}
		}
		Console.WriteLine("index = " + pivotIndex);
		return pivotIndex;
	}

	private static void refactor(int[] array, int toMove)
	{
		int tempMoved = array[toMove];
		for (int i = toMove; i > 0; i--)
		{
			array[i] = array[i - 1];
		}
		array[0] = tempMoved;
	}
}