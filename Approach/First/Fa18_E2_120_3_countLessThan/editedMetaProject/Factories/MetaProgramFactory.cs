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
        //Factory for SubmissionA w/ double[] input arg
        [PexFactoryMethod(typeof(MetaProgram.BinaryTree))]
        public static MetaProgram.BinaryTree CreateBinaryTree_double(double val1)
        {
            //Make tree
            MetaProgram.BinaryTree tree = new MetaProgram.BinaryTree();

            tree.root = new MetaProgram.BinaryTree.Node(tree, val1);
            //tree.root.left = null;
            //tree.root.right = null;

            return tree;
        }

        /*
        //Factory for SubmissionA w/ string input arg
        [PexFactoryMethod(typeof(MetaProgram.BinaryTree))]
        public static MetaProgram.BinaryTree CreateBinaryTree_string([PexAssumeNotNull] String val1)
        {
            MetaProgram.BinaryTree tree = new MetaProgram.BinaryTree();
            tree.root = new MetaProgram.BinaryTree.Node(tree, val1);
            return tree;
        }
        */

        //Factory for SubmissionB w/ double[] input arg
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolution))]
        public static MetaProject.BinaryTreeSolution CreateBinaryTreeSolution_double(double val1)
        {
            //Make tree
            BinaryTreeSolution tree = new BinaryTreeSolution();

            tree.root = new BinaryTreeSolution.Node(tree, val1);
            return tree;
        }

        
        //Factory for SubmissionB w/ string input arg
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolution))]
        public static MetaProject.BinaryTreeSolution CreateBinaryTreeSolution_string([PexAssumeNotNull] MetaProject.BinaryTreeSolution.Node root)
        {
            MetaProject.BinaryTreeSolution tree = new MetaProject.BinaryTreeSolution();
            tree.root = root;
            return tree;
        }
        
        
        //Factory for Instructor Solution w/ double[] input arg
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolutionForReal))]
        public static MetaProject.BinaryTreeSolutionForReal CreateBinaryTreeSolutionForReal_double(double val1)
        {
            //Make tree
            BinaryTreeSolutionForReal tree = new BinaryTreeSolutionForReal();

            tree.root = new BinaryTreeSolutionForReal.Node(tree, val1);
            return tree;
        }
        

        /*
        //Factory for Instructor Solution w/ string input arg
        [PexFactoryMethod(typeof(MetaProject.BinaryTreeSolutionForReal))]
        public static MetaProject.BinaryTreeSolutionForReal CreateBinaryTreeSolutionForReal_string([PexAssumeNotNull] MetaProject.BinaryTreeSolutionForReal.Node root)
        {
            MetaProject.BinaryTreeSolutionForReal tree = new MetaProject.BinaryTreeSolutionForReal();
            tree.root = root;
            return tree;
        }*/











        /*[PexFactoryMethod(typeof(MetaProgram.BinaryTree.Node))] //Pex-generated
        public static Object CreateBinaryTreeNode_string([PexAssumeNotNull] string string1)
        {
            //Binary tree property: left < root < right...string2 < string1 < string3
            //PexAssume.IsTrue(string1.CompareTo(string2) > 0); //string1 > string2 (aka string2 comes first, alphabetically)
           // PexAssume.IsTrue(string1.CompareTo(string3) < 0); //string1 < string3 (aka string1 comes first, alphabetically)

            MetaProgram.BinaryTree.Node node = new MetaProgram.BinaryTree.Node(tree, string1);
            tree.root.left = null;
            tree.root.right = null;
            return tree.root;
        }

        [PexFactoryMethod(typeof(MetaProgram.BinaryTree.Node)] //Pex-generated
        public static Object CreateBinaryTreeNode_double([PexAssumeUnderTest] MetaProgram.BinaryTree tree,
            [PexAssumeNotNull] double val1)
        {
            //Binary tree property: left < root < right...val2 < val1 < val3
            //PexAssume.IsTrue(val1 > val2 && val1 < val3); 

            tree.root = new MetaProgram.BinaryTree.Node(tree, val1);
            tree.root.left = null;
            tree.root.right = null;
            return tree.root;
        } */
    }
}
