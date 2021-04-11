using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        // Print 1-255
        public static void PrintNumbers()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }

        }

        // Print odd numbers between 1-255
        public static void PrintOdds()
        {
            var sum = 0;
            for (int i = 1; i < 255; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                    Console.WriteLine(i);
                }
            }
        }
        //Print Sum       
        public static void PrintSum()
        {
            var sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        //Iteration through an Array
        public static void LoopArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        //Find Max
        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine(max);
            return max;
        }

        //Get Average
        public static int GetAverage(int[] numbers)
        {
            int avg = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                avg += numbers[i];
            }
            Console.WriteLine(avg / numbers.Length);
            return avg / numbers.Length;
        }

        //Array with Odd Numbers
        public static int[] OddArray()
        {
            int[] odd = new int[255];
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 != 0)
                {
                    odd[i] = i;
                }
            }
            return odd;

        }

        //Greater than Y
        public static int GreaterThanY(int[] nums, int y)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);

            return count;
        }


        //Square the Values
        public static void SquareArrayValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * numbers[i];
            }

            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }

        public static void EliminateNegatives(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }
//Min, Max, Average
        public static void MinMaxAverage(int[] numbers)
        {
            int max = 0;
            int min = 0;
            int sum = 0;
            int avg = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                sum += numbers[i];
                avg = sum / numbers.Length;
                // int avg = sum / numbers.Length;
                // int[] all = { max, min, sum };

            }
            Console.WriteLine("[{0}]", string.Join(", ", min, max, sum, avg));
        }

//Shifting the values in an array
public static void ShiftValues(int[] numbers){
    int temp = 0;
    int lastNum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {   temp = numbers.Length-1;
       lastNum += temp;
       lastNum = 0;
            // Console.WriteLine(lastNum);

        // numbers += numbers.Length-1 = 0;
     } 
    Console.WriteLine("[{0}]", string.Join(", ", numbers));
        // Console.WriteLine(numbers.Length-1);
}

//Number to String
public static void NumToString(int[] numbers){
    string name ="Dojo";
// String numAsString = numbers.ToString();
for (int i = 0; i < numbers.Length; i++)
{
    if(numbers[i]<0){
        
        //numbers[i] = "Dojo"
    }
} Console.WriteLine(name);
// return name;


}
        public static void Main(string[] args)
        {
            int[] nums = { 4, 6, 7, 18, 90, 45, 32, 44 };
            int[] nums2 = { -4, 6, -7, 18, -90, 45, 32, -44 };

            // PrintNumbers();
            // PrintOdds();
            // PrintSum();
            // LoopArray(nums);
            // FindMax(nums);
            // GetAverage(nums);
            // OddArray();
            // GreaterThanY(nums, 0);
            // SquareArrayValues(nums);
            // EliminateNegatives(nums2);
            // MinMaxAverage(nums);
            // ShiftValues(nums);
            NumToString(nums2);
        }

    }
}
