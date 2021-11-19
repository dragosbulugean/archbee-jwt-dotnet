using JWT;
using JWT.Algorithms;
using JWT.Serializers;

var payload = new Dictionary<string, object>
{
    { "name", "John Wick" },
    { "email", "john.wick@matrix.com" }
};
const string secret = "TW9zaGVFcmV6UHJpdmF0ZUtleQ";

IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
IJsonSerializer serializer = new JsonNetSerializer();
IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

var jwtToken = encoder.Encode(payload, secret);
var archbeeLink = $"https://help.title21.com/?jwt={jwtToken}";

Console.WriteLine($"JWT Token: {jwtToken}");
Console.WriteLine($"Archbee Link: {archbeeLink}");
