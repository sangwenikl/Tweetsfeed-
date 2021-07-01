using AG.Common.Abstracts;
using AG.Common.Globals;
using System;
using System.Text;

namespace AG.Common.Concretes
{
  public class EncodingValidator : IValidator
  {
    private Encoding encoder;
    private ILogger logger;

    public EncodingValidator()
    {
      encoder = Encoding.GetEncoding(GlobalVar.US_ASCII, new EncoderExceptionFallback(), new DecoderExceptionFallback());
      logger = new ConsoleLogger();
    }

    public EncodingValidator(Encoding encoder, ILogger logger)
    {
      this.encoder = encoder;
      this.logger = logger;
    }

    public EncodingValidator(Encoding encoder)
    {
      this.encoder = encoder;
    }
    /// <summary>
    /// Tries to valiidate text data using encoding.
    /// </summary>
    /// <param name="data">The text input data to be validated</param>
    /// <param name="option">The validate encoding to be use on the text input data.</param>
    /// <returns>True if the text input data is validated against the encoding provide, otherwise False.</returns>
    public bool TryValidate(string data, ValidateOptions option)
    {
      bool isValid = false;
      
      switch(option)
      {
        case ValidateOptions.UsASCII:
          {
            try
            {
              byte[] bytes = encoder.GetBytes(data);
              isValid = true;
            }
            catch (EncoderFallbackException e)
            {
              isValid = false;
              logger.TryLog(string.Format("Unable to encode {0} at index {1}",
                                e.IsUnknownSurrogate() ? string.Format("U+{0:X4} U+{1:X4}", Convert.ToUInt16(e.CharUnknownHigh), Convert.ToUInt16(e.CharUnknownLow)) :
                                   string.Format("U+{0:X4}", Convert.ToUInt16(e.CharUnknown)), e.Index));
            }
          }
          break;
        default:
            isValid = false;
          break;  
      }

      return isValid;
    }
  }
}
