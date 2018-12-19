using Limited.DashBoard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Limited.AspNetCore.LeeUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.LeeUIIndex();

            //app.UseFileServer(new FileServerOptions()
            //{
            //    RequestPath = PathString.FromUriComponent($"/lee"),
            //    FileProvider = (new EmbeddedFileProvider(typeof(Startup).Assembly, "Lee.AspNetCore.LeeUI.lee")),
            //    EnableDirectoryBrowsing = true
            //});
            app.UseMvc();
            app.UseService(env);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Hello world");
            });
        }
    }
}
