using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RicisBatch
{
    public static class Ext
    {
        public static object Atomic(Func<object> action)
        {
            
            object retval=null;
            using (var scope = new TransactionScope())
            {
                retval = action();
                scope.Complete();
                Console.WriteLine("#########################################################");
            }

            return retval;
        }
    }
}
