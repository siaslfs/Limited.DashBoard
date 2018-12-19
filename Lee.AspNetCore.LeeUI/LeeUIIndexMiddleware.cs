using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Limited.AspNetCore.LeeUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Limited.AspNetCore.LeeUI
{
    public class LeeUIIndexMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LeeUIOptions _options = new LeeUIOptions();

        public LeeUIIndexMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string method = httpContext.Request.Method;
            PathString path = httpContext.Request.Path;
            string value = path.Value;
            if (method == "GET" && Regex.IsMatch(value, $"^/lee?$"))
            {
                string redirectPath = value + "/index.html";
                RespondWithRedirect(httpContext.Response, redirectPath);
            }
            else if (!(method == "GET") || !Regex.IsMatch(value, $"/lee/?index.html"))
            {
                await _next.Invoke(httpContext);
            }
            else
            {
                await RespondWithIndexHtml(httpContext.Response);
            }
        }

        private void RespondWithRedirect(HttpResponse response, string redirectPath)
        {
            //IL_0017: Unknown result type (might be due to invalid IL or missing references)
            response.StatusCode = 301;
            StringValues sv = new StringValues(redirectPath);
            response.Headers.Add("Location", sv);
        }

        private async Task RespondWithIndexHtml(HttpResponse response)
        {
            response.StatusCode = 200;
            response.ContentType = "text/html";
            List<string> namelist = new List<string>();
            foreach (string str in this.GetType().Assembly.GetManifestResourceNames())
            {
                namelist.Add(str);
            }
            Stream stream = this.GetType().Assembly.GetManifestResourceStream("Lee.AspNetCore.LeeUI.index.html");

            StringBuilder stringBuilder = new StringBuilder(new StreamReader(stream).ReadToEnd());
            foreach (KeyValuePair<string, string> indexParameter in GetIndexParameters())
            {
                stringBuilder.Replace(indexParameter.Key, indexParameter.Value);
            }
            await HttpResponseWritingExtensions.WriteAsync(response, stringBuilder.ToString(), Encoding.UTF8, default(CancellationToken));

        }

        private IDictionary<string, string> GetIndexParameters()
        {
            return new Dictionary<string, string>
        {
            {
                "%(DocumentTitle)","Lee UI"
            },
            {
                "%(HeadContent)",""
            },
            {
                "%(ConfigObject)",SerializeToJson(_options.ConfigObject)
            },
            {
                "%(OAuthConfigObject)", SerializeToJson(_options.OAuthConfigObject)
            }
        };
        }

        private string SerializeToJson(JObject jObject)
        {
            JsonSerializerSettings val = new JsonSerializerSettings();
            val.NullValueHandling = 0;
            val.Formatting = 0;
            return JsonConvert.SerializeObject((object)jObject, val);
        }
    }
}
