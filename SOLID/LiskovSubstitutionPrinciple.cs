using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class ReadOnlySqlFile { }

    public interface IReadableSqlFile
    {
        public string LoadText();
    }

    public interface IWriteableSqlFile
    {
        public string SaveText();
    }

    public class SqlFile: IReadableSqlFile, IWriteableSqlFile
    {
        public string FilePath { get; set; }
        public string FileText { get; set; }

        public string LoadText()
        {
            throw new NotImplementedException();
        }

        public string SaveText()
        {
            throw new NotImplementedException();
        }
    }

    class SqlFileManager
    {
        public string GetTextFromFiles(List<IReadableSqlFile> lstSqlFiles) 
        {
            StringBuilder result= new StringBuilder();

            foreach(var file in lstSqlFiles)
            {
                result.Append(file.LoadText());
            }

            return result.ToString();
        }

        public void SaveTextFromFiles(List<IWriteableSqlFile> lstSqlFiles)
        {
            foreach (var file in lstSqlFiles)
            {
                file.SaveText();
            }
        }
    }
}
