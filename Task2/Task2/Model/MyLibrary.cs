using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;
using Task2.LogicLayer;

namespace Task2.Presentation.Model
{
    public class MyLibrary
    {
        private List<User> users;
        private List<Catalog> catalogs;
        private List<Event> events;
        private List<State> states;
        private BusinessLogicAPI businesAPi;

        public List<User> USER { get { return users; } set { users = value; } }
        public List<Catalog> CATALOG { get { return catalogs; } set { catalogs = value; } }
        public List<Event> EVENT { get { return events; } set { events = value; } }
        public List<State> STATES { get { return states; } set { states = value; } }


        public MyLibrary()
        {
            users = new List<User>();
            catalogs = new List<Catalog>();
            events = new List<Event>();
            states = new List<State>();
            businesAPi = new BusinessLogicAPI(new MyDataLayer(LINQ.GetContext()));
            foreach(Users u in businesAPi.dataAPI.Users)
            {
                users.Add(new User(u.Name, u.Surname));
            }
            foreach (Catalogs c in businesAPi.dataAPI.Catalogs)
            {
                Catalog book = new Catalog(c.Title, c.Author);
                catalogs.Add(book);
                states.Add(new State(book));
            }
         
        }

        public void AddState(State state)
        {
            if (!BookExist(state.Book.Title, state.Book.Author))
            {
                catalogs.Add(state.Book);
            }
            states.Add(state);
            businesAPi.service.AddBook(state.Book.Title, state.Book.Author);
        }

        public bool BookExist(string Title, string Author)
        {
            if(catalogs.Where(c => c.Title == Title && c.Author == Author).Any())
            {
                return true;
            }
            return false;
        }

        public void AddUser(string surname,string firstname)
        {
            users.Add(new User(firstname, surname));
            businesAPi.service.AddUser(firstname, surname);
        }

        public void RemoveUser(User u)
        {
            users.Remove(u);
            businesAPi.dataAPI.removeUser(u.Name,u.Surname);
        }

        public void RemoveBook(Catalog c)
        {
            catalogs.Remove(c);
            businesAPi.dataAPI.removeBook(c.Title, c.Author);
        }

        public void Borrow(string title,string author,User user)
        {
            State state = STATES.First(s => s.Book.Title == title && s.Book.Author == author && s.Available == true);
            events.Add(new Borrowing(state, user));
            businesAPi.service.BorrowOneBook(state.Book.Title, state.Book.Author, user.Name, user.Surname);
        }

        public void Return()
        {

        }

    }
}
