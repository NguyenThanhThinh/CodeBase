using CodeBase.Core.Models;

namespace CodeBase.Core.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
{
    #region Methods

    Task<Paging> GetPaging(int pageIndex, int size, string keyword);

    Task<IEnumerable<TEntity>> GetAll();

    Task<TEntity> GetById(Guid id);

    Task<bool> CheckExist(Guid id);

    Task<int> Insert(TEntity entity);

    Task<int> Update(TEntity entity);

    Task<int> Delete(Guid id);

    #endregion
}