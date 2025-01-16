using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisputeController : ControllerBase
{
    private AuthenticationController authController = new AuthenticationController();
    private readonly string sandboxEndpoint = "https://api.sandbox.paypal.com";
    private PayPalRequestBody paypalRequestBody = new PayPalRequestBody();

    private Token getAccessToken()
    {
        var response = authController.GetAccessTokenAsync().Result as JsonResult;
        var token = JsonConvert.DeserializeObject<Token>(response.Value.ToString());
        Console.Write(token.Access_token);
        return token;
    }

    [HttpGet(template: "list", Name = "listdispute")]
    public async Task<IActionResult> ListDispute()
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/customer/disputes", Method.Get);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
}
