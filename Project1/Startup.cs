using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Project1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OAuth;
using Services;
using Infrastructure;

namespace Project1
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
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<STDbContext>(options => options.UseSqlServer(connection));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<EmailSetting>(Configuration.GetSection("EmailSetting"));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<STDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(option =>
            {
                // Password settings
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = false;
                option.Password.RequiredUniqueChars = 6;

                // Lockout settings
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                option.Lockout.MaxFailedAccessAttempts = 10;
                option.Lockout.AllowedForNewUsers = true;

                // User settings
                option.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.AddAuthentication().AddOAuth("Microsoft", options => OAuth.OAuthConfig.MicrosoftConfig(options));
            //services.AddAuthentication(option=>
            //{
            //    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            //}).AddOAuth("Microsoft", options => OAuth.OAuthConfig.MicrosoftConfig(options));
            services.AddSingleton<IEmailServices,EmailService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}



//Microsoft OAuth
//services.AddAuthentication(options =>
//        {
//            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            options.DefaultChallengeScheme = "Microsoft";
//        })
//       .AddCookie()
//       .AddOAuth("Microsoft", option =>
//       {
//           option.ClientId = Configuration["Authentication:Microsoft:ClientId"];
//           option.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
//           option.AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";
//           option.TokenEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/token";
//           option.UserInformationEndpoint = "https://graph.microsoft.com/v1.0/users";
//           option.CallbackPath = new PathString("/signin-microsoft");
//           option.SaveTokens = true;
//           option.Scope.Clear();
//           option.Scope.Add("Calendars.Read");
//           option.Scope.Add("Calendars.ReadWrite");

//           //option.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
//           //option.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
//           //option.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
//           //option.ClaimActions.MapJsonKey(ClaimTypes.Email, "mail");

//           option.Events = new OAuthEvents
//           {
//               OnCreatingTicket = async context =>
//              {
//                  var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
//                  request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                  request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);


//                  var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
//                  response.EnsureSuccessStatusCode();

//                  var user = JObject.Parse(await response.Content.ReadAsStringAsync());

//                  context.HttpContext.Response.Cookies.Append("token", context.AccessToken);    

//                  context.RunClaimActions(JObject.FromObject(user));

//                  var userId = user.Value<string>("displayName");
//                  if (!string.IsNullOrEmpty(userId))
//                  {
//                      context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
//                  }

//                  // Add the Name claim
//                  var email = user.Value<string>("mail");
//                  if (!string.IsNullOrEmpty(email))
//                  {
//                      context.Identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, email, ClaimValueTypes.String, context.Options.ClaimsIssuer));
//                  }


//              },
//               OnRemoteFailure = context =>
//               {
//                   context.HandleResponse();
//                   context.Response.Redirect("/Home/Error?message=" + context.Failure.Message);
//                   return Task.FromResult(0);
//               }
//           };
//       });





// GitHub OAuth
//services.AddAuthentication(options =>
//        {
//           options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//           options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//             options.DefaultChallengeScheme = "GitHub";
//        })
//       .AddCookie()
//       .AddOAuth("GitHub", options =>
//       {
//    options.ClientId = Configuration["GitHub:ClientId"];
//    options.ClientSecret = Configuration["GitHub:ClientSecret"];
//    options.CallbackPath = new PathString("/signin-github");

//    options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
//    options.TokenEndpoint = "https://github.com/login/oauth/access_token";
//    options.UserInformationEndpoint = "https://api.github.com/user";

//    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
//    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
//    options.ClaimActions.MapJsonKey("urn:github:login", "login");
//    options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
//    options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");

//    options.Events = new OAuthEvents
//    {
//        OnCreatingTicket = async context =>
//        {
//            var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
//            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

//            var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
//            response.EnsureSuccessStatusCode();

//            var user = JObject.Parse(await response.Content.ReadAsStringAsync());

//            context.RunClaimActions(user);
//        }
//    };
//});
