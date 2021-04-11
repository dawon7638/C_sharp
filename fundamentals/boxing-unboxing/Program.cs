using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> myNewList = new List<object>();
            myNewList.Add(7);
            myNewList.Add(28);
            myNewList.Add(-1);
            myNewList.Add(true);
            myNewList.Add("chair");
            int addNums = 0;

            for (var i = 0; i < myNewList.Count; i++)
            {
                Console.WriteLine(" " + myNewList[i]);
                if (myNewList[i] is int)
                {
                    addNums += (int)myNewList[i];
                }
            }
            Console.WriteLine(addNums);
        }
    }
}
