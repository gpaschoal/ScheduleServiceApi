using Schedule.Service.Domain.Model.Entities.Base;
using Schedule.Service.Domain.Model.ValueObjects;

namespace Schedule.Service.Domain.Model.Entities;

public class User : ActivableEntityBase
{
    public User(
        string firstName, 
        string lastName, 
        CpfValueObject cpf, 
        Guid cityId, 
        Guid stateId, 
        Guid countryId, 
        PhoneNumberValueObject telephone1, 
        PhoneNumberValueObject telephone2, 
        PhoneNumberValueObject cellphone1, 
        PhoneNumberValueObject cellphone2, 
        AddressValueObject address, 
        string userName, 
        string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Cpf = cpf;
        CityId = cityId;
        StateId = stateId;
        CountryId = countryId;
        Telephone1 = telephone1;
        Telephone2 = telephone2;
        Cellphone1 = cellphone1;
        Cellphone2 = cellphone2;
        Address = address;
        UserName = userName;
        Password = password;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public CpfValueObject Cpf { get; private set; }

    public Guid CityId { get; private set; }
    public virtual City City { get; }
    public Guid StateId { get; private set; }
    public virtual State State { get; }
    public Guid CountryId { get; private set; }
    public virtual Country Country { get; }

    public PhoneNumberValueObject Telephone1 { get; private set; }
    public PhoneNumberValueObject Telephone2 { get; private set; }
    public PhoneNumberValueObject Cellphone1 { get; private set; }
    public PhoneNumberValueObject Cellphone2 { get; private set; }
    public AddressValueObject Address { get; private set; }

    public string UserName { get; private set; }
    public string Password { get; private set; }

    public string FullName { get => $"{FirstName} {LastName}";  }
}
