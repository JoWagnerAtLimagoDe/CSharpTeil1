using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Collections
{

    /// <summary>
    /// Eine tolle Klasse
    /// </summary>
    public class Stapel
    {

        private int[] data;
        private int index;

        public Boolean IsEmpty { get {
               
                return index <= 0;    
        } }
        public Boolean IsFull {
            get
            {
                   return index >= data.Length;
            }
        }
        public Stapel():this(10)
        {
           
        }

        public Stapel(int size)
        {
            data = new int[size<1?10:size];
            index = 0;
        }

        /// <summary>
        /// Macht was tolles
        /// </summary>
        /// <param name="value">Teller zum Einfügen</param>
        public void Push(int value) // Verhalten im Fehlerfall
        {
            if (IsFull) return;

            data[index++] = value;
        }


        public int Pop()  // Verhalten im Fehlerfall
        {
            if (IsEmpty) return 0;
            return data[--index];
        }
    }
}
