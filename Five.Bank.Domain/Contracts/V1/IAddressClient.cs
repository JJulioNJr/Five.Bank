using Five.Bank.Domain.ValueObjects.V1;

namespace Five.Bank.Domain.Contracts.V1;
public interface IAddressClient {

    Task<Address?> GetByZipCode(string? zipCode);
}

