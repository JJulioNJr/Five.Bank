using Five.Bank.Domain.Entities.V1;

namespace Five.Bank.Domain.Contracts.V1;
public interface IAccountRepository : IRepository<Account> {


    Task UpdateAsync(Account account);
}

