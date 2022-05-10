using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.DataLayer
{
    /// <summary>
    /// DataAPI
    /// </summary>
    public abstract class AbstractDataAPI
    {
        private List<Catalog> catalogs = new List<Catalog>(); // catalog of book
        private List<State> states = new List<State>();  // states of the book
        private List<User> users = new List<User>();  // all the users
        private List<Event> events = new List<Event>();  // event history 

       
        /// <summary>
        /// Borrow an iteam
        /// </summary>
        /// <param name="Title"></param> title of the book
        /// <param name="Author"></param> Author
        /// <param name="Name"></param> Name of the user
        /// <param name="Surname"></param> Surname of the user
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

        /// <summary>
        /// Find an user
        /// </summary>
        /// <param name="name"></param> His name
        /// <param name="surname"></param> His surname
        /// <returns></returns> return null if not found
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

        /// <summary>
        /// Find a book
        /// </summary>
        /// <param name="title"></param> It's title
        /// <param name="author"></param> the author
        /// <returns></returns> false if not found
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

        /// <summary>
        /// Returning an item
        /// </summary>
        /// <param name="Title"></param> TItle of the book
        /// <param name="Author"></param> the author
        /// <param name="Name"></param> User name
        /// <param name="Surname"></param> User surname
        /// <exception cref="Exception"></exception>Throw exception if not found
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

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        public void addUser(User user)
        {
            users.Add(user);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="catalog"></param>
        public void addBook(Catalog catalog)
        {
            catalogs.Add(catalog);
            states.Add(new State(catalog));
        }

        /// <summary>
        /// Return the state of a book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns> True or False (false if not found)
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
