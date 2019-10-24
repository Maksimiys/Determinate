using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            Random rnd=new Random();
            int n = Int32.Parse(Console.ReadLine()),res=0;
            int[,] arr = new int[n, n];
            for(i=0;i<n;i++)
                for(j=0;j<n;j++)
                {
                    arr[i, j] = rnd.Next(-10, 11);
                }
            if (n == 2)
            {
                res = arr[0, 0] * arr[1, 1] - (arr[0, 1] * arr[1, 0]);
            }
            if (n == 3)
            {
                res = (arr[0, 0] * arr[1, 1] * arr[2, 2]) + (arr[0, 1] * arr[1, 2] * arr[2, 0]) + (arr[0, 2] * arr[1, 0] * arr[2, 1]) - (arr[0, 2] * arr[1, 1] * arr[2, 0]) - (arr[0, 0] * arr[1, 2] * arr[2, 1]) - (arr[0, 1] * arr[1, 0] * arr[2, 2]);
            }
            else
            {
                 res = Matrixnn(arr, n);
            }
           Console.WriteLine($"Final= {res}");
        }
        public static int Matrix44(int[,] mas)
        {
            int a11, a21, a31, a41,res;
            a11 = (mas[1, 1] * mas[2, 2] * mas[3, 3]) + (mas[1, 2] * mas[2, 3] * mas[3, 1]) + (mas[1, 3] * mas[2, 1] * mas[3, 2]) - (mas[1, 3] * mas[2, 2] * mas[3, 1]) - (mas[1, 1] * mas[2, 3] * mas[3, 2]) - (mas[1, 2] * mas[2, 1] * mas[3, 3]);
            a21 = (mas[0, 1] * mas[2, 2] * mas[3, 3]) + (mas[0, 2] * mas[2, 3] * mas[3, 1]) + (mas[0, 3] * mas[2, 1] * mas[3, 2]) - (mas[0, 3] * mas[2, 2] * mas[3, 1]) - (mas[0, 1] * mas[2, 3] * mas[3, 2]) - (mas[0, 2] * mas[2, 1] * mas[3, 3]);
            a31 = (mas[0, 1] * mas[1, 2] * mas[3, 3]) + (mas[0, 2] * mas[1, 3] * mas[3, 1]) + (mas[0, 3] * mas[1, 1] * mas[3, 2]) - (mas[0, 3] * mas[1, 2] * mas[3, 1]) - (mas[0, 1] * mas[1, 3] * mas[3, 2]) - (mas[0, 2] * mas[1, 1] * mas[3, 3]);
            a41 = (mas[0, 1] * mas[1, 2] * mas[2, 3]) + (mas[0, 2] * mas[1, 3] * mas[2, 1]) + (mas[0, 3] * mas[1, 1] * mas[2, 2]) - (mas[0, 3] * mas[1, 2] * mas[2, 1]) - (mas[0, 1] * mas[1, 3] * mas[2, 2]) - (mas[0, 2] * mas[1, 1] * mas[2, 3]);
            res = (a11 * mas[0,0])+(-1*a21*mas[1,0])+(mas[2,0] * a31)+(mas[3,0] * (-1*a41));
            return res;
        }
        public static int Matrixnn(int[,] mas, int n)
        {
            int[,] ms = new int[15,15];

            int i, j, k, l = 0, dob = 0,m=2;
            if(n==4)
            {
                return Matrix44(mas);
            }
            if(n>4)
            {
                for (k = 0; k < n; k++)
                {
                    if (k == 0)
                    {
                        for (i = 0; i < n - 1; i++)
                            for (j = 0; j < n - 1; j++)
                            {
                                ms[i, j] = mas[i + 1, j + 1];
                            }
                    
                    }
                    else
                    {
                        for (i=0; i < n; i++)
                        {
                            if (i == k)
                            {
                                l++;
                            }
                            else
                            {
                                for (j = 1; j < n; j++)
                                {
                                    if (l > 0)
                                    {
                                        ms[i - 1, j - 1] = mas[i, j];
                                    }
                                    else
                                    {
                                        ms[i, j - 1] = mas[i, j];
                                    }
                                }
                            }
                        }
                        l = 0;
                    }
                    if (m % 2 != 0)
                    {
                           Console.WriteLine($"Resoult-1= {Matrixnn(ms,n-1)}");
                        dob += (mas[k,0]* Matrixnn(ms, n - 1)*(-1));
                    }
                    else
                    {
                        Console.WriteLine($"Resoult1= {Matrixnn(ms,n-1)}");
                        dob += (mas[k, 0] * Matrixnn(ms, n - 1));
                    }
                    m++;
                }
            }
            return dob;
        }
    }
}
