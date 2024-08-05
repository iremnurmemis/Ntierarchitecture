
using Castle.DynamicProxy;

namespace Core
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute 
    {

        // invocation business methodlarıdır aspectler method ınterceptionları baz alır ve onun methodlarını ezerek kullanır.virtual method senin onu ezmeni bekleyen methodlardır
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        public virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) 
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();

            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally 
            {
                if(isSuccess)
                    OnSuccess(invocation);
            }

            OnAfter(invocation);
        }

    }
}
