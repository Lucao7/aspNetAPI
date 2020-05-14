using Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.General;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace WebApiNfe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            Settings settings = new Settings();
            Configuration.GetSection("Settings").Bind(settings);

            services.AddDbContext<SolutionContext>(options =>
               options.UseSqlServer(settings.ConnectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API NFe - WCI",
                        Version = "v1",
                        Description = "API NFe - WCI criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Samuel Apolion Benevenuto",
                            Url = ""
                        }
                    });

                //string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                //string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                //string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //c.IncludeXmlComments(caminhoXmlDoc);

                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "API NFe - WCI");
            });
        }
    }
}
