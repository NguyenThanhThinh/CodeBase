namespace CodeBase.Core.Models;

public class Department : BaseEntity
{
    #region Properties

    public Guid Id { get; set; }

    public string? Name { get; set; }

    #endregion

    #region Constructor

    public Department()
    {
        Id = Guid.NewGuid();
    }

    #endregion
}