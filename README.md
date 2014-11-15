SampleDataGenerator
=============================

[![Build status](https://ci.appveyor.com/api/projects/status/6pr6gdy8osxpxbti?svg=true)](https://ci.appveyor.com/project/Mathieu/sampledatagenerator)

Sample data generator simplifies the process of creating random data for demo purposes.

Installation
============

```
PM> Install-Package SampleDataGenerator
```

Usage
=====

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
        .ChooseFrom(StaticData.LastNames)
    .For(x => x.Id)
        .CreateUsing(() => Guid.NewGuid());

var clients = clientGenerator.Generate(50).ToList();
```

Static data available
=====================

- First names
- Last names
- Fictional company names
- Countries