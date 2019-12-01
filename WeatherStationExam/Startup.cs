﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace WeatherStationExam
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //her tilføjer vi swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info{Title = "Vejrstation API", Version = "v1.0"});
                }
            );

            //CORS snask
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //mere swagger snask
            app.UseSwagger();

            app.UseSwaggerUI
            (
                c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vejrstation API v1.0")
            );

            //mere CORS snask
            app.UseCors
            (
                options => { options.AllowAnyOrigin().AllowAnyMethod(); }
            );

            app.UseMvc();
        }
    }
}
