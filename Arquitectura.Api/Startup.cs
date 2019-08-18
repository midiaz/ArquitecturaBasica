using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Arquitectura.IoC;
using Arquitectura.Utiles;
using Arquitectura.Api.Opciones;
using Swashbuckle.AspNetCore.Swagger;

namespace Arquitectura.Api
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
            
            services.Configure<Keys>(Configuration.GetSection("Keys"));
            string connectionString = Configuration.GetConnectionString("SQLServer");
            services.configurarConnectionString(connectionString);
            services.registrarServicioRepositorio();
            services.registrarServicioNegocio();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var swaggerOptions = new SwaggerConfig();
            Configuration.GetSection(nameof(SwaggerConfig)).Bind(swaggerOptions);
            services.AddSwaggerGen(x=>x.SwaggerDoc(swaggerOptions.Version, new Info {Title= swaggerOptions.Descripcion, Version= swaggerOptions.Version }));
            //// Register the Swagger generator, defining one or more Swagger documents
            //services.AddSwaggerGen(swagger =>
            //{
            //    var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
            //    swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
            //                       new Info
            //                       {
            //                           Title = SwaggerConfiguration.DocInfoTitle,
            //                           Version = SwaggerConfiguration.DocInfoVersion,
            //                           Description = SwaggerConfiguration.DocInfoDescription,
            //                           Contact = contact
            //                       }
            //                        );
            //});
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
            app.UseStaticFiles();
            var swaggerOptions = new SwaggerConfig();
            Configuration.GetSection(nameof(SwaggerConfig)).Bind(swaggerOptions);
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Descripcion); });



            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
