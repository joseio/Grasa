using System.Text.RegularExpressions;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Diagnostics;

namespace MetaProject
{
    [PexClass(typeof(MetaProgram))]
    public partial class MetaProgram
    {

        public class Program
        {
	    /// <summary>Return true if the array is sorted in descending order, false otherwise.</summary>
	        public static bool isSorted(int[] array)
	{
		int[] sorted = new int[array.Length];
		for (int x = 0; x < array.Length; x++)
		{
			sorted[x] = array[x];
		}
		int temp = 0;
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = 0; j < array.Length - 1; j++)
			{
				if (sorted[j] < sorted[j + 1])
				{
					temp = sorted[j];
					sorted[j] = sorted[j + 1];
					sorted[j + 1] = temp;
				}
			}
		}
		bool ans = true;
		for (int y = 0; y < array.Length; y++)
		{
			if (sorted[y] != array[y])
			{
				ans = false;
			}
		}
		return ans;
	}












































        public static bool isSortedSolution(int[] array)
	    {
		    int[] sorted = new int[array.Length];
            for (int x = 0; x < array.Length; x++)
            {
                sorted[x] = array[x];
            }
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (sorted[j] < sorted[j + 1])
                    {
                        temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            bool ans = true;
            for (int y = 0; y < array.Length; y++)
            {
                if (sorted[y] != array[y])
                {
                    ans = false;
                }
            }
            return ans;
        }













































































        public static bool isSortedSolutionForReal(int[] array)
        {
            int[] sorted = new int[array.Length];
            for (int x = 0; x < array.Length; x++)
            {
                sorted[x] = array[x];
            }
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (sorted[j] < sorted[j + 1])
                    {
                        temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            bool ans = true;
            for (int y = 0; y < array.Length; y++)
            {
                if (sorted[y] != array[y])
                {
                    ans = false;
                }
            }
            return ans;
        }
    }






























































        /*
        [PexMethod]
        public static void CheckDebug([PexAssumeNotNull]MetaProgram.List l, int x)
        {
            List l2 = l.Clone();
            int oldCount = l.Count();
            l.addToEndSolution(x);
            PexObserve.ValueForViewing("$next:", l.next != null ? l.next.ToString() : "null");
            PexAssert.IsTrue((oldCount + 1) == l.Count());
        } */
        [PexMethod]
        //[PexMethod(TestEmissionFilter = PexTestEmissionFilter.All)]
        public static void Check([PexAssumeNotNull]int[] arr)
        {
            /*
             This problem  ask students to solve a static method so we don't require cloning  or implementing
             an isEquals method for a class because static method don't require object instances in order to be called.
             */
            bool firstIndex = false;
            bool secondIndex = false;
            bool output = false;
            bool outputSolution = false;

            try
            {
                output = Program.isSorted(arr);

            }
            catch (IndexOutOfRangeException)
            {
                firstIndex = true;
            }

            try
            {
                outputSolution = Program.isSortedSolution(arr);
            }
            catch (IndexOutOfRangeException)
            {
                secondIndex = true;
            }


            //program passes under these scenarios
            // (1)both throw exception so firstIndex == secondIndex but since the programs don't terminate
            //and exit abnormally (exception), the the outputs are unchanged, outputSolution == output
            //(2) neither program fails (firstIndex == secondIndex), and must agree on output (outputSolution == output).
            bool passingCondition = (firstIndex == secondIndex  && firstIndex == true)||( firstIndex == secondIndex  && firstIndex == false && (outputSolution == output));
            /*negation of passing condition*/
            bool failingCondition = !passingCondition;

            if (failingCondition)
                throw new Exception();
        }



        }
    }
