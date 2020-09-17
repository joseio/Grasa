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

        public class List
        {
            private int value;
            private List next;

            public List() { }

            public List(int setValue)
            {
                value = setValue;
            }

            /**
            * Add a value as the last item in the list.
            *
            * Can be called on any item of the list, although will normally be called
            * on the first item.
                       */
            public void addToEnd(int newValue)
	{
        if (next == null)
        {
            next = new List(newValue);
            return;
        }
        List current = next;
        for (; current.next != null; current = current.next)
        {
            List second = current.next;
            if (second.next == null)
            {
                second.next = new List(newValue);
                return;
            }
        }
        return;
	}










































            public void addToEndSolution(int newValue)
            {
                List count = this;
                while (count.next != null)
                {
                    count = count.next;
                }
                count.next = new List(newValue);
                return;
            }

            //Doesn't change for First level
            public void addToEndSolutionForReal(int newValue)
            {
                List count = this;
                while (count.next != null)
                {
                    count = count.next;
                }
                count.next = new List(newValue);
                return;
            }










            public int Count()
            {
                int count = 0;

                List current = this;
                while (current != null)
                {
                    count++;
                    current = current.next;
                }
                return count;
            }

            public override bool Equals(object obj)
            {
                //If not a list
                if (!(obj is List))
                    return false;

                if (((List)obj).Count() != this.Count())
                {
                    return false;
                }
                //Same length
                else
                {
                    //Deep check
                    List current = this;
                    List temp = (List)obj;
                    while (current != null)
                    {
                        //Iterate  
                        if (temp.value != current.value)
                            return false;
                        current = current.next;
                        temp = temp.next;
                    }
                }
                return true;
            }
        }



        //Testing calling addToEnd MULT times, 04/21/19
[PexMethod]
        public static void Check([PexAssumeUnderTest] MetaProgram.List l, [PexAssumeUnderTest] MetaProgram.List l2, int x, int numIterations)
        {
            //Use PexAssume.IsTrue instead of Clone(), as not to give Pex any issues
            PexAssume.IsTrue(l.Equals(l2));
            //Ensure that Pex generates two distinct MetaProgram.List objects
            PexAssume.AreNotSame(l, l2); 

            bool firstNull = false;
            bool secondNull = false;

            try
            {
                for (int i = 0; i < numIterations; i++)
                {
                    l.addToEnd(x);
                }
            }
            catch (NullReferenceException)
            {
                firstNull = true;
            }

            try
            {
                for (int j = 0; j < numIterations; j++)
                {
                    l2.addToEndSolution(x);
                }
            }
            catch (NullReferenceException)
            {
                secondNull = true;
            }

            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && l2.Equals(l)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception();
        }
    }
}
