namespace CodeBase.Core.Models;

public class BaseEntity
{
    #region Properties

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    #endregion
}