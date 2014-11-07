SampleDataGenerator
=============================

Sample data generator simplifies the process of creating random data for demo purposes.

Installation
============

Using nuget package manager :

Install-Package SampleDataGenerator

Usage
=====

Given the following class :

    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

You can generate an array of Clients with :

    Generator
        .For<Client>()
        .For(x => x.FirstName)
            .ChooseFrom(StaticData.FirstNames)
        .For(x => x.LastName)
            .ChooseFrom(StaticData.LastNames)
        .For(x => x.Id)
            .CreateUsing(() => Guid.NewGuid());

At the moment, 3 sets of data are providen :
- StaticData.FirstNames
- StaticData.LastNames
- StaticData.Companies

History
=======

Originally present in the code of https://github.com/mathieubrun/Samples.AngularBootstrapWebApi, I chose to make it a library of its own, mainly for learning fluent API design.

[![Build status](https://ci.appveyor.com/api/projects/status/6pr6gdy8osxpxbti?svg=true)](https://ci.appveyor.com/project/Mathieu/sampledatagenerator)

