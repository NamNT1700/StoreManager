using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using StoreManager.Extensions;
using System;
using System.IO;
using System.Text;

namespace StoreManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddAutoMapper(typeof(Startup));
            services.AddCors(options =>
            {

                options.AddPolicy(name: "Origins",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://http://localhost:2002/", "http://localhost:4200/")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowAnyOrigin();


                                  });
            });
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureMySqlContext(Configuration);
            services.ConfigureRepositoryWrapper();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LicenseManager API",
                    Version = "v1",
                    Description = "LicenseManager Service."
                });
                var filePath = @"wwwroot/xml/abc.xml";
                c.IncludeXmlComments(filePath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ConstruxivIdentity",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                c.IncludeXmlComments(filePath);
                c.MapType(typeof(IFormFile), () => new OpenApiSchema() { Type = "file", Format = "binary" });
            });
            services.AddAuthentication(otp =>
            {
                otp.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                otp.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
         .AddJwtBearer(options =>
         {
             options.RequireHttpsMetadata = false;
             options.SaveToken = true;
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                  //ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  //ValidIssuer = issuer,
                  //ValidAudience = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                 ClockSkew = TimeSpan.Zero
             };
         });
            //  services.AddAuthentication("Bearer")
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "https://localhost:2000";

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false
            //    };
            //});
            //  services.AddAuthorization(options =>
            //  {
            //      options.AddPolicy("ApiScope", policy =>
            //      {
            //          policy.RequireAuthenticatedUser();
            //          policy.RequireClaim("User", "Admin");
            //      });
            //  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("Origins");
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
           

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LicenseManager API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
