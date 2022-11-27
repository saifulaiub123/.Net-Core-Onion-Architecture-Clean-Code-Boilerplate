using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentGoInfrastructure.DBContext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using RentGo.Api.Authentication;
using RentGo.Api.Dependency;
using RentGo.Api.Middleware;
using RentGo.Application.Dependency;
using RentGo.Application.Helper;
using RentGo.Domain.Constant;
using RentGo.Domain.DBModel;
using RentGo.Infrastructure.Dependency;

namespace Api
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
            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddFluentValidation(
                    v => v.RegisterValidatorsFromAssembly(typeof(RegisterApplication).Assembly)
                ); ;

            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString(ConfigOptions.DbConnName),
                            options => options.EnableRetryOnFailure())
                );

            // For Identity  
            services.AddIdentity<ApplicationUser, UserRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddServices();
            services.AddRepositories();
            services.ApplicationServices();
            services.TokenAuthentication(Configuration);

            services.AddAutoMapper(typeof(ApplicationDbContext));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}