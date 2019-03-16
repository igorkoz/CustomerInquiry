using CustomerInquiry.Adapters;
using Unity;
using Unity.Extension;
using Unity.Injection;
using Unity.Lifetime;

namespace CustomerInquiry.IoC
{
    /// <summary>
    /// Represents extension to initialize the unity container with interface mapping required for API.
    /// </summary>
    public class ApiUnityContainerExtension : UnityContainerExtension
    {
        /// <summary>
        /// Initialize the container with this extension's functionality.
        /// </summary>
        protected override void Initialize()
        {
            this.Container.RegisterType<ICustomerAdapter, CustomerAdapter>();
        }
    }
}