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

    public interface ISparseMatrix 
    {

    }
    
    public interface ISparseMatrix<T> : ISparseMatrix, IFlatMatrix<T>
    {
        /**
            * Returns a sorted array of occupied indexes.
            * @return  a sorted array of occupied indexes.
            */
        int[] getSparseIndices();

        /**
         * Returns an array of all the flat indexes that can be 
         * computed from the current configuration.
         * @return
         */
        int[] get1DIndexes();

        /**
         * Uses the specified {@link TypeFactory} to return an array
         * filled with the specified object type, according this {@code SparseMatrix}'s 
         * configured dimensions
         * 
         * @param factory   a factory to make a specific type
         * @return  the dense array
         */
        //T[] asDense(ITypeFactory<T> factory);

    }
}


