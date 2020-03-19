using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;

//new PhysicalFileProvider
//Path.Combine(Directory.GetCurrentDirectory())
namespace CNIT134Empty
{
    public class startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();  //default initial page
            app.UseStaticFiles();   //line line for wwwroot

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                    RequestPath = new PathString("/app-images")
            });


            /*
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"Images")),
                    RequestPath = new PathString("/app-images")
            });
            */

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
