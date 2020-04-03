using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PM.Api.Domain.Commands.v1;
using PM.Api.Domain.Queries.v1;
using PM.Api.IoC;

namespace PM.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddCors(o => o.AddPolicy(Configuration["CorsPolicy:Name"], builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build()))
                .AddAutoMapper(typeof(Startup))
                .AddSwaggerGen(c => c.SwaggerDoc(Configuration["SwaggerGen:Name"], new OpenApiInfo
                {
                    Title = Configuration["SwaggerGen:OpenApiInfo:Title"],
                    Version = Configuration["SwaggerGen:OpenApiInfo:Version"],
                    Description = Configuration["SwaggerGen:OpenApiInfo:Description"]
                }))
                .AddMediatR(typeof(AbstractCommand), typeof(AbstractQuery<>))
                .AddRepositories()
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint(Configuration["SwaggerEndpoint:Url"], Configuration["SwaggerEndpoint:Name"]))
                .UseCors(Configuration["CorsPolicy:Name"])
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/health");
                });
        }
    }
}
