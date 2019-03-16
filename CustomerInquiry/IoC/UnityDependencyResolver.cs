using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http.Dependencies;
using Unity;

namespace CustomerInquiry.IoC
{
    /// <summary>
    /// Represent Unity IoC container.
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;
        private readonly IEnumerable<string> typeStringsToIgnore;
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnityDependencyResolver" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="typeStringsToIgnore">The type strings to ignore.</param>
        public UnityDependencyResolver(IUnityContainer container, IEnumerable<string> typeStringsToIgnore = null)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
            this.typeStringsToIgnore = typeStringsToIgnore != null
                                           ? new HashSet<string>(typeStringsToIgnore)
                                           : new HashSet<string>();
        }

        /// <inheritdoc/>
        public IDependencyScope BeginScope()
        {
            var child = this.container.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        /// <summary>
        ///     Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        ///     The retrieved service.
        /// </returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                if (!this.IgnoreError(serviceType))
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return null;
        }

        /// <summary>
        ///     Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        ///     The retrieved service.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                if (!this.IgnoreError(serviceType))
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return new List<object>();
        }

        /// <summary>
        /// Dispose the container.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the container.
        /// </summary>
        /// <param name="disposing">Type of the service.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.container.Dispose();
            }

            this.disposed = true;
        }

        /// <summary>
        /// Ignores the error.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Returns <c>true</c> if type contains in list to ignore else <c>false</c>.</returns>
        private bool IgnoreError(Type serviceType)
        {
            var serviceTypeString = serviceType.FullName;
            return this.typeStringsToIgnore.Contains(serviceTypeString);
        }
    }
}
