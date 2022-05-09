using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.DataLayer
{
    /// <summary>
    /// Usefull function for Data layer
    /// </summary>
    public abstract class AbstractDataAPI
    {
        private List<Catalog> catalogs = new List<Catalog>(); //our books
        private List<State> states = new List<State>(); //the states
        private List<User> users = new List<User>(); //useres
        private List<Event> events = new List<Event>(); //events list

       

        public void BorrowItem(String Title, String Author, String Name, String Surname)
        {
            State state = FindBook(Title, Author);
            if (state != null)
            {
                User User = FindUser(Name, Surname);
                if (User != null)
                {
                    events.Add(new Borrowing(state, User));
                    state.ChangeState();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("User not found");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Book not found");
            }
        }

        public User FindUser(string name, string surname)
        {
            try
            {
                return users.Where(x => x.Name == name && x.Surname == surname).First();

            }catch (Exception ex)
            {

            return null;
            }
        }

        public State FindBook(string title, string author)
        {
            try {
                
                return states.Where(x => x.Book.Title == title && x.Book.Author == author).First();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public void ReturnItem(String Title, String Author, String Name, String Surname)
        {
            User User = FindUser(Name, Surname);
            if (User == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                State state = FindBook(Title, Author);
                if (state != null)
                {
                    events.Add(new Returning(state, User));
                    state.ChangeState();

                }
                else
                {
                    throw new Exception("Book not found");
                }
            }
        }

        public void addUser(User user)
        {
            users.Add(user);
        }

        public void addBook(Catalog catalog)
        {
            catalogs.Add(catalog);
            states.Add(new State(catalog));
        }

        public bool isAvailible(Catalog book)
        {
            if (book != null)
            {
                return FindBook(book.Title, book.Author).Available;
            }
            return false;
        }
       
        public abstract void Borrow(String Title, String Author, String Name, String Surname);
        public abstract void Return(String Title, String Author, String Name, String Surname);
       
    }
}
