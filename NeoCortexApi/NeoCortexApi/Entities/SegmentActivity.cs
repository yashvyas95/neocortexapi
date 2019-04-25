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

namespace NeoCortexApi.Entities
{
    /// <summary>
    /// Used as tupple in temporal cycle calculus.
    /// </summary>
    //[Serializable]
    public class SegmentActivity
    {
        /// <summary>
        /// Contains the index of segments with number of synapses with permanence higher than threshold,
        /// which makes synapse active.
        /// [segment index, number of active synapses].
        /// </summary>
        public Dictionary<int, int> Active = new Dictionary<int, int>();

        /// <summary>
        /// Contains the index of segments with number of synapses with permanence higher than minimum threshold,
        /// which makes synapse potential one.
        /// Dictionary [segment index, number of potential synapses].
        /// </summary>
        public Dictionary<int, int> Potential = new Dictionary<int, int>();

        public SegmentActivity()
        {

        }
    }
}
