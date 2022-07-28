namespace CodeBase.Core.Interfaces.Services;

public interface IBaseService<TEntity>
{
    #region Methods

    Task<int> Insert(TEntity entity);

    Task<int> Update(TEntity entity);

    #endregion
}