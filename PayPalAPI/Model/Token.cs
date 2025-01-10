using System.Text.Json;
using Newtonsoft.Json;

public class Token
{
    [JsonProperty("scope")]
    public string? Scope { get; set; }

    [JsonProperty("access_token")]
    public string? Access_token { get; set; }

    [JsonProperty("token_type")]
    public string? Token_type { get; set; }

    [JsonProperty("expires_in")]
    public int Expires_in { get; set; }

    [JsonProperty("nonce")]
    public string? Nonce { get; set; }

}