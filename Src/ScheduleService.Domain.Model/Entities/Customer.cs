using ScheduleService.Domain.Model.Entities.Base;
using ScheduleService.Domain.Model.Enums;
using ScheduleService.Domain.Model.ValueObjects;

namespace ScheduleService.Domain.Model.Entities;

public class Customer : ActivableEntityBase
{
    public Customer()
    {
        ServiceOrders = new List<ServiceOrder>();
    }

    public Customer(
        string name,
        CpfValueObject cpf,
        Guid cityId, Guid stateId, Guid countryId,
        PhoneNumberValueObject telephone1, PhoneNumberValueObject telephone2,
        PhoneNumberValueObject cellphone1, PhoneNumberValueObject cellphone2,
        AddressValueObject address) : this()
    {
        Name = name;
        Cpf = cpf;
        CityId = cityId;
        StateId = stateId;
        CountryId = countryId;
        Telephone1 = telephone1;
        Telephone2 = telephone2;
        Cellphone1 = cellphone1;
        Cellphone2 = cellphone2;
        Address = address;
        CustomerType = ECustomerType.Person;
    }

    public Customer(
        string name,
        CnpjValueObject cnpj,
        Guid cityId, Guid stateId, Guid countryId,
        PhoneNumberValueObject telephone1, PhoneNumberValueObject telephone2,
        PhoneNumberValueObject cellphone1, PhoneNumberValueObject cellphone2,
        AddressValueObject address) : this()
    {
        Name = name;
        Cnpj = cnpj;
        CityId = cityId;
        StateId = stateId;
        CountryId = countryId;
        Telephone1 = telephone1;
        Telephone2 = telephone2;
        Cellphone1 = cellphone1;
        Cellphone2 = cellphone2;
        Address = address;
        CustomerType = ECustomerType.Company;
    }

    public string Name { get; private set; }

    public CpfValueObject Cpf { get; private set; }
    public CnpjValueObject Cnpj { get; private set; }

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

    public ECustomerType CustomerType { get; private set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; }
}
