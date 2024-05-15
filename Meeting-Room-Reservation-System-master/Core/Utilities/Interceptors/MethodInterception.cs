using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {//attrbutlerimin çalışma zamnınını oluşturan yerler
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); //başında koyabileceğim attribute
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;//hata alınca koyabileceğim
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }//sonunda koyabileceğim attribute
            }
            OnAfter(invocation);
        }
    }

    //Attribute için bilgiler adı falan ve önem derecesine göre kullanılmasını sçyler


}
