namespace SampleDataGenerator
{
    public interface IPropertyAssigner<TObject>
    {
        void SetValue(TObject target);
    }
}