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
using NeoCortexApi;

namespace NeoCortexApi.Entities
{
    /**
 * Allows storage of array data in sparse form, meaning that the indexes
 * of the data stored are maintained while empty indexes are not. This allows
 * savings in memory and computational efficiency because iterative algorithms
 * need only query indexes containing valid data. The dimensions of matrix defined
 * at construction time and immutable - matrix fixed size data structure.
 * 
 * @author David Ray
 * @author Jose Luis Martin
 *
 * @param <T>
 */

    
    public interface IFlatMatrix<T> : IMatrix<T> {

        T get(int index);

        IFlatMatrix<T> set(int index, T value);

        int computeIndex(int[] coordinates);

        /**
         * Returns the maximum accessible flat index.
         * @return  the maximum accessible flat index.
         */
        int getMaxIndex();

        int computeIndex(int[] coordinates, bool doCheck);

        /**
         * Returns an integer array representing the coordinates of the specified index
         * in terms of the configuration of this {@code SparseMatrix}.
         * @param index the flat index to be returned as coordinates
         * @return  coordinates
         */
        int[] computeCoordinates(int index);

        int[] getDimensionMultiples();
        }
    }
