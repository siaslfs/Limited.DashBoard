using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Limited.DashBoard.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Limited.DashBoard.Demo
{
    public class Startup
    {
        /// <summary>
        /// 配置对象
        /// </summary>
        public IConfiguration Configuration { get; }

        public IHostingEnvironment Env { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置注入</param>
        /// <param name="env">The env.</param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            //读取配置文件
            services.Configure<ConfigOptions>(x =>
            {
                x.ConsulHost = Configuration.GetSection("ConsulStrings:ConsulHost").Value;
                x.ConfiguredKey = Configuration.GetSection("ConsulStrings:ConfiguredKey").Value;
                x.UnconfiguredKey = Configuration.GetSection("ConsulStrings:UnconfiguredKey").Value;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc();
            app.UseService(env);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<a href=\"/DashBoard\">Skip</a>");
            });
        }
    }
}
