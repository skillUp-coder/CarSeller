using CarSeller.API.Config;
using CarSeller.DataAccess.EF;
using CarSeller.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace CarSeller.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.SetJwtBearer(this._configuration);
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(this._configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
            services.AddControllers().AddNewtonsoftJson(options =>
                                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.SetInterfaceDI();
            services.SetMapperDI();

            services.AddSwaggerGen(opt => 
            {
                opt.ResolveConflictingActions(apiDesc => apiDesc.First());
            });

            services.BuildServiceProvider().GetService<DataContext>().Database.Migrate();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SetSwagger(this._configuration);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
