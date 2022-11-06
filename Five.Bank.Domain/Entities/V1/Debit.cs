namespace Five.Bank.Domain.Entities.V1;
public sealed class Debit : Transaction {
    public Debit(decimal amount, string? description)
        : base(amount, DateTime.Now, description) {
    }

    public Debit(Guid id, decimal amount, DateTime createdAt, string? description)
        : base(id, amount, createdAt, description) {
    }
}

