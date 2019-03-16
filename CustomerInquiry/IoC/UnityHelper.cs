using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Formatting;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Hosting;
using System.Web.Http.Metadata;
using System.Web.Http.Validation;
using Unity;
using Unity.Injection;

namespace CustomerInquiry.IoC
{
    /// <summary>
    /// Class for Unity Helper methods.
    /// </summary>
    public static class UnityHelper
    {
        /// <summary>
        /// Initialize the unity container with required interface mapping.
        /// </summary>
        /// <param name="container">unity container.</param>
        public static void InitializeDependencyContainer(IUnityContainer container)
        {
            container.AddExtension(new ApiUnityContainerExtension());
        }
    }
}