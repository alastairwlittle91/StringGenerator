# String Generator

Basic service to allow configurable generation of randomly composed strings.

## Installation

There are required settings that must be made available through app settings. Those settings are as follows:

```json

{
  "StringGenerator": {
    "IncludeCharacters": true | false, //Should characters be included in the generated strings
    "IncludeNumbers": true | false, //Should numbers be included in the generated strings
    "IncludeUpperCase": true | false, //Should upper case characters be included in the generated strings
    "IncludeSpecialCharacters": true | false, //Should special characters be included in the generated strings
  }
}

```

## Usage

To initialise the connection to the database, the method `AddStringGenerator` should be called passing in an `IConfiguration` instance that contains the above configuration settings.

I.e. `.AddStringGenerator(_configuration);`

To then utilise the string generator service, ensure the interface `IStringGeneratorService` is injected wherever it needs to be utilised.

I.e. 
```c#
  private readonly IStringGeneratorService _stringGeneratorService;
  private readonly int _length = 10;

  public MyRepository (IStringGeneratorService stringGeneratorService) {
    _stringGeneratorService = stringGeneratorService;
  }

  public Task<List<Entity>> GetString =>
    _stringGeneratorService.GenerateString(_length);
  
```
