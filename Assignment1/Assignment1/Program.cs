/*  ---------------------------------------------------------------------  */
/*  Write a program in C# Sharp to print all unique elements in an array   */
/*  Created by : Ami Purohit                                               */
/*  Date created : 2019-11-09                                              */
/* ----------------------------------------------------------------------- */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numArray = new int[] { 22, 33, 44, 33, 55, 66, 77, 88, 55, 55,  1};

            FindUniqueElements(numArray);

            

        }

        public static void FindUniqueElements (int [] numbers)
        {
            int[] uniqueNumbers = new int[numbers.Length];
            int count = 0;

            // check if array contains any 0 values, add to the result (uniqueArray)
            if (numbers.Contains(0))
            {
                uniqueNumbers[count++] = 0;
            }

            // check for each numbers if it contains in result(uniqueArray)
            for ( int i =0; i < numbers.Length; i++)
            {
                if (!uniqueNumbers.Contains(numbers[i] ) )
                {                   
  
                    uniqueNumbers[count++] = numbers[i];
                }

            }

            
            System.Array.Resize(ref uniqueNumbers, count);

            Console.WriteLine("----------------------------");
            Console.WriteLine();
            foreach (int i in uniqueNumbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }
    }
}
