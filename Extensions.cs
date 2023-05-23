using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StringGenerator;

public static class Extensions
{
  public static IServiceCollection AddStringGenerator(this IServiceCollection services, IConfiguration configuration)
  {
    bool includeCharacters = bool.Parse(configuration.GetSection("StringGenerator:IncludeCharacters").Value);
    bool includeNumbers = bool.Parse(configuration.GetSection("StringGenerator:IncludeNumbers").Value);
    bool includeUpperCase = bool.Parse(configuration.GetSection("StringGenerator:IncludeUpperCase").Value);
    bool includeSpecialCharacters = bool.Parse(configuration.GetSection("StringGenerator:IncludeSpecialCharacters").Value);

    services.AddTransient<IStringGeneratorService>(o => {
      return new StringGeneratorService(includeCharacters, includeNumbers, includeUpperCase, includeSpecialCharacters);
    });

    return services;
  }
}