namespace InnovecsTest.Load
{
    public interface ILoader<T>
    {
        T Load(string path);
    }
}
