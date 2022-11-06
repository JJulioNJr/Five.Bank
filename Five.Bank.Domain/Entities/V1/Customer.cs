using Five.Bank.Domain.Contracts.V1;
using Five.Bank.Domain.Specification.V1;
using Five.Bank.Domain.ValueObjects.V1;

namespace Five.Bank.Domain.Entities.V1;
public sealed class Customer : IEntity {

    public Customer(string name, string document, DateTime birthday, Address? address) :
                    this(Guid.NewGuid(), name, document, birthday, address) {
    }

    public Customer(Guid id, string name, string document, DateTime birthday, Address? address) {
        this.Id = id;
        this.Name = name;
        this.Document = document;
        this.Birthday = birthday;
        this.Address = address;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Document { get; init; }
    public DateTime Birthday { get; init; }
    public Address? Address { get; init; }

    public bool Validate() {
        var documentSpecification = new DocumentAlgorithmSpecification(Document);
        var birthdaySpecification = new CustomerMajoritySpecification(Birthday);
        var nameSpecification = new NameSpecification(Name);
        return
            documentSpecification.IsSatisfied() &&
            birthdaySpecification.IsSatisfied() &&
            nameSpecification.IsSatisfied();
    }
}

