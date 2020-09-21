using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Individual_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6}; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            //3, 1, 4, 1, 5
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "gouwashajhaslls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }
// This procedure creates a trianle of x lines of astoisks
        public static void PrintTriangle(int x)
        {
            try
            {
                // for loop that runs for the number of lines needed
                for (int i = 0; i <= x; i++)
                {
                    //for loop to print the number of spaces necessary to centralize the astorisks as needed
                    for (int j = 1; j <= x - i; j++)
                        Console.Write(" ");
                    //for loop for printing the number of astorisks needed for each corresponding x line
                    //each additional line produces incremental odd number of astorisks ie. 1,3,5,7 etc. hence the second agument in the for loop
                    for (int j = 1; j <= 2 * i - 1; j++)
                        Console.Write("*");
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            // Intializing three variables:
            //count to track the number of odd numbers collected
            //i to incremement the number being checked
            //sum to add the odd numbers needed
            int count = 0;
            int i = 0;
            int sum = 0;
            try
            {
                //while loop which stops when the number of odd numbers needed is reached
                while (count < n)
                {
                    //check variable uses the mod function to determine whether a number is odd
                    int check = i % 2;
                    //if statement ensures that only odd numbers are included
                    if (check == 1){
                        //increments the number of odd numbers collected
                        count++;
                        //adds selected odd number to the sum variable
                        sum = sum + i;
                    }
                    //increments the number ie. 1 -> 2 ->3 ->4 etc
                    //alternatively i could be incremented by two and the check for odd numbers could be removed
                    //current method allows for easier scalabily or subtle changes if necessary
                    i++;
                }
                Console.Write("The sum of he numbers is, "+sum);
                Console.Write("\n");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                // Checks for length of array
                int len = n.Length;
                //incrementer for for loops
                int x = 0;
                //count the number of increasing steps
                int counti = 1;
                //counts the number of decreasing steps
                int countd = 1;
                //checking for increasing steps
                for (x = 0; x < len-1; x++)
                {
                    if (n[x] <= n[x + 1]){
                        countd++;
                    }
                }
                //checing for decreasing steps
                for (x = 0; x < len - 1; x++)
                {
                    if (n[x] >= n[x + 1])
                    {
                        counti++;
                    }
                }
                //returns true if the number of decreasing or increasing steps is one less than the length of the array
                //one less since 2 varaibles are compared in each step
                if (counti == len | countd == len)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            //initializes counter varaiable 
            int count = 0;
            //removes any duplicate values within the array thus preventing any duplicate pairs from being counted
            J = J.Distinct().ToArray();
            try
            {
                //starts for loop from first position
                for (int i = 0; i< J.Length; i++)
                {
                    //initializes for loop from next available position to ensure no double counting
                    for (int x = i+1; x< J.Length; x++)
                    {
                        int diff = J[i] - J[x];
                        if (Math.Abs(diff) == k)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {
            
            try
            {
                char[] keys = keyboard.ToCharArray();
                char[] wrd = word.ToCharArray();
                int diff = 0;
                //calculating diff
                int posO =0;
                int posN = 0;
                
                for (int i = 0; i < wrd.Length; i++)
                {
                    int x = 0;
                    //finds the index of the character in the keyboard array
                    while (wrd[i] != keys[x])
                    {
                        //increment the index
                        x++;
                        //increment the position
                        posN++;
                    }
                    //add the difference between the new positions
                    diff = diff + Math.Abs(posN - posO);
                    //set the current position to the old position
                    posO = posN;
                    //reset the new position
                    posN = 0;
                }
                return diff;
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                // based upon the LevenshteinDistance algorithm 

                int l1 = str1.Length;
                int l2 = str2.Length;
                int[,] d = new int[l1 + 1, l2 + 1];

                // if the length of the source is zero, the total number of characters in the target varaible needs to be added
                if (l1 == 0)
                {
                    return l2;
                }
                //if the length of the target is zero, the total number of characters in the source varaible needs to be removed
                if (l2 == 0)
                {
                    return l1;
                }

                //fill a 2 dimensional matrix with a sequence of numbers
                //populate based on the length of the source word
                for (int i = 0; i <= l1; d[i, 0] = i++)
                {
                }
                //populate based on the length of the target word
                for (int j = 0; j <= l2; d[0, j] = j++)
                {
                }
                //start comparing source and target arrays and checking for differences
                for (int i = 1; i <= l1; i++)
                {
                    for (int j = 1; j <= l2; j++)
                    {
                        //if there are any differences between source and target arrays add to cost 
                        int cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;

                            d[i, j] = Math.Min( Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                    }
                }
                //reeturn the value from the two dimensional matrix matching respective index
                return d[l1, l2];
            }
            
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}
