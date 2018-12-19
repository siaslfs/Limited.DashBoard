using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace Limited.AspNetCore.LeeUI
{
    public static class LeeUIIndexMiddlewareExtensions
    {
        private const string EmbeddedFilesNamespace = "Lee.AspNetCore.LeeUI.lee";

        public static IApplicationBuilder LeeUIIndex(this IApplicationBuilder app ,Action<LeeUIOptions> setupAction = null)
        {
            //LeeUIOptions LeeUIOptions = new LeeUIOptions();
            //setupAction?.Invoke(LeeUIOptions); 
            //UseMiddlewareExtensions.UseMiddleware<LeeUIIndexMiddleware>(app, new object[1]
            //{
            //LeeUIOptions
            //});
            //FileServerOptions val = new FileServerOptions();
            //val.RequestPath = PathString.FromUriComponent(string.IsNullOrEmpty(LeeUIOptions.RoutePrefix) ? string.Empty : $"/{LeeUIOptions.RoutePrefix}");
            //val.FileProvider = (new EmbeddedFileProvider(typeof(LeeUIIndexMiddlewareExtensions).GetTypeInfo().Assembly, "Lee.AspNetCore.LeeUI.lee"));
            //FileServerExtensions.UseFileServer(app, val);
            //return app;

            return app.UseMiddleware<LeeUIIndexMiddleware>();

        }
    }
}
