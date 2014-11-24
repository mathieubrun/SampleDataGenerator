namespace SampleDataGenerator
{
    internal interface IPropertyAssigner<TObject>
    {
        void SetValue(TObject target);
    }
}