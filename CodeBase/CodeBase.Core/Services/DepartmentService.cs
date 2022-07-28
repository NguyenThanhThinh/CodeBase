namespace CodeBase.Core.Services;

public class DepartmentService : BaseService<CodeBase.Core.Models.Department>,
                                 CodeBase.Core.Interfaces.Services.IDepartmentService
{
    #region Properties

    private CodeBase.Core.Interfaces.Repositories.IDepartmentRepo _repo;

    #endregion

    #region Constructor

    public DepartmentService(CodeBase.Core.Interfaces.Repositories.IDepartmentRepo repo) : base(repo)
    {
        _repo = repo;
    }

    #endregion

    #region Methods

    protected override async Task<bool> Validate(CodeBase.Core.Models.Department dep)
    {
        var valid = true;

        if (string.IsNullOrEmpty(dep.Id.ToString()))
        {
            valid = false;
            ErrorMessages.Add(Resources.ExceptionErrorMessage.DepartmentIdNull);
        }

        if (await _repo.CheckExist(dep.Id))
        {
            valid = false;
            ErrorMessages.Add(Resources.ExceptionErrorMessage.DepartmentIdExists);
        }

        if (string.IsNullOrEmpty(dep.Name))
        {
            valid = false;
            ErrorMessages.Add(Resources.ExceptionErrorMessage.DepartmentNameNull);
        }

        return valid;
    }

    #endregion
}