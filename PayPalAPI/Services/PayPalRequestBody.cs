using Microsoft.OpenApi.Expressions;

public class PayPalRequestBody
{
    public string PayPalBody(Order order)
    {
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

        return body;
    }

    public string ApplePayBody(Order order)
    {
        string body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""payment_source"": {" + "\n" +
@"        ""apple_pay"":{" + "\n" +
@"        }" + "\n" +
@"    }," + "\n" +
@"    ""application_context"": {" + "\n" +
@"        ""return_url"": ""https://example.com""," + "\n" +
@"        ""cancel_url"": ""https://example.com""," + "\n" +
@"        ""shipping_preference"": ""SET_PROVIDED_ADDRESS""" + "\n" +
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
    return body;
    }

    public string GooglePayBody(Order order)
    {
        string  body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""payment_source"": {" + "\n" +
@"        ""google_pay"":{" + "\n" +
@"        }" + "\n" +
@"    }," + "\n" +
@"    ""application_context"": {" + "\n" +
@"        ""return_url"": ""https://example.com""," + "\n" +
@"        ""cancel_url"": ""https://example.com""," + "\n" +
@"        ""shipping_preference"": ""SET_PROVIDED_ADDRESS""" + "\n" +
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
    return body;
    }

    public string CardPayBody(Order order)
    {
        string body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""application_context"": {" + "\n" +
@"        ""return_url"": ""https://example.com""," + "\n" +
@"        ""cancel_url"": ""https://example.com""," + "\n" +
@"        ""shipping_preference"": ""NO_SHIPPING""" + "\n" +
@"    }," + "\n" +
@"    ""payment_source"":{" + "\n" +
@"        ""card"":{" + "\n" +
@"            ""attributes"":{" + "\n" +
@"                ""verification"":{" + "\n" +
$@"                    ""method"": ""{order.threeDSecure}""" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        }" + "\n" +
@"    }," + "\n" +
@"    ""purchase_units"": [" + "\n" +
@"        {" + "\n" +
@"            ""description"": ""Purchase Unit Description""," + "\n" +
@"            ""custom_id"": ""MemberNumber00001""," + "\n" +
@"            ""amount"": {" + "\n" +
$@"                ""currency_code"": ""{order.currency_code}""," + "\n" +
$@"                ""value"": ""{order.amount}""" + "\n" +
@"            }" + "\n" +
@"        }" + "\n" +
@"    ]" + "\n" +
@"}";
    return body;
    }

    public string PayPalVaultBody(Order order)
    {
        var body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""purchase_units"": [{" + "\n" +
@"      ""amount"": {" + "\n" +
$@"        ""currency_code"": ""{order.currency_code}""," + "\n" +
$@"        ""value"": ""{order.amount}""" + "\n" +
@"      }" + "\n" +
@"    }]," + "\n" +
@"    ""payment_source"": {" + "\n" +
@"      ""paypal"": {" + "\n" +
@"        ""attributes"": {" + "\n" +
@"          ""vault"": {" + "\n" +
@"            ""store_in_vault"": ""ON_SUCCESS""," + "\n" +
@"            ""usage_type"": ""MERCHANT""," + "\n" +
@"            ""customer_type"": ""CONSUMER""" + "\n" +
@"          }" + "\n" +
@"        }," + "\n" +
@"        ""experience_context"": {" + "\n" +
@"            ""return_url"": ""http://example.com/return_url""," + "\n" +
@"            ""cancel_url"": ""http://example.com/cancel_url""" + "\n" +
@"        }" + "\n" +
@"      }" + "\n" +
@"    }" + "\n" +
@"  }";
    return body;
    }

    public string PayPalVaultIdBody(Order order)
    {
        var body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""purchase_units"": [{" + "\n" +
@"      ""amount"": {" + "\n" +
@"        ""currency_code"": ""USD""," + "\n" +
@"        ""value"": ""100.00""" + "\n" +
@"      }" + "\n" +
@"    }]," + "\n" +
@"    ""payment_source"": {" + "\n" +
@"      ""paypal"": {" + "\n" +
$@"            ""vault_id"": ""{order.vault_id}""" + "\n" +
@"        }," + "\n" +
@"        ""experience_context"": {" + "\n" +
@"            ""return_url"": ""http://example.com/return_url""," + "\n" +
@"            ""cancel_url"": ""http://example.com/cancel_url""" + "\n" +
@"        }" + "\n" +
@"      }" + "\n" +
@"    }" + "\n" +
@"  }";
    return body;
    }

     public string CardVaultIdBody(Order order)
     {
        var body = @"{" + "\n" +
@"    ""intent"": ""CAPTURE""," + "\n" +
@"    ""purchase_units"": [{" + "\n" +
@"      ""amount"": {" + "\n" +
@"        ""currency_code"": ""USD""," + "\n" +
@"        ""value"": ""100.00""" + "\n" +
@"      }" + "\n" +
@"    }]," + "\n" +
@"    ""payment_source"": {" + "\n" +
@"      ""card"": {" + "\n" +
$@"            ""vault_id"": ""{order.vault_id}""" + "\n" +
@"        }," + "\n" +
@"        ""experience_context"": {" + "\n" +
@"            ""return_url"": ""http://example.com/return_url""," + "\n" +
@"            ""cancel_url"": ""http://example.com/cancel_url""" + "\n" +
@"        }" + "\n" +
@"      }" + "\n" +
@"    }" + "\n" +
@"  }";
    return body;
     }

    public string AddTrackingBody(Tracking track)
    {
        var body = @"{" + "\n" +
                        $@"  ""capture_id"": ""{track.capture_id}""," + "\n" +
                        $@"  ""tracking_number"": ""{track.tracking_number}""," + "\n" +
                        $@"  ""carrier"": ""{track.carrier}""," + "\n" +
                        $@"  ""notify_payer"": {track.notify_payer.ToString().ToLower()}" + "\n" +
                    @"}";
        return body;
    }
}