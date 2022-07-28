namespace CodeBase.Api.Controllers;

public class DepartmentsController : BaseController
{
    #region Properties

    private readonly CodeBase.Core.Interfaces.Services.IDepartmentService _departmentService;
    private readonly CodeBase.Core.Interfaces.Repositories.IDepartmentRepo _departmentRepo;

    #endregion

    #region Constructor

    public DepartmentsController(CodeBase.Core.Interfaces.Services.IDepartmentService departmentService,
                                 CodeBase.Core.Interfaces.Repositories.IDepartmentRepo departmentRepo)
    {
        _departmentService = departmentService;
        _departmentRepo = departmentRepo;
    }

    #endregion

    #region Methods

    [Microsoft.AspNetCore.Mvc.HttpGetAttribute]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetPaging(int? pageIndex, int? size, string? keyword)
    {
        try
        {
            if (pageIndex == null) pageIndex = 0;
            if (size      == null) size = 10;
            if (keyword   == null) keyword = "";

            var paging = await _departmentRepo.GetPaging((int)pageIndex, (int)size, keyword);
            return Ok(paging);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }


    [Microsoft.AspNetCore.Mvc.HttpGetAttribute("all")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAll()
    {
        try
        {
            var departments = await _departmentRepo.GetAll();
            return Ok(departments);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }


    [Microsoft.AspNetCore.Mvc.HttpGetAttribute("{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> getOne(Guid id)
    {
        try
        {
            var dep = await _departmentRepo.GetById(id);
            return Ok(dep);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }


    [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> CreateOne(CodeBase.Core.Models.Department d)
    {
        try
        {
            var res = await _departmentService.Insert(d);
            return StatusCode(201, res);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }


    [Microsoft.AspNetCore.Mvc.HttpPutAttribute]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Update(CodeBase.Core.Models.Department dep)
    {
        try
        {
            var res = await _departmentService.Update(dep);
            return Ok(res);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }


    [Microsoft.AspNetCore.Mvc.HttpDeleteAttribute("{id}")]
    public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Delete(Guid id)
    {
        try
        {
            var res = await _departmentRepo.Delete(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }

    #endregion
}