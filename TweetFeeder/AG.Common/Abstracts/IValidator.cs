using AG.Common.Globals;

namespace AG.Common.Abstracts
{
  public interface IValidator
  {
    /// <summary>
    /// Tris to validate the given text data.
    /// </summary>
    /// <param name="data">Input data text data to be validated.</param>
    /// <param name="option">Input validate optiont to be use when validating the data.</param>
    /// <returns>True if the data is validated, otherwise False.</returns>
    bool TryValidate(string data, ValidateOptions option);
  }
}
