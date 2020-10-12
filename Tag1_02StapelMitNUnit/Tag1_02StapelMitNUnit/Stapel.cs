using System;
using System.Collections.Generic;
using System.Text;
using Tag1_02StapelMitNUnit;

namespace Bundesbank.Collections
{
    public class Stapel
    {
        private object[] data;
        private int index;

        public Stapel()
        {
            data = new object[10];
            index = 0;
        }

        public bool IsEmpty { get { return index <= 0; } }
        public bool IsFull { get { return index >= data.Length; } }

        public void Push(object value)
        {
            if (IsFull)
                throw new StapelException("Overflow");
            data[index++] = value;
        }

        public object Pop()
        {
            if(IsEmpty)
                throw new StapelException("Underflow");
            return data[--index];
        }
    }
}
