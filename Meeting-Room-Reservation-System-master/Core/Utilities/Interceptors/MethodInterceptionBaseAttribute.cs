using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelik değerinin propertysi

        public virtual void Intercept(IInvocation invocation)
        {

        } //nesneme göre attribute ekleyebileceğimi oluşturur
    }

    //Attribute için bilgiler adı falan ve önem derecesine göre kullanılmasını sçyler


}
