using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.Enums;
using ScheduleService.Domain.Core.ValueObjects;

namespace ScheduleService.Domain.Core.Entities;

public class Customer : ActivableEntityBase
{
    public Customer()
    {
        ServiceOrders = new List<ServiceOrder>();
    }

    public Customer(
        string name,
        CpfValueObject cpf,
        Guid cityId,
        PhoneNumberValueObject telephone1, PhoneNumberValueObject telephone2,
        PhoneNumberValueObject cellphone1, PhoneNumberValueObject cellphone2,
        AddressValueObject address) : this()
    {
        Name = name;
        Cpf = cpf;
        CityId = cityId;
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
        Guid cityId,
        PhoneNumberValueObject telephone1, PhoneNumberValueObject telephone2,
        PhoneNumberValueObject cellphone1, PhoneNumberValueObject cellphone2,
        AddressValueObject address) : this()
    {
        Name = name;
        Cnpj = cnpj;
        CityId = cityId;
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

    public PhoneNumberValueObject Telephone1 { get; private set; }
    public PhoneNumberValueObject Telephone2 { get; private set; }
    public PhoneNumberValueObject Cellphone1 { get; private set; }
    public PhoneNumberValueObject Cellphone2 { get; private set; }
    public AddressValueObject Address { get; private set; }

    public ECustomerType CustomerType { get; private set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; }
}
