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

    /**
     * Base interface for Matrices.
     * 
     * @author Jose Luis Martin.
     * 
     * @param <T> element type
     */
    public interface IMatrix<T>
    {

        /**
         * Returns the array describing the dimensionality of the configured array.
         * @return  the array describing the dimensionality of the configured array.
         */
        int[] getDimensions();

        /**
         * Returns the configured number of dimensions.
         * @return  the configured number of dimensions.
         */
        int getNumDimensions();

        /**
         * Gets element at supplied index.
         * @param index index to retrieve.
         * @return element at index.
         */
        T get(params int[] index);

        /**
         * Puts an element to supplied index.
         * @param index index to put on.
         * @param value value element.
         */
        IMatrix<T> set(int[] index, T value);
    }
}
