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
		List temp = next;
		while (temp.next != null)
		{
			temp = temp.next;
		}
		List node = new List(newValue);
		temp.next = node;
		node.next = null;
		return;
	}




































































            public void addToEndSolution(int newValue)
	{
		List temp = next;
		while (temp.next != null)
		{
			temp = temp.next;
		}
		List node = new List(newValue);
		temp.next = node;
		node.next = null;
		return;
	}





















































            public void addToEndSolutionForReal(int newValue)
            {
                if (this.next == null)
                {
                    this.next = new List(newValue);
                }
                else
                {
                    this.next.addToEndSolutionForReal(newValue);
                }
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
                    return false;
                else // same length
                {
                    //Deep check
                    List current = this;
                    List temp = (List)obj;
                    while (current != null)
                    {
                        if (temp.value != current.value)
                            return false;
                        current = current.next;
                        temp = temp.next; //Iterate
                    }
                }
                return true;
            }
            public List Clone()
            {
                List temp = new List();

                List current = this;
                if (current.Count() == 0)
                    return temp;
                else if (current.Count() == 1)
                {
                    temp.value = current.value;
                    return temp;
                }
                else
                {
                    temp.value = current.value;
                    current = current.next;
                    while (current != null)
                    {
                        temp.addToEndSolutionForReal(current.value);
                        current = current.next;

                    }
                }
                return temp;
            }

        }




        //Test w/ factory method AND addToEnd MULT times!!
        [PexMethod]
        public static void Check([PexAssumeUnderTest]MetaProgram.List l, [PexAssumeUnderTest]MetaProgram.List l2, [PexAssumeUnderTest]MetaProgram.List l3, int x, Boolean b, int numIterations)
        {
            bool firstNull = false;
            bool secondNull = false;

            PexAssume.IsTrue(l.Equals(l2));
            PexAssume.IsTrue(l.Equals(l3));
            //Ensure that Pex generates three distinct MetaProgram.List objects
            PexAssume.AreNotSame(l, l2); 
            PexAssume.AreNotSame(l, l3); 


           // List l2 = l.Clone();
            //List l3 = l.Clone();


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

            try 
            {
                for (int j = 0; j < numIterations; j++)
                {
                    l3.addToEndSolutionForReal(x);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("addToEndSolutionForReal got  null refence exception!");
            }
            
            bool passingCondition = ((firstNull == secondNull && firstNull == true) || (firstNull == secondNull && firstNull == false && l2.Equals(l)));
            bool failingCondition = !passingCondition;
            if (failingCondition)
                throw new Exception("Student submission is equivalent to correct solution, but is not equal to reference submission.");
                
            //Implement Subsumption PUT
                //Purpose: Determine if subsumption exists across submissions in different child... 
                //...clusters within same parent cluster
            if (passingCondition)
            {
                if (b)
                {
                    if (l3.Equals(l))
                        if (!l2.Equals(l))
                            throw new Exception("Exception 1: Student submission is equivalent to correct solution, but is not equal to reference submission.");
                }
                else
                {
                    if (l3.Equals(l2))
                        if (!l2.Equals(l))
                            throw new Exception("Exception 2: Reference submission is equivalent to correct solution, but is not equal to student submission.");
                }
            }
        }
    }
}
