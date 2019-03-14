using System;
using System.Collections.Generic;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass<int> intObj = new TestClass<int>();

            intObj.Add(1);
            intObj.Add(2);
            intObj.Add(3);
            intObj.Add(4);
            intObj.Add(5);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(intObj[i]);
            }

            Console.ReadLine();
        }
    }


    public class TestClass<T>
    {
        T[] obj = new T[5];
        int count = 0;

        public void Add(T item)
        {
            if (count + 1 < 6)
            {
                obj[count] = item;
            }

            count++;
        }

        public T this[int index]
        {
            get { return obj[index]; }
            set { obj[index] = value; }
        }
    }
}
