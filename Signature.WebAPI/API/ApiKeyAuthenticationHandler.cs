using System.Security.Claims;
using System.Text.Encodings.Web;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using SignatureApplication.Organizations.Query.GetOrganizationByApiKey;

namespace Signature.WebAPI.API;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IMediator mediator;
    private const string ApiKeyHeaderName = "X-API-KEY";

    public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IMediator mediator) : base(options, logger, encoder)
    {
        this.mediator = mediator;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
        {
            return AuthenticateResult.Fail("API Key was not provided.");
        }

        var organizationDb = await mediator.Send(new GetOrganizationByApiKeyQuery() { ApiKey = extractedApiKey });

        if (organizationDb == null)
        {
            return AuthenticateResult.Fail("Invalid API Key provided.");
        }

        var claims = new[] { new Claim(ClaimTypes.Name, "ApiKeyUser") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
