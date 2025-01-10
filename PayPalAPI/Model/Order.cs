public class Order
{
    public string currency_code {get;set;}
    public decimal amount {get;set;} 
    public string? payment_source {get;set;}
    public bool? vault {get;set;}
    public string? vault_id{get;set;}
    public string? threeDSecure{get;set;}

}