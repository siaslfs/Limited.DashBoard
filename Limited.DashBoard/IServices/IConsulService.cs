using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Limited.DashBoard.IServices
{
    /// <summary>
    /// Consul服务
    /// </summary>  
    [HttpHost("http://45.32.8.16:8500")] // HttpHost可以在Config传入覆盖
    public interface IConsulService : IHttpApi
    {
        /// <summary>
        /// 根据key获取返回值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>  
        [HttpGet("/v1/kv/{key}")]
        ITask<string> GetConsulByKeyAsync(string key);
        /// <summary>
        /// 根据key获取返回值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>  
        [HttpPut("/v1/kv/{key}")] 
        ITask<string> PutConsulByKeyAsync(string key, [HttpContent]StringContent data);
    }
}
