using System;

namespace Other
{
    class Program
    {
        //####################################################################################
        // Задача за лабиринта
        static char[,] lab =
        {
                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
        };

        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int position = 0;

        static void FindPath(int row, int col, char direction)
        {
            if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                // We are out of the labyrinth
                return;
            }

            // Append the direction to the path
            path[position] = direction;
            position++;

            // Check if we have found the exit
            if (lab[row, col] == 'е')
            {
                PrintPath(path, 1, position - 1);
            }

            if (lab[row, col] == ' ')
            {
                // The current cell is free. Mark it as visited
                lab[row, col] = 's';

                // Invoke recursion to explore all possible directions
                FindPath(row, col - 1, 'L'); // left
                FindPath(row - 1, col, 'U'); // up
                FindPath(row, col + 1, 'R'); // right
                FindPath(row + 1, col, 'D'); // down          

                // Mark back the current cell as free
                lab[row, col] = ' ';
            }

            // Remove the direction from the path
            position--;
        }

        static void PrintPath(char[] path, int startPos, int endPos)
        {
            Console.Write("Found path to the exit: ");

            for (int pos = startPos; pos <= endPos; pos++)
            {
                Console.Write(path[pos]);
            }

            Console.WriteLine();
        }

        //####################################################################################
        // Пермутации
        private static void Permute(string str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        public static string Swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        //####################################################################################
        // Ханойски кули
        private static void SolveTowers(int n, char startPeg, char endPeg, char tempPeg)
        {
            if (n > 0)
            {
                SolveTowers(n - 1, startPeg, tempPeg, endPeg);
                Console.WriteLine("Move disk from " + startPeg + ' ' + endPeg);
                SolveTowers(n - 1, tempPeg, endPeg, startPeg);

            }
        }

        static void Main(string[] args)
        {
            /* // Hanoi towers
           char startPeg = 'A'; // start tower in output
           char endPeg = 'C'; // end tower in output
           char tempPeg = 'B'; // temporary tower in output
           int totalDisks = 3; // number of disks
           SolveTowers(totalDisks, startPeg, endPeg, tempPeg);
           */

            /* // combinations // https://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
             String str = "ABC"; 
             int n = str.Length; 
             permute(str, 0, n-1); 
             */


            /* // Labirinth // https://introprogramming.info/intro-csharp-book/read-online/glava10-rekursia/
             FindPath(0, 0, 'S');
             */
            FindPath(0, 0, 'S');
        }
    }
}
