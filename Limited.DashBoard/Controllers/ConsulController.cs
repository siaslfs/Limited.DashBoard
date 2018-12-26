using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Limited.DashBoard.Common;
using Limited.DashBoard.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiClient;

namespace Limited.DashBoard.Controllers
{
    [ApiController]
    [Route("limit/[controller]")]
    public class ConsulController : Controller
    {
        public ConfigOptions configOptions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_configOptions"></param>
        public ConsulController(IOptionsSnapshot<ConfigOptions> _configOptions)
        {
            this.configOptions = _configOptions.Value;
        }
        /// <summary>
        ///  获取缓存中的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<dynamic> getAsync()
        {
            using (var client = HttpApiClient.Create<IConsulService>(configOptions.ConsulHost))
            {

                var result = await client.GetConsulByKeyAsync(configOptions.ConfiguredKey);
                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("put")]
        public async Task<dynamic> PutAsync([FromForm]string keyValue)
        {
            using (var client = HttpApiClient.Create<IConsulService>(configOptions.ConsulHost))
            {
                StringContent queryString = new StringContent(keyValue);
                var result = await client.PutConsulByKeyAsync(configOptions.ConfiguredKey, queryString);
                return result;
            }
        }
    }
}
