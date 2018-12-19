using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Limited.DashBoard
{
    public static class StartupExtensions
    {
        public static void UseService(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.DashBoard(); 
            app.UseFileServer(new FileServerOptions()
            {
                RequestPath = PathString.FromUriComponent($"/dashboard"), 
                FileProvider = (new EmbeddedFileProvider(typeof(StartupExtensions).Assembly, "Limited.DashBoard.UI")),
                EnableDirectoryBrowsing = true
            });
        }
    }
}
