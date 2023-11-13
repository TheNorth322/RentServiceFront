using Refit;

namespace RentServiceFront.domain.model.request;

public class RegisterEntityRequest
{
    public RegisterRequest RegisterRequest { get; set; }
    public string Name { get; set; }
    public string SupervisorFirstName { get; set; }
    public string SupervisorLastName { get; set; }
    public string SupervisorSurname { get; set; }
    public string Address { get; set; }
    public long BankId { get; set; }
    public string CheckingAccount { get; set; }
    public string ItnNumber { get; set; }

    public RegisterEntityRequest(RegisterRequest registerRequest, string name, string supervisorFirstName, 
        string supervisorLastName, string supervisorSurname, string address, long bankId, string checkingAccount, string itnNumber)
    {
        RegisterRequest = registerRequest;
        Name = name;
        SupervisorFirstName = supervisorFirstName;
        SupervisorLastName = supervisorLastName;
        SupervisorSurname = supervisorSurname;
        Address = address;
        BankId = bankId;
        CheckingAccount = checkingAccount;
        ItnNumber = itnNumber;
    }
}