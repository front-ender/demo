namespace FileLogging
{
    public interface IFileLogger
    {
        Task Log(List<string> logs);
    }
}