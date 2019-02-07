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

using NeoCortexApi;
using NeoCortexApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestsProject
{
    public class SpatialPoolerMock : SpatialPooler
    {
        private int[] m_InhibitColumns;

        //private static long serialVersionUID = 1L;

        public SpatialPoolerMock(int[] inhibitColumns)
        {
            m_InhibitColumns = inhibitColumns;
        }
        public override int[] inhibitColumns(Connections c, double[] overlaps)
        {
            return m_InhibitColumns;// new int[] { 0, 1, 2, 3, 4 };
        }
    };


    public class SpatialPoolerMock2 : SpatialPooler
    {
        //private static long serialVersionUID = 1L;

        private Func<double, int[]> m_CallBackGlobal;
        private Func<double, int[]> m_CallBackLocal;

        public SpatialPoolerMock2( Func<double, int[]> callBackGlobal, Func<double, int[]> callBackLocal)
        {
            m_CallBackGlobal = callBackGlobal;
            m_CallBackLocal = callBackLocal;
        }
        

        public override int[] inhibitColumnsGlobal(Connections c, double[] overlap, double density)
        {
            m_CallBackGlobal?.Invoke(density);
            //setGlobalCalled(true);
            //_density = density;
            return new int[] { 1 };
        }

        public override int[] inhibitColumnsLocal(Connections c, double[] overlap, double density)
        {
            m_CallBackLocal?.Invoke(density);
            //setGlobalCalled(true);
            //_density = density;
            return new int[] { 1 };
        }
    };



    public class SpatialPoolerMock3 : SpatialPooler
    {
        //private static long serialVersionUID = 1L;

        private double m_avgConnectedSpanForColumnND;

        private double m_avgColumnsPerInput;

        public SpatialPoolerMock3(double avgConnectedSpanForColumnND, double avgColumnsPerInput)
        {
            this.m_avgConnectedSpanForColumnND = avgConnectedSpanForColumnND;
            this.m_avgColumnsPerInput = avgColumnsPerInput;

        }

        public override double getAvgSpanOfConnectedSynapsesForColumn(Connections c, int columnIndex)
        {
            return this.m_avgConnectedSpanForColumnND;
        }

        public override double avgColumnsPerInput(Connections c)
        {
            return this.m_avgColumnsPerInput;
        }
    };


    public class SpatialPoolerMock4 : SpatialPooler
    {
        //private static long serialVersionUID = 1L;


        public SpatialPoolerMock4()
        {
           

        }

        public override void raisePermanenceToThreshold(Connections c, double[] perm, int[] maskPotential)
        {
            //Mock out
        }
    };
}
