using System;
using Newtonsoft.Json;
using RentServiceFront.domain.enums;
using RentServiceFront.domain.model.entity;
using RentServiceFront.domain.model.request.Address;

namespace RentServiceFront.domain.model.request.passport;

public class AddPassportRequest
{
    
    [JsonProperty("username")]
    public string Username { get; set; }
    
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    
    [JsonProperty("surname")]
    public string Surname { get; set; }
    
    [JsonProperty("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    
    [JsonProperty("dateOfIssue")]
    public DateTime DateOfIssue { get; set; }
    
    [JsonProperty("migrationServiceId")]
    public long MigrationServiceId { get; set; }
    
    [JsonProperty("number")]
    public string Number { get; set; }
    
    [JsonProperty("series")]
    public string Series { get; set; }
    
    [JsonProperty("placeOfBirth")]
    public CreateAddressRequest PlaceOfBirth { get; set; }
    
    [JsonProperty("gender")]
    public Gender Gender { get; }

    public AddPassportRequest(string username, string firstName, string lastName, string surname, DateTime dateOfBirth,
        DateTime dateOfIssue, long migrationServiceId, string number, string series, CreateAddressRequest placeOfBirth, Gender gender)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        DateOfIssue = dateOfIssue;
        MigrationServiceId = migrationServiceId;
        Number = number;
        Series = series;
        PlaceOfBirth = placeOfBirth;
        Gender = gender;
    }
}