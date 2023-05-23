
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StringGenerator;
public class StringGeneratorService : IStringGeneratorService
{
  //reference
  private readonly string _lowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
  private readonly string _upperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
  private readonly string _numbers = "0123456789";
  private readonly string _specialCharacters = "!\"£$%^&*()_+{}:@~>?|<\\,./;'#[]-=`¬";

  //config
  private readonly bool _includeCharacters;
  private readonly bool _includeNumbers;
  private readonly bool _includeUpperCase;
  private readonly bool _includeSpecialCharacters;

  private readonly string _pool = "";

  public StringGeneratorService(bool includeCharacters, bool includeNumbers, bool includeUpperCase, bool includeSpecialCharacters)
  {
    _includeCharacters = includeCharacters;
    _includeNumbers = includeNumbers;
    _includeUpperCase = includeUpperCase;
    _includeSpecialCharacters = includeSpecialCharacters;

    _pool = BuildPool();
  }

  public string GenerateString(int length)
  {
    var elements = Enumerable.Range(0, _pool.Length)
        .Select(x => _pool[GetNextInt32(_pool.Length -1)])
        .OrderBy(o => GetNextInt32(_pool.Length -1)).ToArray();

    return new string(Enumerable.Range(0, length)
        .Select(x => new string(elements)[GetNextInt32(elements.Count() -1)]).ToArray());          
  }

  private string BuildPool() 
  {
    var builder = new StringBuilder();

    if (_includeCharacters)
    {
        var chars = new StringBuilder(_lowerCaseCharacters);

        if (_includeUpperCase)
            chars.Append(_upperCaseCharacters);

        builder.Append(chars.ToString());
    }

    if (_includeNumbers)
        builder.Append(_numbers);
    
    if (_includeSpecialCharacters)
        builder.Append(_specialCharacters);

    return builder.ToString();
  }

  private int GetNextInt32(int limit)
  {
    var rnd = RandomNumberGenerator.Create();
    byte[] randomInt = new byte[4];
    rnd.GetBytes(randomInt);

    var targetVal = Convert.ToInt32(randomInt[0]);

    while(targetVal > limit)
    {
        targetVal = targetVal / 2;
    }

    return targetVal;
  }
}