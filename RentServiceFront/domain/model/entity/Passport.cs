using System;

namespace RentServiceFront.domain.model.entity;

public class Passport
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfIssue { get; set; }
    public MigrationService MigrationService { get; set; }
    public string Number { get; set; }
    public string Series { get; set; }
    public string PlaceOfBirth { get; set; }
}