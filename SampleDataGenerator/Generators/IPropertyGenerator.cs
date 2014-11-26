namespace SampleDataGenerator.Generators
{
    public interface IPropertyGenerator<TProperty>
    {
        TProperty Get();
    }
}