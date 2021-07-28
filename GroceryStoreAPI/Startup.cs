using GroceryStoreAPI.IServices;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;
namespace GroceryStoreAPI
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
            services.AddHttpClient();
            services.AddDbContext<Prod_CustomersContext>(options => options.UseSqlServer(Configuration["DbConnection"]));
            services.AddTransient<ICustomersService, CustomersService>();

            //******** Below code we need to use for Token uthntication.......

            //services
                //.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //.AddJwtBearer(options =>
                //{
                //    options.Events = new JwtBearerEvents
                //    {
                //        OnAuthenticationFailed = context =>
                //        {
                //            Debug.Write(context.Exception);
                //            return Task.CompletedTask;
                //        }
                //    };
                //    options.SaveToken = true;
                //    options.IncludeErrorDetails = true;
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuer = false,
                //        ValidateActor = false,
                //        ValidateLifetime = false,
                //        ValidateIssuerSigningKey = false,
                //        IssuerSigningKeyResolver = ResolveIssuerSigningKey

                //    };
                //});
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        private IEnumerable<SecurityKey> ResolveIssuerSigningKey(string token, SecurityToken securityToken, string kid,TokenValidationParameters validationParameters)
        {
            if(securityToken is JwtSecurityToken jwtSecurityToken)
            {
                var tokenKey = (string)jwtSecurityToken.Header[JwtHeaderParameterNames.Jku];
                return GetSecurityKeys(tokenKey);
            }
            return null;
        }
        private IEnumerable<SecurityKey> GetSecurityKeys(string keySetUrl)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(keySetUrl).Result;
            var keySet = JsonConvert.DeserializeObject<JsonWebKeySet>(response);
            return keySet.GetSigningKeys();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
