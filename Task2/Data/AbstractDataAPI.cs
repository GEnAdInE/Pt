
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Task2.DataLayer
{
    /// <summary>
    /// DataAPI
    /// </summary>
    public abstract class AbstractDataAPI
    {

        public DataClassesDataContext dataContext;
        private List<Catalogs> catalog;
        private List<States> states;
        private List<Users> users;
        private List<Events> events;

        public List<Catalogs> Catalogs { get { return this.catalog; } set { this.catalog = value; } }
        public List<States> States { get { return this.states; } set { this.states = value;} }
        
        public List<Users> Users { get { return this.users; } set { this.users = value; } }

        public List<Events> Events { get { return this.events; } set { this.events = value; } }
  



    public AbstractDataAPI(DataClassesDataContext dataContext)
        {
            this.dataContext = dataContext;

            this.catalog =this.dataContext.Catalogs.ToList();
            this.users = this.dataContext.Users.ToList();
            this.states =this. dataContext.States.ToList();
            this.events = this.dataContext.Events.ToList();
        }

        /// <summary>
        /// Find an user
        /// </summary>
        /// <param name="name"></param> His name
        /// <param name="surname"></param> His surname
        /// <returns></returns> return null if not found
        public abstract Users FindUser(string name, string surname);
        

        /// <summary>
        /// Find a book
        /// </summary>
        /// <param name="title"></param> It's title
        /// <param name="author"></param> the author
        /// <returns></returns> false if not found
        public abstract States FindBook(string title, string author);
       

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        public abstract void addUser(Users user);
      

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="catalog"></param>
        public abstract void addBook(Catalogs catalog);
     
        public abstract void removeUser(string name,string firstname);

        public abstract void removeBook(string Title, string Author);

        public abstract void EditBook(string title,string author,string nTitle,string nAuthor);
        public abstract void EditUser(string name, string surname, string nName, string nSurname);

        /// <summary>
        /// Return the state of a book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns> True or False (false if not found)
        public abstract bool isAvailible(Catalogs book);
        
       
        public abstract void Borrow(String Title, String Author, String Name, String Surname);
        public abstract void Return(String Title, String Author, String Name, String Surname);
       
    }
}
