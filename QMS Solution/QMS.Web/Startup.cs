using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QMS.Core.Database;
using QMS.Core.Providers;
using QMS.Core.Services;
using QMS.Database;
using QMS.Domain.ConfigSections;
using QMS.Domain.Constants;
using QMS.Infrastructure.Providers;
using QMS.Infrastructure.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Linq;
using System.Text;

namespace QMS.Web
{
    public class Startup
    {
        private const string _cors = "QMSCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers();

            services.AddCors(options=> {
                options.AddPolicy(_cors,
                    builder=> builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.Configure<AppSettings>(Configuration.GetSection(ConfigurationConstants.AppSettings));

            #region Setup PingAuthentication config
            services.Configure<PingAuthentication>(Configuration.GetSection(ConfigurationConstants.PingAuthentication));
            #endregion

            #region Setup EpmsApi config
            services.Configure<EpmsApi>(Configuration.GetSection(ConfigurationConstants.EpmsApi));
            #endregion

            #region JWT
            var appSettings = Configuration.GetSection(ConfigurationConstants.AppSettings).Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "QMS",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new[] { "readAccess", "writeAccess" }
                    }
                });
            });
            #endregion

            #region Databases
            services.AddHttpContextAccessor();
            var constring = Configuration.GetSection(ConfigurationConstants.ConnectionStrings).Get<ConnectionStrings>();
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(options => options.UseSqlServer(constring.WebApiConnection));
            services.AddTransient<IDataContext>(provider => provider.GetService<DataContext>());
            #endregion

            #region Application Services Configuration
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            services.AddTransient<IPingService, PingService>();
            #endregion

            #region Mediator
            var queryAssembly = AppDomain.CurrentDomain.Load("QMS.Queries");
            var commandAssembly = AppDomain.CurrentDomain.Load("QMS.Commands");
            services.AddMediatR(queryAssembly, commandAssembly);
            #endregion

            #region Automapper
            //AutoMapperConfiguration.Initialize();
            var mapperAssembly = AppDomain.CurrentDomain.Load("QMS.Mapper");
            services.AddAutoMapper(mapperAssembly);
            #endregion

            services.AddSpaStaticFiles(options => options.RootPath = "wwwroot");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QMS Api v1");
                c.DocumentTitle = "QMS APIs";
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();
                      
            app.UseRouting();
            app.UseAuthentication();
            app.UseCors(_cors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "clientapp";
            });
        }
    }
}
