using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OAuth
{
    public class OAuthConfig
    {
        public static void MicrosoftConfig(OAuthOptions option)
        {
            option.ClientId = "YOUR_CLIENT_ID";
            option.ClientSecret = "YOUR_CLIENT_SECRET";
            option.AuthorizationEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";
            option.TokenEndpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/token";
            option.UserInformationEndpoint = "https://graph.microsoft.com/v1.0/users";
            option.CallbackPath = new PathString("/signin-microsoft");
            option.SaveTokens = true;
            option.Scope.Clear();
            option.Scope.Add("Calendars.Read");
            option.Scope.Add("Calendars.ReadWrite");

            //option.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
            //option.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            //option.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
            //option.ClaimActions.MapJsonKey(ClaimTypes.Email, "mail");

            option.Events = new OAuthEvents
            {
                OnCreatingTicket = async context =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);


                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();

                    var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                    context.HttpContext.Response.Cookies.Append("token", context.AccessToken);

                    context.RunClaimActions(JObject.FromObject(user));

                    var userId = user.Value<string>("displayName");
                    if (!string.IsNullOrEmpty(userId))
                    {
                        context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                    }

                    // Add the Name claim
                    var email = user.Value<string>("mail");
                    if (!string.IsNullOrEmpty(email))
                    {
                        context.Identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, email, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                    }
                },
                OnRemoteFailure = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Home/Error?message=" + context.Failure.Message);
                    return Task.FromResult(0);
                }
            };
        }
    }
}
