SampleDataGenerator
===================

Sample data generator simplifies the process of creating random data for demo purposes.

Build status
------------

[![Build status](https://img.shields.io/appveyor/ci/Mathieu/SampleDataGenerator.svg)](https://ci.appveyor.com/project/Mathieu/sampledatagenerator)
[![Coverity status](https://img.shields.io/coverity/scan/6554.svg)](https://scan.coverity.com/projects/mathieubrun-sampledatagenerator)

Installation
------------

[![Nuget count](http://img.shields.io/nuget/v/SampleDataGenerator.svg)](https://www.nuget.org/packages/SampleDataGenerator/) [![Nuget downloads](http://img.shields.io/nuget/dt/SampleDataGenerator.svg)](https://www.nuget.org/packages/SampleDataGenerator/)

```
PM> Install-Package SampleDataGenerator
```

Usage
-----

Given the following class :

```csharp
public class Client
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

You can generate an array of 50 Client instances with :

```csharp
var clientGenerator = Generator
    .For<Client>()
    .For(x => x.FirstName)
        .ChooseFrom(StaticData.FirstNames)
    .For(x => x.LastName)
        .ChooseRandomlyFrom(StaticData.LastNames)
    .For(x => x.Id)
        .CreateUsing(() => Guid.NewGuid());

var clients = clientGenerator.Generate(50).ToList();
```

Static data available
---------------------

- First names
- Last names
- Fictional company names
- Countries
