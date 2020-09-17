

public class Partitioner
{
	public static int partition(int[] arr)
	{
		if (arr == null || arr.Length <= 1)
		{
			return 0;
		}
		int par = arr[0];
		System.Collections.Generic.List<int> above = new System.Collections.Generic.List<
			int>();
		System.Collections.Generic.List<int> below = new System.Collections.Generic.List<
			int>();
		for (int x = 1; x < arr.Length; x++)
		{
			if (arr[x] >= par)
			{
				above.Add(arr[x]);
			}
			else
			{
				below.Add(arr[x]);
			}
		}
		for (int a = 0; a < below.Count; a++)
		{
			arr[a] = below[a];
		}
		arr[below.Count] = par;
		for (int b = below.Count + 1; b < arr.Length; b++)
		{
			arr[b] = above[b - (below.Count + 1)];
		}
		return below.Count;
	}
}