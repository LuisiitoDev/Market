using IdentityServer4.Dapper.Extensions;
using IdentityServer4.Dapper.Extensions.MySql;
using IdentityServer4.Models;
using luigiDev.Market.DataAccess.Identity;
using luigiDev.Market.DataAccess.ProductRepository;
using luigiDev.Market.Entities.DBConfig;
using luiguiDev.Market.Business.ProductBusiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.DataBase = Configuration.GetSection("MongoConnection:MongoDataBase").Value;
            });
            services.AddDbContext<IdentityDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("IdentityServerConnection")));
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductBusiness, ProductBusiness>();

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

            DatabaseInitializer.Initialize(app, context);
        }
    }
}
