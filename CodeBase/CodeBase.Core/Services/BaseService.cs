using CodeBase.Core.Enums;
using CodeBase.Core.Exceptions;
using CodeBase.Core.Interfaces.Services;
using CodeBase.Core.Repositories.Interfaces;

namespace CodeBase.Core.Services;

public class BaseService<TEntity> : IBaseService<TEntity>
{
    #region Properties

    private IBaseRepository<TEntity> _repo;


    protected List<string> ErrorMessages = new();


    protected CrudMode CrudMode = CrudMode.Add;

    #endregion

    #region Contructor

    public BaseService(IBaseRepository<TEntity> repo)
    {
        _repo = repo;
    }

    #endregion

    #region Methods

    public Task<int> Insert(TEntity entity)
    {
        CrudMode = CrudMode.Add;

        if (!Validate(entity)) throw new ValidationException(ErrorMessages);

        return _repo.Insert(entity);
    }

    public Task<int> Update(TEntity entity)
    {
        CrudMode = CrudMode.Update;

        if (!Validate(entity)) throw new ValidationException(ErrorMessages);

        return _repo.Update(entity);
    }


    protected virtual bool Validate(TEntity entity)
    {
        return true;
    }

    #endregion
}