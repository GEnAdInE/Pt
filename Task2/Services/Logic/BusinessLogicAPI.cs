using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Task2.LogicLayer
{
    public class BusinessLogicAPI
    {
        public AbstractDataAPI dataAPI;
        public DataService service { get; set; }
        public BusinessLogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            
            service = new DataService(this);
        }

      
    }

    public class LINQ
    {
        public static DataClassesDataContext GetContext()
        {

            string m_connection = "";
            string _StringDb = @"db.mdf";
            string _workingFOlder = Environment.CurrentDirectory;
            Console.WriteLine(_workingFOlder);
            string _path = Path.Combine(_workingFOlder, _StringDb);
            FileInfo f = new FileInfo(_path);
            if (f.Exists)
            {
                m_connection = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_path};Integrated Security=True;Connect Timeout=30";
            }
            return new DataClassesDataContext(m_connection);
            
        }
    }
}
