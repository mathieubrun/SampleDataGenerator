namespace SampleDataGenerator
{
    public interface IPropertyGenerator<TProperty>
    {
        TProperty Get();
    }
}