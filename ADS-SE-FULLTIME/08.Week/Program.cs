using System;

namespace _08.Week
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the binary tree from the sample

            BinarySearchTree<int> binaryTree =

                  new BinarySearchTree<int>(14,

                              new BinarySearchTree<int>(19,

                                          new BinarySearchTree<int>(23),

                                          new BinarySearchTree<int>(6,

                                                      new BinarySearchTree<int>(10),

                                                      new BinarySearchTree<int>(21))),

                              new BinarySearchTree<int>(15,

                                          new BinarySearchTree<int>(3),

                                          null));



            // Traverse and print the tree in in-order manner

            binaryTree.PrintInorder();

            // Console output:

            // 23 19 10 6 21 14 3 15
        }
    }
}
