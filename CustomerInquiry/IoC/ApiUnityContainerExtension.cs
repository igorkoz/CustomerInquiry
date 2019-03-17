using CustomerInquiry.Adapters;
using CustomerInquiryBusiness.Managers;
using CustomerInquiryBusiness.Validators;
using CustomerInquiryDataService.Repositories;
using Unity;
using Unity.Extension;
using Unity.Injection;
using Unity.Lifetime;

namespace CustomerInquiry.IoC
{
    /// <summary>
    /// Represents extension to initialize the Unity container with interface mapping required for API
    /// </summary>
    public class ApiUnityContainerExtension : UnityContainerExtension
    {
        /// <summary>
        /// Initialize the container with this extension's functionality
        /// </summary>
        protected override void Initialize()
        {
            this.Container.RegisterType<ICustomerAdapter, CustomerAdapter>();
            this.Container.RegisterType<ICustomerManager, CustomerManager>();
            this.Container.RegisterType<ICustomerRepository, CustomerRepository>();
            this.Container.RegisterType<IDbContext, CustomerDBContext>();
            this.Container.RegisterType<IEMailValidator, EMailValidator>();
        }
    }
}