using Schedule.Service.Domain.Model.Entities;

namespace Schedule.Service.Domain.Model.ValueObject;

public record AddressValueObject(string Street, string Neighborhood, string LocalReference, string ZipCode, string Number, City City);
