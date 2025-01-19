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
        request.AddHeader("Authorization", "Basic QVNOeXRZcUNYZTBTQ0dFeXBfQy1vM2kyUzNhMFhZQVNEdnJSeWZrMy00eDVHZ3JYU3BpZEpNOGdRWXNXMm94VmhtTnZWZmF5NzdjNENEbVA6RUFSdW5rYkFyVHhYM3h0elAxeV8xLTBUSlYtNC1EVjRzV0FZaWQzb05yMDJpXzJDY0RCdXBROWxDWThELUFoeWVoUFA1Qk1zZTlFZm1nc1I=");
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
        request.AddHeader("Authorization", "Basic QVNOeXRZcUNYZTBTQ0dFeXBfQy1vM2kyUzNhMFhZQVNEdnJSeWZrMy00eDVHZ3JYU3BpZEpNOGdRWXNXMm94VmhtTnZWZmF5NzdjNENEbVA6RUFSdW5rYkFyVHhYM3h0elAxeV8xLTBUSlYtNC1EVjRzV0FZaWQzb05yMDJpXzJDY0RCdXBROWxDWThELUFoeWVoUFA1Qk1zZTlFZm1nc1I=");
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("response_type", "id_token");
        request.AddParameter("target_customer_id", customerId);
        RestResponse response = await client.ExecuteAsync(request);
        return new JsonResult(response.Content);
    }

    [HttpPost(template: "idtoken", Name = "vaultidtoken")]
    public async Task<IActionResult> GetVaultIdAccessTokenAsync()
    {
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/oauth2/token/", Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddHeader("Authorization", "Basic QVNOeXRZcUNYZTBTQ0dFeXBfQy1vM2kyUzNhMFhZQVNEdnJSeWZrMy00eDVHZ3JYU3BpZEpNOGdRWXNXMm94VmhtTnZWZmF5NzdjNENEbVA6RUFSdW5rYkFyVHhYM3h0elAxeV8xLTBUSlYtNC1EVjRzV0FZaWQzb05yMDJpXzJDY0RCdXBROWxDWThELUFoeWVoUFA1Qk1zZTlFZm1nc1I=");
        request.AddParameter("grant_type", "client_credentials");
        request.AddParameter("response_type", "id_token");
        RestResponse response = await client.ExecuteAsync(request);
        return new JsonResult(response.Content);
    }

    [HttpPost(template: "code", Name = "authorizationcode")]
    public async Task<IActionResult> GetAuthorizationCode(string code)
    {
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/oauth2/token", Method.Post);
        request.AddHeader("Authorization", "Basic QVNOeXRZcUNYZTBTQ0dFeXBfQy1vM2kyUzNhMFhZQVNEdnJSeWZrMy00eDVHZ3JYU3BpZEpNOGdRWXNXMm94VmhtTnZWZmF5NzdjNENEbVA6RUFSdW5rYkFyVHhYM3h0elAxeV8xLTBUSlYtNC1EVjRzV0FZaWQzb05yMDJpXzJDY0RCdXBROWxDWThELUFoeWVoUFA1Qk1zZTlFZm1nc1I=");
        request.AddHeader("Content-Type", "text/plain");
        var body = @"grant_type=authorization_code&code=" + code;
        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        RestResponse response = await client.ExecuteAsync(request);
        return new JsonResult(response.Content);
    }
}
