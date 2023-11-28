using System;
using Newtonsoft.Json;
using RentServiceFront.domain.enums;

namespace RentServiceFront.domain.model.entity;

public class Passport
{
    public Passport(string firstName, string lastName, string surname, DateTime dateOfBirth, DateTime dateOfIssue,
        MigrationService migrationService, string number, string series, Gender gender, string placeOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        DateOfIssue = dateOfIssue;
        MigrationService = migrationService;
        Number = number;
        Series = series;
        Gender = gender;
        PlaceOfBirth = placeOfBirth;
    }
    
    [JsonProperty("fistName")] public string FirstName { get; set; }

    [JsonProperty("lastName")] public string LastName { get; set; }

    [JsonProperty("surname")] public string Surname { get; set; }

    [JsonProperty("dateOfBirth")] public DateTime DateOfBirth { get; set; }

    [JsonProperty("dateOfIssue")] public DateTime DateOfIssue { get; set; }

    [JsonProperty("issuedBy")] public MigrationService MigrationService { get; set; }

    [JsonProperty("number")] public string Number { get; set; }

    [JsonProperty("series")] public string Series { get; set; }

    [JsonProperty("gender")] public Gender Gender { get; }

    [JsonProperty("placeOfBirth")] public string PlaceOfBirth { get; set; }
}