using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace RicisBatch
{


  

   
    
      
    public interface IBeforeAdvice
    {
        void Process(object target, MethodInfo targetMethod, object[] args);
    }

    public interface IAfterReturningAdvice
    {
        void Process(object target, MethodInfo targetMethod, object[] args, object result);
    }

    public class GenericDeocorator<T> : DispatchProxy
    {
        private T _decorated;
        private IList<IBeforeAdvice> beforeAdvices= new List<IBeforeAdvice>();
        private IList<IAfterReturningAdvice> afterReturningAdvices =new List<IAfterReturningAdvice>();


        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {


                foreach (var beforeAdvice in beforeAdvices)
                {
                    beforeAdvice.Process(_decorated, targetMethod, args);
                }
                var result = targetMethod.Invoke(_decorated, args);
                foreach (var afterReturningAdvice in afterReturningAdvices)
                {
                    afterReturningAdvice.Process(_decorated, targetMethod, args, result);
                }


                return result;






            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {

                throw ex.InnerException ?? ex;
            }
        }

        public static M Create<M>(M decorated, IList<IBeforeAdvice> beforeAdvices)
        {
            object proxy = Create<M, GenericDeocorator<M>>();
            ((GenericDeocorator<M>)proxy).SetParameters(decorated, beforeAdvices);

            return (M)proxy;
        }

        private void SetParameters(T decorated, IList<IBeforeAdvice> beforeAdvices)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
            this.beforeAdvices = beforeAdvices;
            //this.afterReturningAdvices = afterReturningAdvices;
        }

     
    }
}
