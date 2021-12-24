using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.ValueObjects;

namespace ScheduleService.Domain.Core.Entities;

public class User : ActivableEntityBase
{
    public User()
    { }

    public User(
        string firstName,
        string lastName,
        string userName,
        string password,
        string email,
        CpfValueObject cpf,
        Guid? cityId,
        PhoneNumberValueObject telephone1,
        PhoneNumberValueObject telephone2,
        PhoneNumberValueObject cellphone1,
        PhoneNumberValueObject cellphone2,
        AddressValueObject address)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Password = password;
        Email = email;
        Cpf = cpf;
        CityId = cityId;
        Telephone1 = telephone1;
        Telephone2 = telephone2;
        Cellphone1 = cellphone1;
        Cellphone2 = cellphone2;
        Address = address;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public string UserName { get; private set; }
    public string Password { get; private set; }

    public string Email { get; private set; }

    public CpfValueObject Cpf { get; private set; }

    public Guid? CityId { get; private set; }
    public virtual City? City { get; }

    public PhoneNumberValueObject Telephone1 { get; private set; }
    public PhoneNumberValueObject Telephone2 { get; private set; }
    public PhoneNumberValueObject Cellphone1 { get; private set; }
    public PhoneNumberValueObject Cellphone2 { get; private set; }
    public AddressValueObject Address { get; private set; }

    public string FullName { get => $"{FirstName.Trim()} {LastName.Trim()}"; }
}
