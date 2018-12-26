using System;
using System.Collections.Generic;
using System.Text;

namespace Limited.DashBoard.Common
{
    public class ConfigOptions
    {
        /// <summary>
        /// consul 地址
        /// </summary>
        public string ConsulHost { get; set; } = "http://45.32.8.16:850";
        /// <summary>
        /// 未配置的服务
        /// </summary>
        public string UnconfiguredKey { get; set; } = "Unconfigured";
        /// <summary>
        /// 已配置的服务
        /// </summary>
        public string ConfiguredKey { get; set; } = "Configured";
    }
}
