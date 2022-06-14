using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.LogicLayer;

namespace Task2.Presentation.Model
{
    public class MainWindowModel
    {
       public MyAbstractLib myLibrary;

        public MainWindowModel()
        {
            myLibrary = new MyLibrary();
        }
       
        public MainWindowModel(MyAbstractLib library)
        {
            myLibrary = library;
        }
     
    }
}
