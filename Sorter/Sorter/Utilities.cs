using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorter
{
    class Utilities
    {
        /* Utility class designed to encourage OOP best practices to reduce coupling and increase cohesion includes functions to 
         read .txt input, write to output.txt and sort utilizing MergeSort                                                     */
        public static Person[] readInput()
        {
            List<Person> personList = new List<Person>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"input.txt");


                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        Person p = new Person();
                        string input = line.Trim();
                        string[] name = input.Split(new char[0]);
                        p.firstName = name[0];

                        if (name.Length > 1)
                        {
                            p.lastName = name[name.Length - 1];
                            p.hasLastName = true;
                        }
                        else
                        {
                            //proxy sentinel value 
                            p.lastName = "}";
                            p.hasLastName = false;
                        }

                        personList.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return personList.ToArray();
        }

        public static void outToFile(Person[] sorted)
        {
            //Utilizing Linq and Lambda expression to write array to .txt
            System.IO.File.WriteAllLines(@"output.txt", sorted.Select(s => s.printFullName()));
        }
        /* Merge sort section. I decided to use Merge sort for sorting names because of it's O(n log n) time complexity and that it's stable */
        public static Person[] mergeSortFirst(Person[] A)
        {
            Person[] temp = mergeSort(A, 0, A.Length - 1);
            return temp;
        }

        public static Person[] mergeSort(Person[] A, int p, int r)
        {
            Person[] temp = new Person[A.Length];
            if (p < r)
            {
                int q = ((r + p) / 2);
                mergeSort(A, p, q);
                mergeSort(A, q + 1, r);
                temp = merge(A, p, q, r);
            }
            return temp;
        }

        public static Person[] merge(Person[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;

            Person[] L = new Person[n1 + 1];
            Person[] R = new Person[n2 + 1];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }

            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + 1 + j];
            }
            Person sentinel = new Person();
            sentinel.firstName = "~";
            sentinel.lastName = "~";
            L[L.Length - 1] = sentinel;
            R[R.Length - 1] = sentinel;

            int x = 0;
            int y = 0;

            for (int k = p; k < r + 1; k++)
            {
                if (L[x].firstName.ToLower()[0] <= R[y].firstName.ToLower()[0])
                {
                    A[k] = L[x];
                    x++;
                }
                else
                {
                    A[k] = R[y];
                    y++;
                }
            }

            return A;

        }

        public static Person[] mergeSortLast(Person[] A)
        {
            Person[] temp = mergeSortL(A, 0, A.Length - 1);
            return temp;
        }

        public static Person[] mergeSortL(Person[] A, int p, int r)
        {
            Person[] temp = new Person[A.Length];
            if (p < r)
            {
                int q = ((r + p) / 2);
                mergeSortL(A, p, q);
                mergeSortL(A, q + 1, r);
                temp = mergeL(A, p, q, r);
            }
            return temp;
        }

        public static Person[] mergeL(Person[] A, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;

            Person[] L = new Person[n1 + 1];
            Person[] R = new Person[n2 + 1];
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }

            for (int j = 0; j < n2; j++)
            {
                R[j] = A[q + 1 + j];
            }
            Person sentinel = new Person();
            sentinel.firstName = "~";
            sentinel.lastName = "~";
            L[L.Length - 1] = sentinel;
            R[R.Length - 1] = sentinel;

            int x = 0;
            int y = 0;

            for (int k = p; k < r + 1; k++)
            {

                if (L[x].lastName.ToLower()[0] <= R[y].lastName.ToLower()[0])
                {
                    A[k] = L[x];
                    x++;
                }
                else
                {
                    A[k] = R[y];
                    y++;
                }




            }

            return A;

        }

    }
}
