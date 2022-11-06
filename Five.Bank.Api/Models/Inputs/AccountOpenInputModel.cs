namespace Five.Bank.Api.Models.Inputs;
public class AccountOpenInputModel {
    public AccountOpenInputModel(Guid customerId) {
        CustomerId = customerId;
    }

    public Guid CustomerId { get; }
}

