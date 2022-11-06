namespace Five.Bank.Api.Models.Inputs;
public class AccountDepositInputModel {
    public AccountDepositInputModel(decimal amount) {
        Amount = amount;
    }

    public decimal Amount { get; }
}

