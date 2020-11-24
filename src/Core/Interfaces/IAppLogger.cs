namespace Core.Interfaces
{
    /// <summary>
    /// Logger App
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string msg, params object[] args);
        void LogWarning(string msg, params object[] args);
    }
}