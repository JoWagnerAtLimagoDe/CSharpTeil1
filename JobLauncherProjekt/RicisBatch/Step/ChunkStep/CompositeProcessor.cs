using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RicisBatch.Step.ChunkStep
{
    public class MyStruct
    {
        public object delegate_;
        public Type retvalType;
        public Type paramType;
        public Type processorType;
        public MyStruct(object @delegate, Type processorType,Type retvalType, Type paramType)
        {
            delegate_ = @delegate;
            this.processorType = processorType;
            this.retvalType = retvalType;
            this.paramType = paramType;
        }
    }
    public class CompositeProcessor<P, T> : AbstractProcessor<P, T>
    {
        private IList<MyStruct> list = new List<MyStruct>();
       
        public void AddProcessor<TT,TS>(IProcessor<TT,TS> processor)
        {

            Type p = processor.GetType().GetInterfaces()[0];
            Type[] typeArguments = p.GetGenericArguments();
            list.Add(new MyStruct(processor , p,typeArguments[1], typeArguments[0]));

        }
       

        public override T Process(P p)
        {
            object retval = p;
            foreach (var myStruct in list)
            {
               
                MethodInfo m = myStruct.processorType.GetMethod("Process", BindingFlags.Public | BindingFlags.Instance,
                    null, new Type[] {myStruct.paramType}, null);
                retval = m.Invoke(myStruct.delegate_, new object[] {retval});
            }
            //
            return (T)retval;
        }

      

    }
}
