using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.LogicLayer
{
    /// <summary>
    /// Implementation of AbstractDataAPI as a Service
    /// </summary>
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
            logicAPI.dataAPI.addUser(new DataLayer.Users() { Name = firstname,Surname = surname});
        }

        public void AddBook(String title, String Author)
        {
            logicAPI.dataAPI.addBook(new DataLayer.Catalogs() { Author = Author,Title = title});
        }

        public bool getAvaibility(String title, String author)
        {
            return logicAPI.dataAPI.isAvailible(new DataLayer.Catalogs() { Author = author,Title = title});
        }

        public DataLayer.States findBook(String title, String author)
        {
            return logicAPI.dataAPI.FindBook(title, author);    
        }

        public DataLayer.Users findUser(String name,String surname)
        {
            return logicAPI.dataAPI.FindUser(name, surname);
        }

        public void EditUSer(string name,string surname,string nName,string nSurname)
        {
            logicAPI.dataAPI.EditUser(name,surname,nName,nSurname);
        }
        public void EditBook(string Title, string Author, string nTitle, string nAuthor)
        {
            logicAPI.dataAPI.EditBook(Title, Author, nTitle, nAuthor);
        }

        public void removeBook(string title, string author)
        {
            logicAPI.dataAPI.removeBook(title, author);
        }

        public void removeUser(string name, string surname)
        {
            logicAPI.dataAPI.removeUser(name, surname);
        }
    }
}
