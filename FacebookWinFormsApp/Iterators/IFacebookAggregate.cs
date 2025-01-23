namespace BasicFacebookFeatures.Iterators
{
    public interface IFacebookAggregate<T>
    {
        IFacebookIterator<T> CreateIterator();
    }
} 