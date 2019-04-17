﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NeoCortexApi.DistributedComputeLib
{
    public class InMemoryArray : IDistributedArray
    {
        private int[] dimensions;

        private Array backingArray;

        private int numOfNodes;


        //public bool IsFixedSize => throw new NotImplementedException();

        //public bool IsReadOnly => throw new NotImplementedException();

        //public int Count => this.backingArray.Length;

        //public bool IsSynchronized => throw new NotImplementedException();

        //public object SyncRoot => throw new NotImplementedException();

        public int Rank => this.backingArray.Rank;

        long IDistributedArray.Count => this.backingArray.Length;

        public object this[int row, int col]
        {
            get
            {
                return this.backingArray.GetValue(row, col);
            }
            set
            {
                this.backingArray.SetValue(value, row, col);
            }
        }


        public object this[int index]
        {
            get => this.backingArray.GetValue(index);

            set => this.backingArray.SetValue(value, index);
        }

        public InMemoryArray(int numOfNodes)
        {
            this.numOfNodes = numOfNodes;
        }

        public static IDistributedArray CreateInstance(Type type, int[] dimensions)
        {
            var arr = new InMemoryArray(1);
            arr.backingArray = Array.CreateInstance(typeof(int), dimensions);
            arr.dimensions = dimensions;
            return arr;
        }

        public double Max()
        {
            throw new NotImplementedException();
            //double max = Double.MinValue;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] > max)
            //    {
            //        max = array[i];
            //    }
            //}
            //return max;
        }


        //public int Add(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Clear()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Contains(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyTo(Array array, int index)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public int IndexOf(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(int index, object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(object value)
        //{
        //    throw new NotImplementedException();
        //}



        //public void RemoveAt(int index)
        //{
        //    throw new NotImplementedException();
        //}

        public int AggregateArray(int row)
        {
            int cols = this.backingArray.GetUpperBound(1) + 1;

            int sum = 0;
            for (int i = 0; i < cols; i++)
            {
                sum += (Int32)this.backingArray.GetValue(row, i);
            }

            return sum;
        }

        public object GetValue(int index)
        {
            return this.backingArray.GetValue(index);
        }

        public object GetValue(int[] indexes)
        {
            return this.backingArray.GetValue(indexes);
        }

        public void SetValue(int value, int[] indexes)
        {
            this.backingArray.SetValue(value, indexes);
        }

        public int GetUpperBound(int v)
        {
            return this.backingArray.GetUpperBound(v);
        }

        public void SetRowValuesTo(int rowIndex, object newVal)
        {
            var cols = backingArray.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                backingArray.SetValue(0, rowIndex, i);
            }
        }


    }
}