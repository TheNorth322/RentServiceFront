using System;
using Newtonsoft.Json;

namespace RentServiceFront.domain.model.request;

public class AuthenticationRequest
{
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("password")]
    public string Password { get; set; }

    public AuthenticationRequest(string _username, string _password)
    {
        if (String.IsNullOrEmpty(_username))
            throw new ArgumentException("Username can't be null or empty");
        if (String.IsNullOrEmpty(_password))
                    throw new ArgumentException("Username can't be null or empty");
        Username = _username;
        Password = _password;
    }
}