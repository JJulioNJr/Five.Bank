namespace Five.Bank.Domain.Entities.V1;

public sealed class Account {


    public Guid Id { get; init; }
    public List<Transaction> Transactions { get; init; }
    public Guid CustomerId { get; init; }
    public bool IsClosed { get; init; }

    public Account(Guid customerId)
                  : this(Guid.NewGuid(), new(), customerId, false) {
    }
    public Account(Guid id, List<Transaction> transactions, Guid customerId, bool isClosed) {
        Id = id;
        Transactions = transactions;
        CustomerId = customerId;
        IsClosed = isClosed;
    }

    public void Deposit(Credit credit) => Transactions.Add(credit);
    public void Withdraw(Debit debit)  {
        var balance = Transactions.Sum(transaction => {
            if (transaction is Debit) return transaction.Amount * -1;
            return transaction.Amount;
        });

        var allCredits = Transactions.Where(transaction => transaction is Credit);
        //var balance1 = 0M;
        //foreach (var transaction in Transactions) {
        //    if(transaction is Debit) {
        //        balance1 -= transaction.Amount;
        //    } else {
        //        balance1+=transaction.Amount;
        //    }
        //}

        if(balance > 0)  Transactions.Remove(debit);
        throw new Exception("A Conta não possui saldo para saque");
    }
}































