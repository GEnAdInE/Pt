using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LogicLayer
{
    public class DataService
    {
        private BusinessLogicAPI logicAPI;

        public DataService(BusinessLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI;
        }

        public void BorrowOneBook(String Title, String Author, String Name, String Surname)
        {
           logicAPI.dataAPI.Borrow(Title, Author, Name, Surname);
        }


        public void ReturnOneBook(String Title, String Author, String Name, String Surname)
        {
           logicAPI.dataAPI.Return(Title, Author, Name, Surname);
        }

        public void AddUser(String firstname,String surname)
        {
            logicAPI.dataAPI.addUser(new DataLayer.User(firstname, surname));
        }

        public void AddBook(String title, String Author)
        {
            logicAPI.dataAPI.addBook(new DataLayer.Catalog(title, Author));
        }

        public bool getAvaibility(String title, String author)
        {
            return logicAPI.dataAPI.isAvailible(new DataLayer.Catalog(title, author));
        }
    }
}
