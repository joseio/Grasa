

public class Partitioner
{
	public static int partition(int[] values)
	{
		// check for null or empty
		if (values == null || values.Length <= 1)
		{
			return 0;
		}
		int pivot = values[0];
		int lo = 1;
		int hi = values.Length - 1;
		while (true)
		{
			while (values[lo] < pivot && lo < values.Length - 1)
			{
				lo++;
			}
			while (values[hi] >= pivot && hi >= 1)
			{
				hi--;
			}
			if (lo >= hi)
			{
				break;
			}
			int tmp = values[hi];
			values[hi] = values[lo];
			values[lo] = tmp;
		}
		values[0] = values[hi];
		values[hi] = pivot;
		foreach (int i in values)
		{
			Console.printf(i + ", ");
		}
		Console.WriteLine();
		return hi;
	}
	/*public static int partition(int[] values) {
	if (values == null || values.length <= 1) {
	return 0;
	}
	int pivot = values[0];
	int lo = 1;
	int hi = values.length - 1;
	while (true) {
	if (lo < values.length - 2 && values[lo] < pivot) {
	lo++;
	}
	if (hi >= 2 && values[hi] >= pivot) {
	hi--;
	}
	if (hi <= lo) {
	break;
	}
	if (hi <= 0 || lo >= values.length) {
	break;
	}
	System.out.println("hi: " + hi + "|| lo: " + lo);
	int tmp = values[lo];
	values[lo] = values[hi];
	values[hi] = tmp;
	}
	values[0] = values[lo];
	values[lo] = pivot;
	return lo;
	}*/
}