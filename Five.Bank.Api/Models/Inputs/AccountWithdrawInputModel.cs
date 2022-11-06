namespace Five.Bank.Api.Models.Inputs;
public class AccountWithdrawInputModel {
    public AccountWithdrawInputModel(decimal amount) {
        Amount = amount;
    }

    public decimal Amount { get; }
}

