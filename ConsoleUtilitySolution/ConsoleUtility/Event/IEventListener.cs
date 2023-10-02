namespace ConsoleUtility
{
    public interface IEventListener<T>
    {
        void OnInvoke(T eventData);
    }
}