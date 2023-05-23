using System.Threading.Tasks;

namespace StringGenerator;
public interface IStringGeneratorService
{
  ///<summary>
  /// This method generates a string using the provided configuration
  ///<summary>
  string GenerateString(int length);
}