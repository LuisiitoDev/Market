using IdentityServer4.Dapper.Extensions;
using luigiDev.Market.DataAccess.Identity;
using luigiDev.Market.DataAccess.ProductRepository;
using luigiDev.Market.DataAccess.StoreRepository;
using luigiDev.Market.DataAccess.UserRepository;
using luigiDev.Market.Entities.DBConfig;
using luiguiDev.Market.Business.ProductBusiness;
using luiguiDev.Market.Business.StoreBusiness;
using luiguiDev.Market.Business.UserBusiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace luigiDev.Market.Api
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

            // Register the swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version  = "v1",
                    Title = "Online Market Api",
                    Description = "this is a POC of a online market using .net core technology, and some of OAuth2 and MongoBD as DataBase to store data",
                    Contact = new OpenApiContact
                    {
                        Name = "Luis Sandoval"
                    }
                });
            });

            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DataBase = Configuration.GetSection("MongoConnection:MongoDataBase").Value;
            });
            services.AddDbContext<IdentityDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("IdentityServerConnection")));

            // Dependencies required
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IStoreService, StoreService>();
            services.AddTransient<IStoreBusiness, StoreBusiness>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IUserService, UserService>();

            //IDENTITY SERVER CONFIGURATION
            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddConfigurationStore(option => option.ConfigureDbContext = builder => builder.UseMySQL(Configuration.GetConnectionString("IdentityServerConnection"), options => options.MigrationsAssembly("luigiDev.Market.DataAccess")))
                    .AddOperationalStore(option => option.ConfigureDbContext = builder => builder.UseMySQL(Configuration.GetConnectionString("IdentityServerConnection"), options => options.MigrationsAssembly("luigiDev.Market.DataAccess")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IdentityDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to generated Swagger as a Json Endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (html, css, js, etc) and specifying the swagger json endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            DatabaseInitializer.Initialize(app, context);
        }
    }
}
