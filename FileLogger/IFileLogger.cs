namespace FileLogger
{
    public interface IFileLogger
    {
        Task Log(List<string> logs);
    }
}