using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Moq;
using System.Security.Claims;

namespace Tests
{
    /// <summary>
    /// Evaluation of http request authorization and authentication
    /// </summary>
    public class FakePolicyEvaluator : IPolicyEvaluator
    {
        /// <summary>
        /// Simulates the authentication process by creating a claims principal, generating an authentication ticket, and returning a successful authentication result.
        /// </summary>
        public Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            // It creates a new instance of the ClaimsPrincipal class, which represents the user's claims or identity.
            var claimsPrincipal = new ClaimsPrincipal();
            // It then creates a new AuthenticationTicket object, which encapsulates the authenticated user's claims principal and an authentication scheme.
            var ticket = new AuthenticationTicket(claimsPrincipal, "Test");
            // It creates a new AuthenticateResult object, which encapsulates the authentication ticket.
            var result = AuthenticateResult.Success(ticket);
            // It returns the AuthenticateResult object.
            return Task.FromResult(result);
        }
        /// <summary>
        /// Creates a new instance of the PolicyAuthorizationResult class and returns it. 
        /// The PolicyAuthorizationResult.Success() method is used to create a successful authorization result without any additional information.
        /// </summary>
        public Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticationResult, HttpContext context, object? resource)
        {
            // Whenever the AuthorizeAsync method is called, it will always return a successful authorization result
            var result = PolicyAuthorizationResult.Success();
            return Task.FromResult(result); 
        }
    }
}
