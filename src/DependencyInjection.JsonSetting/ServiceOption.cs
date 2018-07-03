using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceOption
    {     
        /// <summary>
        /// 服务类型
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// 实现类型
        /// </summary>
        public string ImplementationType { get; set; }

        /// <summary>
        /// 服务类型程序集名称
        /// </summary>
        public string ServiceAssemblyName { get; set; }

        /// <summary>
        /// 实现类型程序集名称
        /// </summary>
        public string ImplementationAssemblyName { get; set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public ServiceLifetime ServiceLifttime { get; set; }
    }
}
