namespace Schedule.Service.Domain.Model.ValueObjects;

public record AddressValueObject(string Street, string Neighborhood, string LocalReference, string ZipCode, string Number);
