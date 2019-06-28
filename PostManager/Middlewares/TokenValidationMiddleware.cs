using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace PostManager.Middlewares
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public CustomAuthOptions()
        {
            //this.Scheme = "CustomScheme";
        }
    }

    public class TokenValidationHandler : AuthenticationHandler<CustomAuthOptions>
    {
        public const string SchemeName = "TokenValidationScheme";
        private readonly IHttpClientFactory _httpclientFactory;

        public TokenValidationHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IHttpClientFactory httpclientFactory)
            : base(options, logger, encoder, clock)
        {
            _httpclientFactory = httpclientFactory;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var userToken = (string)Request.Headers["token"];
            var client = _httpclientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("token", userToken);

            var urlOfValidation = Environment.GetEnvironmentVariable("MICROSERVICES_AUTH");

            var result = await client.GetAsync(urlOfValidation + "/auth/userToken");

            if (!result.IsSuccessStatusCode)
                return AuthenticateResult.Fail("could not verify user token");

            var claims = new[] { new Claim("token", userToken, null) };
            var identity = new ClaimsIdentity(claims, nameof(TokenValidationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), this.Scheme.Name);


            return AuthenticateResult.Success(ticket);
        }
    }
}
