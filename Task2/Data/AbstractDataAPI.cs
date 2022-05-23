using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer.sql;

namespace Task2.DataLayer
{
    /// <summary>
    /// DataAPI
    /// </summary>
    public abstract class AbstractDataAPI
    {

        private MyDataContext dataContext;
        private List<Catalog> catalog;
        private List<State> states;
        private List<User> users;
        private List<Event> events;

        public List<Catalog> Catalogs { get { return this.catalog; } set { this.catalog = value; } }
        public List<State> States { get { return this.states; } set { this.states = value;} }
        
        public List<User> Users { get { return this.users; } set { this.users = value; } }

        public List<Event> Events { get { return this.events; } set { this.events = value; } }
  



    public AbstractDataAPI(MyDataContext dataContext)
        {
            this.dataContext = dataContext;
            this.catalog = dataContext.GetTable<Catalog>().ToList();
            this.states = dataContext.GetTable<State>().ToList();
            this.users = dataContext.GetTable<User>().ToList();
            this.events = dataContext.GetTable<Event>().ToList();
          
        }
       

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
