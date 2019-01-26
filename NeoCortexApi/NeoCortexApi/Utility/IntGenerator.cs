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

namespace NeoCortexApi.Utility
{


    /**
     * Generates a range of integers.
     * 
     * @author 
     */
    public class IntGenerator
    {
        /** serial version */
        private static readonly long serialVersionUID = 1L;

        protected int m_CurrentValue;
        protected int lower;
        protected int upper;

        public IntGenerator(int lower, int upper)
        {
            this.lower = lower;
            this.m_CurrentValue = this.lower;
            this.upper = upper;
        }

        /**
         * Returns the value returned by the last call to {@link #next()}
         * or the initial value if no previous call to {@code #next()} was made.
         * @return
         */
        public int get()
        {
            return m_CurrentValue;
        }

        /**
         * Returns the configured size or distance between the initialized
         * upper and lower bounds.
         * @return
         */
        public int size()
        {
            return upper - lower;
        }

        /**
         * Returns the state of this generator to its initial state so 
         * that it can be reused.
         */
        public void reset()
        {
            this.m_CurrentValue = lower;
        }

        
        /// <summary>
        /// Moves iterator to the next value and returns the current value.
        /// </summary>
        /// <returns></returns>
        public int next()
        {
            int retVal = m_CurrentValue;
            m_CurrentValue = ++m_CurrentValue > upper ? upper : m_CurrentValue;
            return retVal;
        }


        /// <summary>
        /// Gets the next value witout of incremmenting iterator.
        /// </summary>
        public int NextValue
        {
            get
            {
                var currVal = m_CurrentValue;
                int nexVal = ++currVal > upper ? upper : currVal;

                return nexVal;
            }
        }

        /**
         * {@inheritDoc}
         */

        public bool hasNext() { return m_CurrentValue < upper - 1; }

        /**
         * Returns a {@link Generator} which returns integers between
         * the values specified (lower inclusive, upper exclusive)
         * @param lower     the lower bounds or start value
         * @param upper     the upper bounds (exclusive)
         * @return
         */
        public static IntGenerator of(int lower, int upper)
        {
            return new IntGenerator(lower, upper);
        }
    }

}
