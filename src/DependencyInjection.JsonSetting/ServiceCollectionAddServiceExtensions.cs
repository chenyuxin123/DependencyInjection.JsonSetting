using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionAddServiceExtensions
    {
        /// <summary>
        /// 注册服务，默认配置节为 Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            IList<ServiceOption> serviceOptions = new List<ServiceOption>();
            configuration.GetSection("Services").Bind(serviceOptions);
            return AddService(services, serviceOptions);
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddService(this IServiceCollection services, IList<ServiceOption> serviceOptions)
        {
            if (serviceOptions == null || serviceOptions.Count == 0)
            {
                return services;
            }

            var assemblies = new List<Assembly>();

            foreach (var service in serviceOptions)
            {
                if (!string.IsNullOrEmpty(service.ServiceAssemblyName))
                {
                    Assembly assembly = assemblies.Find(x => x.GetName().Name == service.ServiceAssemblyName);
                    if (assembly == null)
                    {
                        assembly = Assembly.Load(service.ServiceAssemblyName);
                        assemblies.Add(assembly);
                    }
                    Type serviceType = assembly.GetType(service.ServiceType);
                    Type implementationType = null;
                    if (service.ServiceAssemblyName == service.ImplementationAssemblyName || string.IsNullOrEmpty(service.ImplementationAssemblyName))
                    {
                        implementationType = assembly.GetType(service.ImplementationType);
                    }
                    else
                    {
                        Assembly implementationAssembly = assemblies.Find(x => x.GetName().Name == service.ImplementationAssemblyName);
                        if (implementationAssembly == null)
                        {
                            implementationAssembly = Assembly.Load(service.ImplementationAssemblyName);
                            assemblies.Add(implementationAssembly);
                        }
                        implementationType = implementationAssembly.GetType(service.ImplementationType);
                    }
                    services.Add(new ServiceDescriptor(serviceType, implementationType, service.ServiceLifttime));
                }
                else
                {
                    services.Add(new ServiceDescriptor(Assembly.GetEntryAssembly().GetType(service.ServiceType), Assembly.GetEntryAssembly().GetType(service.ImplementationType), service.ServiceLifttime));
                }
            }
            return services;
        }
    }
}
