using System;
using System.Collections.Generic;
using System.Text;

namespace Limited.Gateway.Options
{
    public class RouteOption
    {
        /// <summary>
        /// 源路径匹配
        /// </summary>
        public string SourcePathRegex { get; set; }

        /// <summary>
        /// HTTP动词
        /// </summary>
        public string[] HttpMethods { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 目标服务
        /// </summary>
        public string TargetService { get; set; }

        /// <summary>
        /// 目标路径正则
        /// </summary>
        public string TargetPathRegex { get; set; }

        /// <summary>
        /// 质量控制
        /// </summary>
        public QoSOption QoS { get; set; }
    }
}
