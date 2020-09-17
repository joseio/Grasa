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

        public class LastTen
        {
        	public int[] tenArray = new int[10];
        	public virtual void add(int newValue)
        	{
        		for (int j = 0; j < 10; j++)
        		{
        			if (tenArray[j] == null)
        			{
        				tenArray[j] = newValue;
        				break;
        			}
        		}
        		if (tenArray[tenArray.Length - 1] != null)
        		{
        			for (int k = 0; k < 9; k++)
        			{
        				tenArray[k] = tenArray[k + 1];
        			}
        			tenArray[tenArray.Length - 1] = newValue;
        		}
        	}
        	public virtual int[] getLastTen()
        	{
        		int[] returnArray = new int[10];
        		for (int i = 0; i < returnArray.Length; i++)
        		{
        			returnArray[i] = 0;
        		}
        		for (int j = 0; j < returnArray.Length; j++)
        		{
        			returnArray[j] = this.tenArray[tenArray.Length - j - 1];
        		}
        		return returnArray;
        	}
        }




































        [PexMethod]
        public static void Check([PexAssumeNotNull] int[] inputArr, int x)
        {
            LastTen sub1Arr = new LastTen();
            sub1Arr.tenArray = inputArr;

            LastTenSolution sub2Arr = new LastTenSolution();
            sub2Arr.array = inputArr;

            LastTenSolutionForReal sub3Arr = new LastTenSolutionForReal();
            sub3Arr.array = inputArr;

            bool firstNull = false, secondNull = false;

            try
            {
                sub1Arr.add(x);
            }
            catch (IndexOutOfRangeException)
            {
                firstNull = true;
            }

            try
            {
                sub2Arr.add(x);
            }
            catch (IndexOutOfRangeException)
            {
                secondNull = true;
            }

            try
            {
                sub3Arr.add(x);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("addSolutionForReal got index out of range!");
            }


            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && sub2Arr.getLastTen().Equals(sub1Arr.getLastTen())));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
        }
    }























    public class LastTenSolution
    {
    	internal int[] array = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    	public virtual void add(int newValue)
    	{
    		for (int i = 0; i < 9; i++)
    		{
    			array[i] = array[i + 1];
    		}
    		array[10] = newValue;
    	}
    	public virtual int[] getLastTen()
    	{
    		return array;
    	}
    }


































    public class LastTenSolutionForReal
    {
        public int[] array = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public LastTenSolutionForReal()
        {
        }

        public virtual void add(int newValue)
        {
            for (int i = 0; i < 9; i++)
            {
                array[i] = array[i + 1];
            }
            array[9] = newValue;
        }

        public virtual int[] getLastTen()
        {
            return array;
        }
    }
}
