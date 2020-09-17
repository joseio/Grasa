using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaProject;
using Microsoft.Pex.Framework;

namespace MetaProject
{
    public static partial class MetaProgramFactory
    {
        //Factory for SubmissionA
        [PexFactoryMethod(typeof(MetaProgram.BinaryTree))]
        public static MetaProgram.BinaryTree CreateBinaryTree([PexAssumeNotNull] double[] arr)
        {
            MetaProgram.BinaryTree tree = new MetaProgram.BinaryTree();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.add(arr[i]);
            }
            return tree;
        } 

        //Factory for SubmissionB
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolution))]
        public static MetaProject.BinaryTreeSolution CreateBinaryTreeSolution([PexAssumeNotNull] double[] arr)
        {
            MetaProject.BinaryTreeSolution tree = new MetaProject.BinaryTreeSolution();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.add(arr[i]);
            }
            return tree;
        } 

        //Factory for Instructor Solution
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolutionForReal))]
        public static MetaProject.BinaryTreeSolutionForReal CreateBinaryTreeSolutionForReal([PexAssumeNotNull] double[] arr)
        {
            MetaProject.BinaryTreeSolutionForReal tree = new MetaProject.BinaryTreeSolutionForReal();
            for (int i = 0; i < arr.Length; i++)
            {
                tree.add(arr[i]);
            }
            return tree;
        } 
	}
}
