using System;

namespace RentServiceFront.domain.model.request.passport;

public class AddPassportRequest
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfIssue { get; set; }
    public long MigrationServiceId { get; set; }
    public string Number { get; set; }
    public string Series { get; set; }
    public string PlaceOfBirth { get; set; }

    public AddPassportRequest(string username, string firstName, string lastName, string surname, DateTime dateOfBirth,
        DateTime dateOfIssue, long migrationServiceId, string number, string series, string placeOfBirth)
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
    }
}