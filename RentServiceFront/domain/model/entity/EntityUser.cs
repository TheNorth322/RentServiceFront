namespace RentServiceFront.domain.model.entity;

public class EntityUser
{
    public string Name { get; set; }
    public string SupervisorFirstName { get; set; }
    public string SupervisorLastName { get; set; }
    public string SupervisorSurname { get; set; }
    public Address Address { get; set; }
    public Bank Bank { get; set; }
    public string CheckingAccount { get; set; }
    public string ItnNumber { get; set; }
}