// <copyright file="BinaryTreeSolutionFactory.cs">Copyright ?  2014</copyright>

using System;
using Microsoft.Pex.Framework;
using MetaProject;

namespace MetaProject
{
    public static partial class BinaryTreeSolutionFactory
    {
        [PexFactoryMethod(typeof(BinaryTreeSolution.Node))]
        public static BinaryTreeSolution.Node CreateNode_string([PexAssumeNotNull] BinaryTreeSolution tree, [PexAssumeNotNull] string input)
        {
            BinaryTreeSolution.Node newNode = new BinaryTreeSolution.Node(tree, input);
            return newNode;
        }

        public static BinaryTreeSolution.Node CreateNode_double([PexAssumeNotNull] BinaryTreeSolution tree, [PexAssumeNotNull] double input)
        {
            BinaryTreeSolution.Node newNode = new BinaryTreeSolution.Node(tree, input);
            return newNode;
        }
    }
}
