using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CarPark.WebServer
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSignalR()
                    .AddStackExchangeRedis(o =>
                    {
                        o.ConnectionFactory = async writer =>
                        {
                            var config = new ConfigurationOptions
                            {
                                AbortOnConnectFail = false
                            };
                            config.EndPoints.Add(IPAddress.Loopback, 0);
                            config.SetDefaultPorts();
                            var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
                            connection.ConnectionFailed += (_, e) =>
                            {
                                Console.WriteLine("Connection to Redis failed.");
                            };

                            if (!connection.IsConnected)
                            {
                                Console.WriteLine("Did not connect to Redis.");
                            }

                            return connection;
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSignalR(route =>
            {
                route.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
