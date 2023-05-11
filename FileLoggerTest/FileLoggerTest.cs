using System.Text;
using Xunit;
using FileLogging;

namespace FileLoggerTest
{
    public class FileLoggerTest
    {
        private readonly FileInfo _fileInfoTest;

        public const string Testfile1 = @"\Testfile.txt";
        private readonly List<string> logList = new List<string>();
        public FileLoggerTest()
        {
            _fileInfoTest = new FileInfo(new StringBuilder(System.Environment.CurrentDirectory).Append(Testfile1).ToString());
            Enumerable.Range(1, FileLogger.BatchSaveThreshold).ToList().ForEach(x => logList.Add(string.Format("Some log entry {0}", x)));
        }

        [Fact]
        public async Task CanSave()
        {
            IFileLogger fileLogger = new FileLogger(_fileInfoTest);
            await fileLogger.Log(logList);
            Assert.True(_fileInfoTest.Exists);
        }
    }
}