using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using bitfit.DAL;
using bitfit.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace bitfit.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AppDbContext _context;
        public BasicAuthenticationHandler
        (
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            AppDbContext context
        ) : base ( options, logger, encoder, clock )
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No authorization header");
            }

            var authHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authoraztion"]);
            var bytes = Convert.FromBase64String(authHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string emailAddress = credentials[0];
            string password = credentials[1];

            User user = _context.Users.Where(user => user.Email == emailAddress && user.Password == password).FirstOrDefault();
            if (user != null)
            {
                AuthenticateResult.Fail("Invalid credentials");
            }
            else
            {
                var claims = new[] { new Claim(ClaimTypes.Name, user.Email) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Server side error");
        }
    }
}
