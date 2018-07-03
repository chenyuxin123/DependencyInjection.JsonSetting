using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CYX.Class;
using CYX.Class2;
using CYX.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //方式1：
            List<ServiceOption> serviceOptions = new List<ServiceOption>();
            Configuration.GetSection("Services").Bind(serviceOptions);
            services.AddService(serviceOptions);

            //方式2：
            //services.AddService(Configuration);

            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IStudentService, StudentService>();
            //services.AddTransient<IFoo, Foo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUserService userService, IStudentService studentService,IFoo foo)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                userService.Add();
                studentService.Add();
                foo.Test();
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
