using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;

namespace PayPalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
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

    [HttpGet(template: "orders/{orderId}", Name = "orders")]
    public async Task<IActionResult> ShowOrderDetails(string orderId)
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/checkout/orders/"+orderId+"", Method.Get);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    //Create Order
    //fundingsource - paypal, card, google_pay, apple_pay, token
    //currencyCode - string
    //amount - decimal
    //vault? - boolean
    //vaultid? - paypal-request-id
    [HttpPost(template: "orders", Name = "createorder")]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        string body = "";
        if (order.payment_source == "card")
        {
            paypalRequestBody.CardPayBody(order);
        }

        if (order.payment_source == "google_pay")
        {
            body = paypalRequestBody.GooglePayBody(order);
        }

        if (order.payment_source == "apple_pay")
        {
            body = paypalRequestBody.ApplePayBody(order);
        }
        if (order.payment_source == "paypal" || order.payment_source == null)
        {
            body = paypalRequestBody.PayPalBody(order);
        }

        if (order.vault == true && order.payment_source == "paypal")
        {
            body = paypalRequestBody.PayPalVaultBody(order);
        }

        if (order.vault == true && order.payment_source == "card")
        {
            body = paypalRequestBody.CardVaultIdBody(order);
        }
        if (order.vault_id != null)
        {
            body = paypalRequestBody.PayPalVaultBody(order);
        }
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/checkout/orders", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");

        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    //Capture Order
    [HttpPost(template: "capture", Name = "captureorder")]
    public async Task<IActionResult> CaptureOrder(Capture capture)
    {
        Console.WriteLine(capture.orderId);
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/checkout/orders/" + capture.orderId + "/capture", Method.Post);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }
}
