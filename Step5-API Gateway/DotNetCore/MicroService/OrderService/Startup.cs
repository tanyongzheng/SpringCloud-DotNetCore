using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderService.Controllers;
using Pivotal.Discovery.Client;
using Steeltoe.CircuitBreaker.Hystrix;

namespace OrderService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加注入配置
            services.AddScoped<Controllers.IUserService, Controllers.UserService>();
            // 注册使用HystrixCommand类封装UserService方法做断路器的命令类
            services.AddHystrixCommand<UsergetAllCommand>("userservice", Configuration);
            services.AddHystrixCommand<UsergetPortCommand>("userservice", Configuration);
            //判断是否能获取Eureka配置
            if (Configuration.GetSection("eureka").GetChildren().Any())
            {
                //添加Steeltoe服务发现客户端服务配置
                services.AddDiscoveryClient(Configuration);
            }
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            //判断是否能获取Eureka配置
            if (Configuration.GetSection("eureka").GetChildren().Any())
            {
                //使用服务发现客户端
                app.UseDiscoveryClient();
            }
        }
    }
}
