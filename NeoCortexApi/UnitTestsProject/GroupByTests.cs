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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeoCortexApi.Entities;
using NeoCortexApi.Utility;
using System;
using System.Collections.Generic;
using System.Text;


namespace UnitTestsProject
{
    /// <summary>
    /// Tests for implementation of grouping.
    /// </summary>
    [TestClass]
    public class GroupByTests
    {
        [TestMethod]
        public void IntegerCompare()
        {
            var i1 = new Integer(1);
            var i2 = new Integer(1);
                     
            Assert.IsTrue(i1 ==  i2);
            Assert.IsTrue(i1.Equals(i2));
        }

        [TestMethod]
        public void PairCompare()
        {
            var p1 = new Pair<Integer, Integer>(7, 7);
            var p2 = new Pair<Integer, Integer>(7, 7);

            Assert.IsTrue(p1 == p2);
            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void testIntegerGroup()
        {
            List<Integer> l = new List<Integer>(new Integer[] { 7, 12, 16 });

            List<Pair<Integer, Integer>> expected = new List<Pair<Integer, Integer>>(
                new Pair<Integer, Integer>[] {
                    new Pair<Integer, Integer>(7, 7),
                    new Pair<Integer, Integer>(12, 12),
                    new Pair<Integer, Integer>(16, 16)
                });

            GroupBy<Integer, Integer> grouper = GroupBy<Integer, Integer>.From(l, (el) => el);

            int i = 0;
            int pairCount = 0;
            foreach (Pair<Integer, Integer> p in grouper)
            {
                Assert.IsTrue(expected[i] == p);
                pairCount++;
                i++;
            }

            Assert.AreEqual(3, pairCount);

            pairCount = 0;

            l = new List<Integer>(new Integer[] { 2, 4, 4, 5 });

            List<Pair<Integer, Integer>> expected2 = new List<Pair<Integer, Integer>>(
                new Pair<Integer, Integer>[] {
                    new Pair<Integer, Integer>(2, 6),
                    new Pair<Integer, Integer>(4, 12),
                    new Pair<Integer, Integer>(4, 12),
                    new Pair<Integer, Integer>(5, 15)
                });

            grouper = GroupBy<Integer, Integer>.From(l, (n) => n * 3);

            i = 0;
            foreach (Pair<Integer, Integer> p in grouper)
            {
                Assert.IsTrue(expected2[i++] == p);
                pairCount++;
            }

            Assert.AreEqual(4, pairCount);
        }

        [TestMethod]
        public void testObjectGroup()
        {
            Column c0 = new Column(9, 0);
            Column c1 = new Column(9, 1);

            // Illustrates the Cell's actual index = colIndex * cellsPerColumn + indexOfCellWithinCol
            Assert.AreEqual(7, c0.getCell(7).getIndex());
            Assert.AreEqual(12, c1.getCell(3).getIndex());
            Assert.AreEqual(16, c1.getCell(7).getIndex());

            DistalDendrite dd0 = new DistalDendrite(c0.getCell(7), 0, 0, 0);
            DistalDendrite dd1 = new DistalDendrite(c1.getCell(3 /* Col 1's Cells start at 9 */), 1, 0, 1);
            DistalDendrite dd2 = new DistalDendrite(c1.getCell(7/* Col 1's Cells start at 9 */), 2, 0, 2);

            List<DistalDendrite> l = new List<DistalDendrite>(
                new DistalDendrite[] { dd0, dd1, dd2 });


            List<Pair<DistalDendrite, Column>> expected = new List<Pair<DistalDendrite, Column>>(
                new Pair<DistalDendrite, Column>[] {
                new Pair<DistalDendrite, Column>(dd0, c0),
                new Pair<DistalDendrite, Column>(dd1, c1),
                new Pair<DistalDendrite, Column>(dd2, c1)
                });

            GroupBy<DistalDendrite, Column> grouper = GroupBy<DistalDendrite, Column>.From(l, c => c.getParentCell().getColumn());

            int i = 0;

            foreach (Pair<DistalDendrite, Column> p in grouper)
            {
                Assert.IsTrue(expected[i++] == p);
            }
        }
    }
}
