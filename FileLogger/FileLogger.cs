using System.Text;

namespace FileLogger
{
    public class FileLogger : IFileLogger
{
    private readonly List<string> _logs = new List<string>();
    private readonly FileInfo _fileInfoToSave;
    private Object _locker = new Object();
    public const int BatchSaveThreshold10000 = 10000;
    private bool AnyLogsToSave { get { return _logs.Count >= BatchSaveThreshold10000; } }

    public FileLogger(FileInfo fileInfoToSave)
    {
        _fileInfoToSave = fileInfoToSave;
    }
    // Synchronous call for creating a list
    public async Task Log(List<string> logs)
    {
        _logs.AddRange(logs);
        await SaveLogToFileAsBatch();
    }
    // Asynchronous call to save fast
    private async Task SaveLogToFileAsBatch()
    {

        while (AnyLogsToSave)
        {
            // Try to get the file handle
            StringBuilder logsConcatenatedWithLineFeed = new StringBuilder().AppendJoin(System.Environment.NewLine, _logs.Take(BatchSaveThreshold10000));
            while (true)
            {
                // Save a batch of 
                try
                {
                    lock (_locker)
                    {
                        using (FileStream file = new FileStream(_fileInfoToSave.FullName, FileMode.Append, FileAccess.Write))
                        using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                        {
                            writer.Write(logsConcatenatedWithLineFeed);
                            _logs.RemoveRange(0, BatchSaveThreshold10000);
                        }
                    }
                }
                catch
                {

                }
                await Task.Delay(5);
            }

        }
    }
}