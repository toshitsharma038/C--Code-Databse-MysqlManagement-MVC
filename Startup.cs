using CoolApi.Models;
using CoolApi.Repository;
using CoolApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CoolApi
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
            string ConnectionStrings = Configuration.GetConnectionString("IdentityConnection");
         
           //services.AddScoped<IStudentDao,StudentDaoImpl>();
           //services.AddScoped<IStudentService,StudentServiceImpl>();
            
            services.AddDbContext<StudentContext>(opt =>opt.UseSqlServer(ConnectionStrings));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoolApi", Version = "v1" });
            });

            //Connection to 
            //Register To interface to application
             var connectionString = Configuration["ConnectionString:DefaultConnection"];
             
             services.AddTransient<IStudentService,StudentServiceImpl>();
             services.AddTransient<IStudentDao,StudentDaoImpl>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseAuthorization();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoolApi v1"));
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
