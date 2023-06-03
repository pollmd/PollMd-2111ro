using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public interface ILogger
    {
        public void LogMessage(string message);
    }

    public class DbLogger: ILogger
    {
        public void LogMessage(string aStackTrace)
        {
            // record log
        }
    }
    public class FileLogger: ILogger
    {
        public void LogMessage(string aStackTrace)
        {
            // record log
        }
    }

    public class ExceptionLogger
    {
        public ILogger _logger { get; set; }
        public ExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogException(Exception e)
        {
             _logger.LogMessage(GetMessage(e));
        }

        string? GetMessage(Exception e)
        {
            return e.Message != string.Empty ? e.Message : e.StackTrace;
        }
    }

    public class DataExporter
    {
        public void ExportDataFromFi()
        {
            try 
            { //...
            }
            catch(IOException e) 
            {
                new ExceptionLogger(new FileLogger());
            }
            catch (Exception e)
            {
                new ExceptionLogger(new DbLogger());
            }
        }
              
    }
}
