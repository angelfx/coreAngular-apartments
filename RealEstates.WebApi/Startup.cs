using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RealEstates.Abstract;
using RealEstates.Abstract.Logic;
using RealEstates.Abstract.Service;
using RealEstates.BLL.Logic;
using RealEstates.BLL.Service;
using RealEstates.DAL.LocalDB;

namespace RealEstates.WebApi
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
            string con = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IDALContext, RealEstateContext>(options => options.UseSqlServer(con));
            services.AddScoped<IRealEstateService, RealEstatesService>();
            services.AddTransient<IApartmentsImport, ApartmentsFileImport>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            })); //Задаем политику CORS

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseMvc();
        }
    }
}
