using DataService.src.Database;
using DataService.src.Repository;
using ExternalService.src;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PassportRecognitionProject.src.Services;
using Shared.Models;

namespace PassportRecognitionProject
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PassportRecognitionProject", Version = "v1" });
            });

            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IExternalRecognitionService, ExternalRecognitionService>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IRequestSender, RegulaRequestSender>();
            services.AddScoped<IDbRepository<MongoDataModel>, MongoDbRepository>();
            services.Configure<ExternalServiceInfo>(Configuration.GetSection("ExternalServiceInfo"));
            services.Configure<MongoDbInfo>(Configuration.GetSection("MongoDbInfo"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PassportRecognitionProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
