using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Object_B.Models.Context;
using Object_B.Models;
using Auth.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Object_B.Services;
using Object_B.hubs;
using System.Linq;
using static Object_B.Services.CalculationCoordinatesService;

namespace Object_B
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });
            services.AddTransient<IMapSaveService, MapSaveService>();
            services.AddSignalR();
            services.AddControllersWithViews();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AllDataContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<SingltonService>();
            services.AddTransient<CreateVisitService>();
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddCors();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AllDataContext context, SingltonService singlton)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            ClearUsers(context, singlton);
            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyMethod()
                      .AllowAnyHeader();
                builder.WithOrigins("http://127.0.0.1:5500").AllowCredentials();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<HubService>("/chat");
            });

            SampleData.Initialize(context);
        }

        private static void ClearUsers(AllDataContext context, SingltonService singlton)
        {
            singlton.dictionaryCoords = new System.Collections.Generic.Dictionary<string, Square>();
            var convertRoomsService = new ConvertRoomsService(context);
            singlton.rooms = convertRoomsService.CalculationCoordinates();
            var users = context.Users.ToList();
            foreach (var i in users)
            {
                i.IsActive = false;
            }
            context.SaveChanges();
        }
    }
}
