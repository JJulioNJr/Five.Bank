using Five.Bank.Domain.Contracts.V1;

namespace Five.Bank.Domain.Entities.V1;
public abstract class Transaction:IEntity {

    protected Transaction(decimal amount, DateTime createdAt, string? description) :
                      this(Guid.NewGuid(), amount, createdAt, description) {
    }

    protected Transaction(Guid id, decimal amount, DateTime createdAt, string? description) {
        Id = id;
        Amount = amount;
        CreatedAt = createdAt;
        Description = description;
    }
   
    public Guid Id { get; init; }
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; init; }
    public string? Description { get; init; }

}

