using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentTokenController : ControllerBase
{
    private readonly string sandboxEndpoint = "https://api.sandbox.paypal.com";
    private AuthenticationController authController = new AuthenticationController();
    private Token getAccessToken()
    {
        var response = authController.GetAccessTokenAsync().Result as JsonResult;
        var token = JsonConvert.DeserializeObject<Token>(response.Value.ToString());
        return token;
    }
    //api/paymenttoken/setup-tokens for paypal
    [HttpPost(template: "setup-tokens", Name = "setuptoken")]
    public async Task<IActionResult> SetupToken()
    {
        var body = @"{" + "\n" +
@"            ""payment_source"": {" + "\n" +
@"                ""paypal"": {" + "\n" +
@"                  ""usage_type"": ""MERCHANT""," + "\n" +
@"                  ""experience_context"": {" + "\n" +
@"                    ""return_url"": ""https://example.com/returnUrl""," + "\n" +
@"                    ""cancel_url"": ""https://example.com/cancelUrl""" + "\n" +
@"                  }" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        }";
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("v3/vault/setup-tokens", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("PayPal-Request-Id",Guid.NewGuid().ToString());
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    [HttpPost(template: "setup-tokens-card", Name = "setuptokencard")]
    public async Task<IActionResult> CardSetupToken()
    {
        var body = @"{" + "\n" +
@"                  ""payment_source"": {" + "\n" +
@"                      ""card"": {" + "\n" +
@"                      }," + "\n" +
@"                  ""verification_method"": ""SCA_WHEN_REQUIRED""" + "\n" +
@"                  }" + "\n" +
@"               }";
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("v3/vault/setup-tokens", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("PayPal-Request-Id",Guid.NewGuid().ToString());
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    //api/paymenttoken/setup-tokens
    [HttpPost(template: "create/{order_id}", Name = "paymenttokencreate")]
    public async Task<IActionResult> PaymentTokenCreate(string order_id)
    {
        var body = @"{" + "\n" +
@"            ""payment_source"": {" + "\n" +
@"                ""token"": {" + "\n" +
$@"                  ""id"": ""{order_id}""," + "\n" +
@"                  ""type"": ""SETUP_TOKEN""" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        }";
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("v3/vault/payment-tokens", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("PayPal-Request-Id",Guid.NewGuid().ToString());
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
    
}
