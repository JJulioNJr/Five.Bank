using Five.Bank.Domain.Contracts.V1;

namespace Five.Bank.Domain.Entities.V1;

public sealed class Account:IEntity {

    public Account(Guid customerId)
                 : this(Guid.NewGuid(), new(), customerId, false) {
    }
    public Account(Guid id, List<Transaction> transactions, Guid customerId, bool isClosed) {
        Id = id;
        Transactions = transactions;
        CustomerId = customerId;
        IsClosed = isClosed;
    }
  
    public Guid Id { get; init; }
    public List<Transaction> Transactions { get; init; }
    public Guid CustomerId { get; }
    public bool IsClosed { get; private set; }

    public void Deposit(Credit credit) => Transactions.Add(credit);
    public void Withdraw(Debit debit)  {

        #region Metodos Exemplos
        //var balance = Transactions.Sum(transaction => {
        //    if (transaction is Debit) return transaction.Amount * -1;
        //    return transaction.Amount;
        //});

        //  var allCredits = Transactions.Where(transaction => transaction is Credit);
        //var balance1 = 0M;
        //foreach (var transaction in Transactions) {
        //    if(transaction is Debit) {
        //        balance1 -= transaction.Amount;
        //    } else {
        //        balance1+=transaction.Amount;
        //    }
        //}
        #endregion

        if (GetCurrentBalance() < debit.Amount) {
        
            throw new Exception("A Conta não possui saldo para saque");
        }
        Transactions.Add(debit);
    }

    public void Open(Credit credit) {
       
        IsClosed=false;
        Deposit(credit);
    }

    public void Close() {
      
        if (GetCurrentBalance() != 0) {
            throw new Exception("A Conta Não pode Ser Fechada, porque ainda Existe Saldo... ");
        }
        IsClosed = true;
    }

    public decimal GetCurrentBalance() {
        var balance = 0M;
        foreach (var transaction in Transactions) {
            if (transaction is Debit) {
                balance -= transaction.Amount;
            } else {
                balance += transaction.Amount;
            }
        }
        return balance;    
    }
}































