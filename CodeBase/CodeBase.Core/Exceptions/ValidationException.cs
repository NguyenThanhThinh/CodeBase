using System.Collections;

namespace CodeBase.Core.Exceptions;

public class ValidationException : Exception
{
    #region Properties

    public string? ErrorMessage { get; set; }

    public IDictionary Errors { get; set; }

    #endregion

    #region Constructor

    public ValidationException(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public ValidationException(List<string> errors)
    {
        Errors = new Dictionary<string, object>();
        Errors.Add(Resources.Common.ErrorFieldName, errors);
    }

    #endregion

    #region Methods

    public override IDictionary Data => Errors;

    public override string Message => ErrorMessage;

    #endregion
}