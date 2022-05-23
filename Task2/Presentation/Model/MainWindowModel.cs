using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer.sql;
using Task2.LogicLayer;

namespace Task2.Presentation.Model
{
    public class MainWindowModel
    {
       public BusinessLogicAPI businessLogicAPI;

        public void setDataContext()
        {
            
            string m_connection = "";
            string _StringDb = @"sql\database.mdf";
            string _workingFOlder = Environment.CurrentDirectory;
            string _path = Path.Combine(_workingFOlder, _StringDb);
            FileInfo f = new FileInfo(_path);
            if (f.Exists)
            {
                m_connection = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_path};Integrated Security=True;Connect Timeout=30";
            }
            MyDataContext myData = new MyDataContext(m_connection);
            businessLogicAPI = new BusinessLogicAPI(new DataLayer(myData));

            
        }
    }
}
