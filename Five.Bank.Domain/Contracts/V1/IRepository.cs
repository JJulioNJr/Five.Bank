namespace Five.Bank.Domain.Contracts.V1;
public interface IRepository <TEntity> where TEntity : IEntity{

    Task AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
}

