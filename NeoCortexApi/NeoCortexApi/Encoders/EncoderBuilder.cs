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

namespace NeoCortexApi.Encoders
{
    public abstract class EncoderBuilder<TBuilder, TEncoder, T>
    {
        protected int n;
        protected int w;
        protected double minVal;
        protected double maxVal;
        protected double radius;
        protected double resolution;
        protected bool periodic;
        protected bool clipInput;
        protected bool forced;
        protected String name;

        protected EncoderBase<T> encoder;

        public TEncoder build()
        {
            if (encoder == null)
            {
                throw new InvalidOperationException("Subclass did not instantiate builder type " +
                    "before calling this method!");
            }

            encoder.N = this.n;
            encoder.W = w;
            encoder.MinVal = minVal;
            encoder.MaxVal = maxVal;
            encoder.Radius = radius;
            encoder.Resolution = resolution;
            encoder.Periodic = periodic;
            encoder.ClipInput = clipInput;
            encoder.Forced = forced;
            encoder.Name = name;

            return (E)encoder;
        }

        public TBuilder FromN(int n)
        {
            this.n = n;
            return (TBuilder)this;
        }
        public TBuilder FromW(int w)
        {
            this.w = w;
            return (TBuilder)this;
        }
        public TBuilder minVal(double minVal)
        {
            this.minVal = minVal;
            return (TBuilder)this;
        }
        public TBuilder maxVal(double maxVal)
        {
            this.maxVal = maxVal;
            return (TBuilder)this;
        }
        public TBuilder radius(double radius)
        {
            this.radius = radius;
            return (TBuilder)this;
        }
        public TBuilder resolution(double resolution)
        {
            this.resolution = resolution;
            return (TBuilder)this;
        }
        public TBuilder periodic(bool periodic)
        {
            this.periodic = periodic;
            return (TBuilder)this;
        }
        public TBuilder clipInput(bool clipInput)
        {
            this.clipInput = clipInput;
            return (TBuilder)this;
        }
        public TBuilder forced(bool forced)
        {
            this.forced = forced;
            return (TBuilder)this;
        }
        public TBuilder name(String name)
        {
            this.name = name;
            return (TBuilder)this;
        }
    }
}

