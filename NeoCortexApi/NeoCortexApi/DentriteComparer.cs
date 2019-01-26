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

using NeoCortexApi.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeoCortexApi
{
    public class DentriteComparer : IComparer<DistalDendrite>
    {
        private int m_NextSegmentOrdinal;

        public DentriteComparer(int nextSegmentOrdinal)
        {
            m_NextSegmentOrdinal = nextSegmentOrdinal;
        }

        public int Compare(DistalDendrite s1, DistalDendrite s2)
        {
            double c1 = s1.getParentCell().getIndex() + ((double)(s1.getOrdinal() / (double)m_NextSegmentOrdinal));
            double c2 = s2.getParentCell().getIndex() + ((double)(s2.getOrdinal() / (double)m_NextSegmentOrdinal));
            return c1 == c2 ? 0 : c1 > c2 ? 1 : -1;
        }
    }
}
