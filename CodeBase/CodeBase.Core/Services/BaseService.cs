using CodeBase.Core.Enums;
using CodeBase.Core.Exceptions;
using CodeBase.Core.Interfaces.Services;
using CodeBase.Core.Repositories.Interfaces;

namespace CodeBase.Core.Services;

public class BaseService<TEntity> : IBaseService<TEntity>
{
    #region Properties

    private readonly IBaseRepo<TEntity> _repo;


    protected List<string> ErrorMessages = new();


    protected CrudMode CrudMode = CrudMode.Add;

    #endregion

    #region Contructor

    public BaseService(IBaseRepo<TEntity> repo)
    {
        _repo = repo;
    }

    #endregion

    #region Methods

    public async Task<int> Insert(TEntity entity)
    {
        CrudMode = CrudMode.Add;

        if (!await Validate(entity)) throw new ValidationException(ErrorMessages);

        return await _repo.Insert(entity);
    }

    public async Task<int> Update(TEntity entity)
    {
        CrudMode = CrudMode.Update;

        if (!await Validate(entity)) throw new ValidationException(ErrorMessages);

        return await _repo.Update(entity);
    }


    protected virtual async Task<bool> Validate(TEntity entity)
    {
        return await Task.FromResult(true);
    }

    #endregion
}