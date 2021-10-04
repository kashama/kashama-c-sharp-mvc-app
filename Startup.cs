using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MYMVCAPP
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
            services.AddControllersWithViews();//THIS METHOD IS USED TO TELL ASP.NET CORE KNOW THAT WE ARE GOING TO USE CONTROLLER AND VIEWS IN OUR APPLICATION
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //my first middleware

             app.Use(async(context, next)=>
            {
                await context.Response.WriteAsync("Hello from my first middleware \n");
                await next(); // this method allow to pass from the first middleware to the second middleware
                await context.Response.WriteAsync("Hello from my first middleware response\n");
            });
             //my second middleware
            app.Use(async(context, next)=>
            {
                await context.Response.WriteAsync("Hello from my second middleware\n");
                await next(); // this method allow to pass from the second middleware to the third middleware 
                await context.Response.WriteAsync("Hello from my second middleware response\n");         
            });
             //my third middleware
            app.Use(async(context, next)=>
            {
                await context.Response.WriteAsync("Hello from my third middleware\n");
                await context.Response.WriteAsync("Hello from my third middleware response\n");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();//allow to use static files(wwwroot files)
            app.UseStaticFiles(new StaticFileOptions());//to use static files outsite of wwwroot directory

            app.UseRouting();//this moddleware is used to map the url to a particular resource.

            app.UseAuthorization();
             // TO  READ ENVIRONMENT PROPERTIES
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => {
                    if (env.IsDevelopment())
                    {
                        await context.Response.WriteAsync("This is dev. environment");
                    }
                    else if (env.IsProduction())
                    {
                        await context.Response.WriteAsync("This is prod. environment");

                    }
                    else if(env.IsStaging())
                    {
                        await context.Response.WriteAsync("This is stag. environment");
                    }
                    else
                    await context.Response.WriteAsync(env.EnvironmentName);
                });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context => {
                    await context.Response.WriteAsync("Hello everyone");
                });
            }); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            }); 
        }
    }
}
