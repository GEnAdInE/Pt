using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.DataLayer
{
    /// <summary>
    /// DataAPI
    /// </summary>
    public abstract class AbstractDataAPI
    {
        public abstract List<Catalog> catalogs { get; set; }
        public abstract List<State> states { get; set; } // states of the book
        public abstract List<User> users { get; set; }  // all the users
        public abstract List<Event> events { get; set; }  // event history 


       

        /// <summary>
        /// Find an user
        /// </summary>
        /// <param name="name"></param> His name
        /// <param name="surname"></param> His surname
        /// <returns></returns> return null if not found
        public abstract User FindUser(string name, string surname);
        
          
        

        /// <summary>
        /// Find a book
        /// </summary>
        /// <param name="title"></param> It's title
        /// <param name="author"></param> the author
        /// <returns></returns> false if not found
        public abstract State FindBook(string title, string author);
       

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        public abstract void addUser(User user);
      

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="catalog"></param>
        public abstract void addBook(Catalog catalog);
     

        /// <summary>
        /// Return the state of a book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns> True or False (false if not found)
        public abstract bool isAvailible(Catalog book);
        
       
        public abstract void Borrow(String Title, String Author, String Name, String Surname);
        public abstract void Return(String Title, String Author, String Name, String Surname);
       
    }
}
