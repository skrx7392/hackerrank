﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank.StrykerCodeSprint
{
    class PointFiltering
    {
        static void pointFiltering(String[] args)
        {
            string[] line1 = Console.ReadLine().Split(' ');
            int n = int.Parse(line1[0]);
            int b = int.Parse(line1[1]);
            SortedDictionary<double, List<double>> Points = new SortedDictionary<double, List<double>>();
            SortedDictionary<double, List<double>> Bucket = new SortedDictionary<double, List<double>>();
            for(int i=0; i<n; i++)
            {
                List<double> point = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse).ToList();
                Points.Add(point[3], point);
            }
            for(int i=0; i<b; i++)
            {
                List<double> point = Points.Last().Value;
                Points.Remove(point[3]);
                Bucket.Add(point[0], point);
            }
            
            while(true)
            {
                string input = Console.ReadLine();
                if(String.IsNullOrEmpty(input))
                {
                    return;
                }
                string[] line = input.Split(' ');
                string c = line[0].ToUpper();
                int k = int.Parse(line[1]);
                List<double> point = new List<double>();
                try
                {
                    point = Bucket[k];
                    //point = Bucket.Values.First(x => x[0] == k);
                    if (String.Equals("F", c))
                    {
                        Console.WriteLine("{0} = ({1},{2},{3})", point[0], String.Format("{0:F3}", point[1]), String.Format("{0:F3}", point[2]), String.Format("{0:F3}", point[3]));
                    }
                    else
                    {
                        if (Points.Count == 0)
                        {
                            Console.WriteLine("No more points can be deleted.");
                        }
                        else
                        {
                            Bucket.Remove(point[0]);
                            Console.WriteLine("Point id {0} removed.", k);
                            List<double> anotherPoint = Points.Values.Last();
                            Bucket.Add(anotherPoint[0], anotherPoint);
                            Points.Remove(anotherPoint[3]);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Point doesn't exist in the bucket.");
                }
            }
        }
    }
}
