/* ---------------------------------------------------------------------------------- */
/* Write a program in C# Sharp to count the frequency of each element of an array     */
/* Created by: Ami Purohit                                                            */
/* Date Created: 2019-11-09                                                           */
/* ---------------------------------------------------------------------------------- */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {

        struct frequncyNumbers
        {
            public int number;
            public int count;

        }


        static void Main(string[] args)
        {

            int[] numArray = new int[] { 22, 33, 44, 33, 55, 66, 77, 88, 55, 55, 0, 0, 1 };

            // count the frequency of each element of an array 
            FindFrequncyUniqueElements(numArray);

        }


        public static void FindFrequncyUniqueElements(int [] numbers)
        {
            

            frequncyNumbers[] frNumbers = new frequncyNumbers[numbers.Length];
            int counter = 0;
            bool foundNumber = false;

            

            // check for each numbers if it contains in result(uniqueArray)
            for (int i = 0; i < numbers.Length; i++)
            {

                // check if number already exist in structer
                for (int j = 0; j< counter; j++) { 
                    if (frNumbers[j].number == numbers[i])
                    {
                        // Increase counter
                        frNumbers[j].count++;
                        foundNumber = true;
                    }                
                }

                // if number does not exist 
                if (!foundNumber)
                {
                    //add new data to next new structer in array
                    frNumbers[counter].number = numbers[i];
                    frNumbers[counter].count ++ ;
                    counter++;
                }

                // setflag to false
                foundNumber = false;

            }

            // resize struct array
            System.Array.Resize(ref frNumbers, counter);

            //display frequency of each element of an array 
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            foreach (frequncyNumbers i in frNumbers)
            {
                Console.WriteLine("Number " + i.number + " contains " + i.count + " times.");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");

        }
    }
}
