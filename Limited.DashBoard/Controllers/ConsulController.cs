using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Limited.DashBoard.IServices;
using Microsoft.AspNetCore.Mvc;
using WebApiClient;

namespace Limited.DashBoard.Controllers
{
    [ApiController]
    [Route("limit/[controller]")]
    public class ConsulController : Controller
    {
        /// <summary>
        ///  获取缓存中的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public async Task<dynamic> getAsync()
        {
            using (var client = HttpApiClient.Create<IConsulService>())
            {
                var result = await client.GetConsulByKeyAsync("lfs");
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
            using (var client = HttpApiClient.Create<IConsulService>())
            {
                StringContent queryString = new StringContent(keyValue);
                var result = await client.PutConsulByKeyAsync("lfs", queryString);
                return result;
            }
        }
    }
}
