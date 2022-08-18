using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GwesReportApi.Inventory;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using GwesReportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GwesReportApi
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
            /*Assignement Section*/
            string secret = Configuration.GetValue<string>("AppSettings:Secret");
            string aesKey = Configuration.GetValue<string>("AppSettings:AesKey");
            bool validateLifetime = false;
            if (Configuration.GetValue<string>("AppSettings:ValidateLifetime") == "true") { validateLifetime = true; } 
            bool validateIssuerSigningKey = false;
            if (Configuration.GetValue<string>("AppSettings:ValidateIssuerSigningKey") == "true") { validateIssuerSigningKey= true; }
            bool validateAudience = false;
            if (Configuration.GetValue<string>("AppSettings:ValidateAudience") == "true") { validateAudience= true; }
            bool validateIssuer = false;
            if (Configuration.GetValue<string>("AppSettings:ValidateIssuer") == "true") { validateIssuer=true; } 
            string validAudience=Configuration.GetValue<string>("AppSettings:ValidAudience");
            string validIssuer=Configuration.GetValue<string>("AppSettings:ValidIssuer"); 
            string validIPAddress=Configuration.GetValue<string>("AppSettings:ValidIPAddress");         
            /**/
            services.AddDbContext<GwesDbContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors();
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = validateIssuer,
                            ValidateAudience = validateAudience,
                            ValidateLifetime = validateLifetime,
                            ValidateIssuerSigningKey = validateIssuerSigningKey,
                            ValidIssuer = validIssuer,
                            ValidAudience = validAudience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("AppSettings:Secret")))
                        };
                    });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());                        
            app.UseEndpoints(x => x.MapControllers());
            
        }
    }
}
