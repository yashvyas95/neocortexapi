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
    public class Pair<TKey, TValue> : IEquatable<Pair<TKey, TValue>>
    {
        /// <summary>
        /// Creates an empty key-pair.
        /// </summary>
       
        public Pair()
        {
           
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.KeyValuePair`2 structure
        //     with the specified key and value.
        //
        // Parameters:
        //   key:
        //     The object defined in each key/value pair.
        //
        //   value:
        //     The definition associated with key.
        public Pair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        //
        // Summary:
        //     Gets the key in the key/value pair.
        //
        // Returns:
        //     A TKey that is the key of the System.Collections.Generic.KeyValuePair`2.
        public TKey Key { get; }
        //
        // Summary:
        //     Gets the value in the key/value pair.
        //
        // Returns:
        //     A TValue that is the value of the System.Collections.Generic.KeyValuePair`2.
        public TValue Value { get; }


        public static bool operator ==(Pair<TKey, TValue> x, Pair<TKey, TValue> y)
        {
            if (EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x)
                && EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return true;

            else if (!EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x)
               && EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return false;
            else if (EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x)
               && !EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return false;

            return EqualityComparer<TKey>.Default.Equals(x.Key, y.Key) && EqualityComparer<TValue>.Default.Equals(x.Value, y.Value);
        }

        public static bool operator !=(Pair<TKey, TValue> x, Pair<TKey, TValue> y)
        {
            if (EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x) 
                && EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return false;
            else if (EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x)
              && !EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return true;
            else if (!EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, x)
              && EqualityComparer<Pair<TKey, TValue>>.Default.Equals(null, y))
                return true;

            return !EqualityComparer<TKey>.Default.Equals(x.Key, y.Key) ||
                !EqualityComparer<TValue>.Default.Equals(x.Value, y.Value);
        }

        //
        // Summary:
        //     Returns a string representation of the System.Collections.Generic.KeyValuePair`2,
        //     using the string representations of the key and value.
        //
        // Returns:
        //     A string representation of the System.Collections.Generic.KeyValuePair`2, which
        //     includes the string representations of the key and value.
        public override string ToString()
        {
            return $"[{this.Key}, {this.Value}]";
        }

        public bool Equals(Pair<TKey, TValue> other)
        {
            return EqualityComparer<TKey>.Default.Equals(this.Key, other.Key) && EqualityComparer<TValue>.Default.Equals(this.Value, other.Value);
        }
    }
}
