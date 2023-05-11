using System.Text;
using Xunit;
using FileLogging;

namespace FileLoggerTest
{
    public class FileLoggerTest
    {
        FileInfo _fileInfoTest;

        public const string Testfile1 = @"\Testfile.txt";
        private List<string> logList = new List<string>();
        public FileLoggerTest()
        {
            _fileInfoTest = new FileInfo(new StringBuilder(System.Environment.CurrentDirectory).Append(Testfile1).ToString());
            for (int i = 0; i < FileLogger.BatchSaveThreshold; i++)
            {
                logList.Add(string.Format("Some log entry {0}", i));
            }
        }

        [Fact]
        public async Task CanSave()
        {
            IFileLogger fileLogger = new FileLogger(_fileInfoTest);
            await fileLogger.Log(logList);
            Assert.True(_fileInfoTest.Exists);
        }
        [Fact]
        public void CanSave2()
        {
            IFileLogger fileLogger = new FileLogger(_fileInfoTest);
            fileLogger.Log(logList);
            Assert.True(_fileInfoTest.Exists);
        }

    }
}