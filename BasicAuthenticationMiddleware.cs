using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AuthenticationSchemaProblem
{
    public class BasicAuthenticationMiddleware : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationMiddleware(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), "BasicAuth");
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
