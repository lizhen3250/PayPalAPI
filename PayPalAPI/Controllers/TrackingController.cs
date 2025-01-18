using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackingController : ControllerBase
{
    private AuthenticationController authController = new AuthenticationController();
    private PayPalRequestBody requestBody = new PayPalRequestBody();
    private readonly string sandboxEndpoint = "https://api.sandbox.paypal.com";
    private PayPalRequestBody paypalRequestBody = new PayPalRequestBody();

    private Token getAccessToken()
    {
        var response = authController.GetAccessTokenAsync().Result as JsonResult;
        var token = JsonConvert.DeserializeObject<Token>(response.Value.ToString());
        return token;
    }

    [HttpPost(template: "{order_id}/track", Name = "addtracking")]
    public async Task<IActionResult> AddTracking(string order_id, Tracking track)
    {
        var token = getAccessToken();
        string body = requestBody.AddTrackingBody(track);
        Console.WriteLine(body);
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("v2/checkout/orders/" + order_id + "/track", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
}
