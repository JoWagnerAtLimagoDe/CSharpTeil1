using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Collections
{
    public class Liste
    {
        private Kettenglied start, akt;

        public virtual bool IsEmpty
        {
            get
            {
                return start == null;
            }
        }
        /// <summary>
        /// liefert true wenn die Liste leer ist oder der Cursor auf dem letzten Datensatz steht.
        /// </summary>
        public virtual bool IsEOL
        {
            get
            {
                return IsEmpty || akt.nach == null;
            }
        }
        /// <summary>
        /// liefert true wenn die Liste leer ist oder der Cursor auf dem ersten Datensatz steht.
        /// </summary>
        public virtual bool IsBOL
        {
            get 
            {
                return start == akt;
            }
        }

        public Liste()
        {
            start = akt = null;
        }

        public virtual void Append(Object item)
        {
            Kettenglied neu = new Kettenglied(item);
            if(IsEmpty)
            {
                start = neu;
    
            } else
            {
                MoveLast();
                neu.vor = akt;
                akt.nach = neu;
            }
            akt = neu;
        }
        public virtual bool Remove()
        {
            if(IsEmpty) return false;

            if(IsBOL && IsEOL)
            {
                start = akt = null;
                return true;
            }

            if(IsBOL)
            {
                start = akt = akt.nach;
                akt.vor = null;
                return true;
            }

            if (IsEOL)
            {
                MovePrevious();
                akt.nach = null;
                return true;
            }
            akt.vor.nach = akt.nach;
            akt.nach.vor = akt.vor;
            MoveNext();
            return true;

        }

        public virtual Object Get()
        {
            if (IsEmpty) return null;
            return akt.data;
        }

        public virtual bool Update(Object newValue)
        {
            if(IsEmpty) return false;
            akt.data = newValue;
            return true;
        }

        public virtual bool MoveNext()
        {
            if (IsEOL) return false;
            akt = akt.nach;

            return true;
        }


        public virtual bool MovePrevious()
        {
            if (IsBOL) return false;

            akt = akt.vor;
            return true;
        }
        public virtual bool MoveFirst()
        {
            if (IsEmpty) return false;
            while (MovePrevious()) 
                ;
            return true;
        }

        public virtual bool removeAll()
        {
            if (IsEmpty) return false;
            while (Remove()) ;
            return true;
        }


        public virtual bool MoveLast()
        {
            if(IsEmpty) return false;
            while (MoveNext()) { }
            return true;
        }

        private class Kettenglied
        {
            public Kettenglied vor, nach;
            public Object data; 

            public Kettenglied(Object data )
            {
                this.data = data;
                vor = nach = null;
            }
        }

    }
}
