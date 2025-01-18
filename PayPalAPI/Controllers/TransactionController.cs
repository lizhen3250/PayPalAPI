using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private AuthenticationController authController = new AuthenticationController();
    private readonly string sandboxEndpoint = "https://api.sandbox.paypal.com";
    private PayPalRequestBody paypalRequestBody = new PayPalRequestBody();

    private Token getAccessToken()
    {
        var response = authController.GetAccessTokenAsync().Result as JsonResult;
        var token = JsonConvert.DeserializeObject<Token>(response.Value.ToString());
        return token;
    }

    [HttpGet(template: "reporting", Name = "listtransctions")]
    public async Task<IActionResult> ListTransactions()
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/reporting/transactions?end_date=2025-01-30T23:59:59-0700&start_date=2025-01-01T00:00:00-0700", Method.Get);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    [HttpGet(template: "reporting/transactions", Name = "getaweektransctions")]
    public async Task<IActionResult> ListTransactions(string start, string end)
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v1/reporting/transactions?end_date="+end+"&start_date="+start, Method.Get);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    [HttpGet(template: "payments/{capture_id}", Name = "getpaymentdetails")]
    public async Task<IActionResult> GetPaymentDetails(string capture_id)
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/payments/captures/"+capture_id, Method.Get);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    [HttpPost(template: "payments/{capture_id}/refund", Name = "refund")]
    public async Task<IActionResult> RefundPayment(string capture_id)
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/payments/captures/"+capture_id+"/refund", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
    
}
