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


namespace NeoCortexApi.Entities
{
    /**
   * Allows storage of array data in sparse form, meaning that the indexes
   * of the data stored are maintained while empty indexes are not. This allows
   * savings in memory and computational efficiency because iterative algorithms
   * need only query indexes containing valid data.
   * 
   * @author David Ray
   *
   * @param <T>
   */
    public class SparseObjectMatrix<T> : AbstractSparseMatrix<T>, IEquatable<T> where T : class
    {
        /** keep it simple */
        private static readonly long serialVersionUID = 1L;

        private Dictionary<int, T> sparseMap = new Dictionary<int, T>();

        /**
         * Constructs a new {@code SparseObjectMatrix}
         * @param dimensions	the dimensions of this array
         */
        public SparseObjectMatrix(int[] dimensions) : base(dimensions, false)
        {

        }

        /**
         * Constructs a new {@code SparseObjectMatrix}
         * @param dimensions					the dimensions of this array
         * @param useColumnMajorOrdering		where inner index increments most frequently
         */
        public SparseObjectMatrix(int[] dimensions, bool useColumnMajorOrdering) : base(dimensions, useColumnMajorOrdering)
        {

        }

        /**
         * Sets the object to occupy the specified index.
         * 
         * @param index     the index the object will occupy
         * @param object    the object to be indexed.
         */
        //  @Override

        public override AbstractFlatMatrix<T> set(int index, T obj)
        {
            if (!sparseMap.ContainsKey(index))
                sparseMap.Add(index, (T)obj);
            else
                sparseMap[index] = obj;

            return this;
        }

        /**
         * Sets the specified object to be indexed at the index
         * computed from the specified coordinates.
         * @param object        the object to be indexed.
         * @param coordinates   the row major coordinates [outer --> ,...,..., inner]
         */
        //@Override
        public override AbstractFlatMatrix<T> set(int[] coordinates, T obj)
        {
            set(computeIndex(coordinates), obj);
            return this;
        }

        /**
         * Returns the T at the specified index.
         * 
         * @param index     the index of the T to return
         * @return  the T at the specified index.
         */
        // @Override
        public T GetObject(int index)
        {
            return get(index);
        }

        /**
         * Returns the T at the index computed from the specified coordinates
         * @param coordinates   the coordinates from which to retrieve the indexed object
         * @return  the indexed object
         */
        // @Override
        public T Get(int[] coordinates)
        {
            return get(computeIndex(coordinates));
        }


        /**
         * Returns the T at the specified index.
         * 
         * @param index     the index of the T to return
         * @return  the T at the specified index.
         */
        // @Override
        public override T get(int index)
        {
            T val = null;

            this.sparseMap.TryGetValue(index, out val);

            return val;
            //return this.sparseMap[index];
        }

        /**
         * Returns a sorted array of occupied indexes.
         * @return  a sorted array of occupied indexes.
         */
        // @Override
        public int[] GetSparseIndices()
        {
            return reverse(sparseMap.Keys.ToArray());
        }

        /**
         * {@inheritDoc}
         */
        // @Override
        public override String ToString()
        {
            return getDimensions().ToString();
        }

        /* (non-Javadoc)
         * @see java.lang.Object#hashCode()
         */
        //    @Override
        public override int GetHashCode()
        {
            int prime = 31;
            int result = base.GetHashCode();
            result = prime * result + ((sparseMap == null) ? 0 : sparseMap.GetHashCode());
            return result;
        }

        /* (non-Javadoc)
         * @see java.lang.Object#equals(java.lang.Object)
         */
        //SuppressWarnings("rawtypes")
        // @Override
        public override bool Equals(Object obj)
        {
            if (this == obj)
                return true;
            if (!base.Equals(obj))
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            SparseObjectMatrix<T> other = obj as SparseObjectMatrix<T>;
            if (other == null)
                return false;

            if (sparseMap == null)
            {
                if (other.sparseMap != null)
                    return false;
            }
            else if (!sparseMap.Equals(other.sparseMap))
                return false;

            return true;
        }

        public bool Equals(T other)
        {
            return this.Equals((object)other);
        }
    }
}
