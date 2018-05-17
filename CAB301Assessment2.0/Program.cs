using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CAB301Assignment2
{
    class Program
    {
        // We store the result to a global variable to prevent the compiler from
        // optimizing out the call to search, since it doesn't modify any data.
        const int N = 10000;
        static int[] results = new int[N];


        static int BruteForceMedian(int[] A)
        {
            int n = A.Length;
            double k = n / 2.0;
            k = Math.Ceiling(k);
            //Console.WriteLine("k {0}, n, {1}", k, n );

            for (int i = 0; i < n; i++)
            {
                int numsmaller = 0; //How many elements are smaller than A[i]
                int numequal = 0; //How many elements are equal to A[i]
                for (int j = 0; j < n; j++)
                {
                    if (A[j] < A[i])
                    {
                        numsmaller++;
                    }
                    else
                    {
                        if (A[j] == A[i])
                        {
                            numequal++;
                        }
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal))
                {
                   
                    return A[i];
                }
            }
            return -1;
        }

        static int Median(int[] A)
        {
            int n = A.Length;
            double k = n / 2.0;
            k = Math.Floor(k);
            int intK = (int)k;
            //Console.WriteLine("k {0}, n, {1}", intK, n);

            if (n == 1)
            {
                //Console.WriteLine("A {0}", A[0]);
                return A[0];
            }
            else
            {
                //Console.WriteLine("A {0}", Select(A, 0, intK, n - 1));
                return Select(A, 0, intK, n - 1);
            }
        }

        static int Select(int[] A, int l, int m, int h)
        {
            int pos = Partition(A, l, h);
            if (pos == m)
            {
                return A[pos];
            }
            if (pos > m)
            {
                return Select(A, l, m, pos - 1);
            }
            else // if pos < m (last remaining option)
            {
                return Select(A, pos + 1, m, h);
            }
        }

        static int Partition(int[] A, int l, int h)
        {
            int pivotval = A[l];
            int pivotloc = l;

            for (int j = l + 1; j < h; j++)
            {
                if (A[j] < pivotval)
                {
                    pivotloc++;
                    int swap = A[pivotloc];
                    A[pivotloc] = A[j];
                    A[j] = swap;
                }
            }
            int temp = A[l];
            A[l] = A[pivotloc];
            A[pivotloc] = temp;
            return pivotloc;
        }


        static int CountBruteForceMedian(int[] A)
        {
            int numofbasicoperations = 0;
            int count = A.Length - 1;

            int n = A.Length;
            double k = n / 2.0;
            k = Math.Ceiling(k);

            for (int i = 0; i < n; i++)
            {
                int numsmaller = 0; //How many elements are smaller than A[i]
                int numequal = 0; //How many elements are equal to A[i]
                for (int j = 0; j < n; j++)
                {
                    numofbasicoperations++;
                    if (A[j] < A[i])
                    {
                        numsmaller++;
                        numofbasicoperations++;
                    }
                    else
                    {
                        if (A[j] == A[i])
                        {
                            numequal++;
                        }
                    }
                }
                if (numsmaller < k && k <= (numsmaller + numequal))
                {
                    
                //Console.WriteLine(numsmaller);
                }
            }
            Console.WriteLine(numofbasicoperations);
            return numofbasicoperations;
        }

        static void AvgNumofBOBruteForceMedian()
        {
            string fileName = "H:\\CAB301Assessment2.0\\AvgNumofBOM.csv";
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);

            TextWriter file = new StreamWriter(fileStream);
            int[] sizeArray = new int[] { 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500,
                5000, 5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000 };

            int randomSeed1 = (int)DateTime.Now.Ticks;
            Random rnd = new Random(randomSeed1);
            int add;

            for (int i = 0; i <= sizeArray.Length - 1; i++)
            {
                int[] array1 = new int[sizeArray[i]];
                int[] array2 = new int[sizeArray[i]];
                int[] array3 = new int[sizeArray[i]];
                int[] array4 = new int[sizeArray[i]];
                int[] array5 = new int[sizeArray[i]];
                int[] array6 = new int[sizeArray[i]];
                int[] array7 = new int[sizeArray[i]];
                int[] array8 = new int[sizeArray[i]];
                int[] array9 = new int[sizeArray[i]];
                int[] array10 = new int[sizeArray[i]];

                for (int j = 0; j < sizeArray[i]; j++)
                {
                    add = rnd.Next(-2147483648, 2147483647);
                    array1[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array2[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array3[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array4[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array5[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array6[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array7[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array8[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array9[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array10[j] = add;
                }
                //Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", array1[0], array2[0], array3[0], array4[0], array5[0], array6[0], array7[0], array8[0], array9[0], array10[0]);

                int listSize = sizeArray[i];
                int time1 = CountBruteForceMedian(array1);
                int time2 = CountBruteForceMedian(array2);
                int time3 = CountBruteForceMedian(array3);
                int time4 = CountBruteForceMedian(array4);
                int time5 = CountBruteForceMedian(array5);
                int time6 = CountBruteForceMedian(array6);
                int time7 = CountBruteForceMedian(array7);
                int time8 = CountBruteForceMedian(array8);
                int time9 = CountBruteForceMedian(array9);
                int time10 = CountBruteForceMedian(array10);

                file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", listSize.ToString(), time1.ToString(),
                    time2.ToString(), time3.ToString(), time4.ToString(), time5.ToString(), time6.ToString(),
                    time7.ToString(), time8.ToString(), time9.ToString(), time10.ToString(), "\n");
            }
            file.Dispose();
        }


        static int ExecutionTime(int[] A)
        {
            int TStart;
            int TFinish;
            int TExecution;
            //Console.WriteLine(string.Join(",", A));
            //Console.ReadLine();
            TStart = DateTime.Now.Millisecond;

            Median(A);

            TFinish = DateTime.Now.Millisecond;
            TExecution = TFinish - TStart;
            if (TExecution < 0)
            {
                TExecution = 1000 + TExecution;
            }

            return TExecution;
        }


        public static void AvgExecutionTime()
        {
            string fileName = "H:\\CAB301Assessment2.0\\AvgExecutionTimeM.csv";
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);

            TextWriter file = new StreamWriter(fileStream);
            int[] sizeArray = new int[] { 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500,
                5000, 5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000000 };

            int randomSeed1 = (int)DateTime.Now.Ticks;
            Random rnd = new Random(randomSeed1);
            int add;


            for (int i = 0; i <= sizeArray.Length - 1; i++)
            {
                int[] array1 = new int[sizeArray[i]];
                int[] array2 = new int[sizeArray[i]];
                int[] array3 = new int[sizeArray[i]];
                int[] array4 = new int[sizeArray[i]];
                int[] array5 = new int[sizeArray[i]];
                int[] array6 = new int[sizeArray[i]];
                int[] array7 = new int[sizeArray[i]];
                int[] array8 = new int[sizeArray[i]];
                int[] array9 = new int[sizeArray[i]];
                int[] array10 = new int[sizeArray[i]];

                for (int j = 0; j < sizeArray[i]; j++)
                {
                    add = rnd.Next(-2147483648, 2147483647);
                    array1[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array2[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array3[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array4[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array5[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array6[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array7[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array8[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array9[j] = add;
                    add = rnd.Next(-2147483648, 2147483647);
                    array10[j] = add;
                }
                int listSize = sizeArray[i];
                int time1 = ExecutionTime(array1);
                int time2 = ExecutionTime(array2);
                int time3 = ExecutionTime(array3);
                int time4 = ExecutionTime(array4);
                int time5 = ExecutionTime(array5);
                int time6 = ExecutionTime(array6);
                int time7 = ExecutionTime(array7);
                int time8 = ExecutionTime(array8);
                int time9 = ExecutionTime(array9);
                int time10 = ExecutionTime(array10);

                file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", listSize.ToString(), time1.ToString(),
                    time2.ToString(), time3.ToString(), time4.ToString(), time5.ToString(), time6.ToString(),
                    time7.ToString(), time8.ToString(), time9.ToString(), time10.ToString(), "\n");
            }
            file.Dispose();
        }

        static void Main(string[] args)
        {

            //BruteForceMedian(test);
            //AvgNumofBOBruteForceMedian();
            AvgExecutionTime();
            Console.WriteLine("Finish computing!");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
