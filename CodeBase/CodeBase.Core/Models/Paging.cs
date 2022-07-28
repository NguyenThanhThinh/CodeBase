namespace CodeBase.Core.Models;

public class Paging
{
    #region Properties

    public object Data { get; set; }

    public int TotalRecords { get; set; }

    public int? PageIndex { get; set; }

    public int RecordStart { get; set; }

    public int RecordEnd { get; set; }

    #endregion

    #region Constructor

    public Paging()
    {
    }

    public Paging(object data, int totalRecords, int recordStart, int recordEnd)
    {
        Data = data;
        TotalRecords = totalRecords;
        RecordStart = recordStart;
        RecordEnd = recordEnd;
    }

    #endregion
}