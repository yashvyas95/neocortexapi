////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2015 Frankfurt University of Applied Sciences / daenet GmbH
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NeoCortexApi.Utility
{
    public class MathHelpers
    {
        /// <summary>
        /// Calculates the hamming distance between arrays.
        /// </summary>
        /// <param name="originArray">Original array to compare from.</param>
        /// <param name="comparingArray">Array to compare to.</param>
        /// <returns>Hamming distance.</returns>
        public static double GetHammingDistance(int[] originArray, int[] comparingArray)
        {

            double[] arr1 = ArrayUtils.toDoubleArray(originArray);
            double[] arr2 = ArrayUtils.toDoubleArray(comparingArray);
            return GetHammingDistance(new double[][] { arr1 }, new double[][] { arr2 })[0];
        }

        /// <summary>
        /// Calculates the hamming distance between arrays.
        /// </summary>
        /// <param name="originArray">Original array to compare from.</param>
        /// <param name="comparingArray">Array to compare to.</param>
        /// <returns>Hamming distance.</returns>
        public static double[] GetHammingDistance(double[][] originArray, double[][] comparingArray)
        {
            double[][] hDistance = new double[originArray.Length][];
            double[] h = new double[originArray.Length];
            double[] hammingDistance = new double[originArray.Length];

            for (int i = 0; i < originArray.Length; i++)
            {
                int len = Math.Max(originArray[i].Length, comparingArray[i].Length);
                int sum = 0;
                for (int j = 0; j < len; j++)
                {
                    if (originArray[i].Length > j && comparingArray[i].Length > j)
                    {
                        if (originArray[i][j] == comparingArray[i][j])
                        {
                            sum = sum + 0;
                        }
                        else
                        {
                            sum++;
                        }
                    }
                    else
                        sum++;
                }

                h[i] = sum;
                if (originArray[i].Length > 0)
                    hammingDistance[i] = ((originArray[i].Length - sum) * 100 / originArray[i].Length);
                else
                    hammingDistance[i] = double.PositiveInfinity;
            }

            return hammingDistance;
        }

    }
}
