using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly string sandboxEndpoint = "https://api.sandbox.paypal.com";
    //api/authentiation/token
    [HttpPost(template: "token", Name = "token")]
    public async Task<IActionResult> GetAccessTokenAsync()
    {
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/oauth2/token/", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("Authorization", "Basic QWZpOWFZMVE0TlJPdTlxeHVQTmwzcVkzVXJBcWFjRkVyNUEydlFQb01FN3otMHQyeXhLSEZ1SXowRzlqRTJJUWhFbTlXLV9ZeW42M2VPUW46RUlia2RpMXBxT2daOVpPSWFMMFlsNXBWSjZMU0c5X3VNN3RZNjRnZUxpNVRwSXg5QW9HeG44T3Fna3hMSlg4ekw0bmhQMF9TTGFXWW02Uk8=");
        request.AddParameter("grant_type", "client_credentials");
        RestResponse response = await client.ExecuteAsync(request);
        return new JsonResult(response.Content);
    }

    [HttpPost(template: "vaulttoken", Name = "vaulttoken")]
    public async Task<IActionResult> GetVaultAccessTokenAsync(string customerId)
    {
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/oauth2/token/", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("Authorization", "Basic QWZpOWFZMVE0TlJPdTlxeHVQTmwzcVkzVXJBcWFjRkVyNUEydlFQb01FN3otMHQyeXhLSEZ1SXowRzlqRTJJUWhFbTlXLV9ZeW42M2VPUW46RUlia2RpMXBxT2daOVpPSWFMMFlsNXBWSjZMU0c5X3VNN3RZNjRnZUxpNVRwSXg5QW9HeG44T3Fna3hMSlg4ekw0bmhQMF9TTGFXWW02Uk8=");
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("target_customer_id", customerId);
        RestResponse response = await client.ExecuteAsync(request);
        return new JsonResult(response.Content);
    }
}
