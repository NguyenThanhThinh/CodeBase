using System.Text.Json.Serialization;

namespace CodeBase.Core.Exceptions;

public class ErrorMessage
{
    #region Properties

    /// <summary>
    /// message for user
    /// </summary>
    [JsonPropertyName("userMsg")]
    public string UserMsg { get; set; }

    /// <summary>
    /// message for developer
    /// </summary>
    [JsonPropertyName("devMsg")]
    public string DevMsg { get; set; }

    /// <summary>
    /// internal error code
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// id of error in the log file
    /// </summary>
    [JsonPropertyName("traceId")]
    public int TraceId { get; set; }

    /// <summary>
    /// contains details of errors
    /// </summary>
    [JsonPropertyName("data")]
    public object Data { get; set; }

    #endregion

    #region Contructor

    public ErrorMessage(string userMsg, string devMsg) : this()
    {
        UserMsg = userMsg;
        DevMsg = devMsg;
    }

    public ErrorMessage()
    {
    }

    public ErrorMessage(string userMsg, string devMsg, string errorCode, int traceId)
    {
        UserMsg = userMsg;
        DevMsg = devMsg;
        ErrorCode = errorCode;
        TraceId = traceId;
    }

    #endregion
}