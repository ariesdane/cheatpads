﻿using System.Collections.Generic;
using Microsoft.AspNet.Builder;

using Microsoft.AspNet.Authentication.OpenIdConnect;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CheatPads.Clients.MVC
{


    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIISPlatformHandler();
            app.UseDeveloperExceptionPage();

            app.UseCookieAuthentication(options =>
            {
                options.AuthenticationScheme = "Cookies";
                options.AutomaticAuthenticate = true;
            });

            app.UseOpenIdConnectAuthentication(options =>
            {
                options.AuthenticationScheme = "oidc";
                options.SignInScheme = "Cookies";
                options.AutomaticAuthenticate = true;
                options.SaveTokensAsClaims = false;
                
                options.Authority = "https://localhost:44345";
                options.PostLogoutRedirectUri = "http://localhost:2221/";

                options.ClientId = "CheatPads.Clients.MVC";
                options.ResponseType = "id_token token";
                options.ResponseMode = "form_post";

                options.Scope.Add("openid");
                options.Scope.Add("email");
                options.Scope.Add("profile");
                options.Scope.Add("userEvents");
                
                options.Events = new OpenIdConnectEvents
                {
                    OnAuthenticationValidated = data =>
                    {
                        var incoming = data.AuthenticationTicket.Principal;
                        var id = new ClaimsIdentity("application", "given_name", "role");

                        id.AddClaim(incoming.FindFirst("sub"));
                        id.AddClaim(incoming.FindFirst("email"));
                        id.AddClaim(incoming.FindFirst("email_verified"));
                        id.AddClaim(incoming.FindFirst("given_name"));
                        id.AddClaim(new Claim("access_token", data.ProtocolMessage.AccessToken));
                        id.AddClaim(new Claim("id_token", data.ProtocolMessage.IdToken));
                        id.AddClaim(new Claim("expires_at", DateTime.Now.AddSeconds(double.Parse(data.ProtocolMessage.ExpiresIn)).ToString()));

                        data.AuthenticationTicket = new AuthenticationTicket(
                            new ClaimsPrincipal(id),
                            data.AuthenticationTicket.Properties,
                            data.AuthenticationTicket.AuthenticationScheme);

                        return Task.FromResult(0);
                    },
                    OnRedirectToEndSessionEndpoint = data =>
                    {
                        var user = data.HttpContext.User;
                        var idToken = user.FindFirst("id_token");

                        if (idToken != null)
                        {
                            data.ProtocolMessage.IdTokenHint = idToken.Value;
                        }

                        return Task.FromResult(0);
                    }
                };

            });

            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}