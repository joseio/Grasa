using System;
using Microsoft.Pex.Framework;
using MetaProject;

namespace MetaProject
{
    public static partial class MetaProgramFactory
    {
        [PexFactoryMethod(typeof(MetaProgram.List))]
        public static MetaProgram.List CreateList_Student([PexAssumeNotNull] int[] arr)
        {
            MetaProgram.List list = new MetaProgram.List();
            for (int i = 0; i < arr.Length; i++)
            {
                list.addToEnd(arr[i]); //Invoke students' addToEnd
            }
            return list;
        }

        [PexFactoryMethod(typeof(MetaProgram.List))]
        public static MetaProgram.List CreateList_Instructor([PexAssumeNotNull] int[] arr)
        {
            MetaProgram.List list = new MetaProgram.List();
            for (int i = 0; i < arr.Length; i++)
            {
                list.addToEndSolutionForReal(arr[i]); //Invoke instructor's addToEnd
            }
            return list;
        }
    }
}
