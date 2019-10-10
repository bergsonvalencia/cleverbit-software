using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleverbitSoftware.WebApi.Integration.Requests.ArticleManagementRequests;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ArticleManagement.Core.Interfaces;
using ArticleManagement.Core.Services;
using ArticleManagement.Core.Validators;
using ArticleManagement.Infrastructure.Data;
using ArticleManagement.Infrastructure.Data.Interfaces;
using SharedKernel.CleverbitSoftware;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CleverbitSoftware.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public string WebApiName => "Cleverbit Software API";
        public string WebApiVersion => "v1";
        public string AppSettings => "appsettings";
        public string ConnectionStringName => "DbConnection";

        public Startup(IHostingEnvironment env)
        {
            BuildConfiguration(env);
            DomainEvents.Init();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();
            services.AddSingleton(Configuration);
            AddScopedDbEntities(services);
            AddScopedServicesAndValidators(services);
            AddSwaggerGen(services);
            SetupAuthentication(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            SetupSwagger(app);
            SetupCors(app);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        private void AddScopedDbEntities(IServiceCollection services)
        {
            services.AddDbContext<ArticleManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringName)));
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        private static void AddScopedServicesAndValidators(IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IValidator<CreateCommentRequest>, CreateCommentValidator>();
        }

        private void SetupAuthentication(IServiceCollection services)
        {
            var jwtSecret = Configuration.GetSection("Authentication:JwtSecret").Value;
            var googleSection = Configuration.GetSection("Authentication:Google");
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                })
                .AddGoogle(options =>
                {
                    options.ClientId = googleSection["ClientId"];
                    options.ClientSecret = googleSection["ClientSecret"];
                });
        }

        private void AddSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(WebApiVersion, new Info { Title = WebApiName, Version = WebApiVersion });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });
        }

        private void BuildConfiguration(IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"{AppSettings}.json", false, true)
                .AddJsonFile($"{AppSettings}.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            Configuration = configBuilder.Build();
        }

        private void SetupSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{WebApiVersion}/swagger.json", $"{WebApiName} {WebApiVersion}");
                c.DocExpansion(DocExpansion.None);
            });
        }

        private static void SetupCors(IApplicationBuilder app)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        }
    }
}
