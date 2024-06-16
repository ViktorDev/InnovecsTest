namespace InnovecsTest
{
    public interface ILoader<T>
    {
        T Load(string path);
    }
}
