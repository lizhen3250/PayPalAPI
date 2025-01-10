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

    private Token getAccessToken()
    {
        var response = authController.GetAccessTokenAsync().Result as JsonResult;
        var token = JsonConvert.DeserializeObject<Token>(response.Value.ToString());
        Console.Write(token.Access_token);
        return token;
    }

    [HttpGet(template: "orders/{orderId}", Name = "orders")]
    public IEnumerable<string> ShowOrderDetails(string orderId)
    {
        getAccessToken();
        return new string[] { "vaule 1", "vaule 1", orderId };
    }

    //Create Order
    //fundingsource - paypal, card, google_pay, apple_pay, token
    //currencyCode - string
    //amount - decimal
    //vault? - boolean
    //vaultid? - paypal-request-id
    [HttpPost(template: "orders", Name = "createorder")]
    public async Task<IActionResult> CreateOrder([FromBody]Order order)
    {
        var token = getAccessToken();
        var options = new RestClientOptions(sandboxEndpoint);
        var client = new RestClient(options);
        var request = new RestRequest("/v2/checkout/orders", Method.Post);
        request.AddHeader("Authorization", token.Token_type + " " + token.Access_token);
        request.AddHeader("Content-Type", "application/json");
        var body = @"{" + "\n" +
        @"    ""intent"": ""CAPTURE""," + "\n" +
        @"    ""payment_source"": {" + "\n" +
        @"        ""paypal"":{" + "\n" +
        @"            ""experience_context"": {" + "\n" +
        @"                ""return_url"": ""http://www.example.com/return_url""," + "\n" +
        @"                ""cancel_url"": ""http://www.example.com/cancel_url""," + "\n" +
        @"                ""shipping_preference"": ""SET_PROVIDED_ADDRESS""," + "\n" +
        @"                ""user_action"": ""PAY_NOW""" + "\n" +
        @"            }" + "\n" +
        @"        }" + "\n" +
        @"    }," + "\n" +
        @"    ""payer"": {" + "\n" +
        @"        ""email_address"": ""example0@qq.com""," + "\n" +
        @"        ""name"": {" + "\n" +
        @"            ""given_name"": ""Zhen""," + "\n" +
        @"            ""surname"": ""Li""" + "\n" +
        @"        }," + "\n" +
        @"        ""phone"": {" + "\n" +
        @"            ""phone_number"": {" + "\n" +
        @"                ""national_number"": ""5555555555""" + "\n" +
        @"            }" + "\n" +
        @"        }," + "\n" +
        @"        ""address"": {" + "\n" +
        @"                 ""address_line_1"" :""11 philidelphia ave""," + "\n" +
        @"                ""address_line_2"" : ""123""," + "\n" +
        @"                ""admin_area_1"": ""los angeles""," + "\n" +
        @"                ""admin_area_2"": ""CA""," + "\n" +
        @"                ""postal_code"" : ""900001""," + "\n" +
        @"                ""country_code"": ""US""" + "\n" +
        @"               " + "\n" +
        @"        }" + "\n" +
        @"    }," + "\n" +
        @"    ""purchase_units"": [" + "\n" +
        @"        {" + "\n" +
        @"            ""description"": ""Purchase Unit Description""," + "\n" +
        @"            " + "\n" +
        @"            ""amount"": {" + "\n" +
        $@"                ""currency_code"": ""{order.currency_code}""," + "\n" +
        $@"                ""value"": ""{order.amount}""" + "\n" +
        @"            }," + "\n" +
        @"            ""shipping"": {" + "\n" +
        @"               ""address"": {" + "\n" +
        @"                 ""address_line_1"" :""11 philidelphia ave""," + "\n" +
        @"                ""address_line_2"" : ""123""," + "\n" +
        @"                ""admin_area_1"": ""los angeles""," + "\n" +
        @"                ""admin_area_2"": ""CA""," + "\n" +
        @"                ""postal_code"" : ""900001""," + "\n" +
        @"                ""country_code"": ""US""" + "\n" +
        @"               }" + "\n" +
        @"            }" + "\n" +
        @"        }" + "\n" +
        @"    ]" + "\n" +
        @"}";
        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);
        return Ok(response.Content);
    }

    //Capture Order
}
