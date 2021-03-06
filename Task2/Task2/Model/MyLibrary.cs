using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task2.LogicLayer;
using Task2.Services;

namespace Task2.Presentation.Model
{
    public class MyLibrary : MyAbstractLib
    {
        private List<User> users;
        private List<Catalog> catalogs;
        private List<Event> events;
        private List<State> states;
        private BusinessLogicAPI businesAPi;

        public override List<User> USER { get { return users; } set { users = value; } }
        public override List<Catalog> CATALOG { get { return catalogs; } set { catalogs = value; } }
        public override List<Event> EVENT { get { return events; } set { events = value; } }
        public override List<State> STATES { get { return states; } set { states = value; } }


        public MyLibrary()
        {
            users = new List<User>();
            catalogs = new List<Catalog>();
            events = new List<Event>();
            states = new List<State>();
            businesAPi = new BusinessLogicAPI(new MyDataLayer(LINQ.GetContext()));
           
        }

   

        public override void AddState(State state)
        {
            if (!BookExist(state.Book.Title, state.Book.Author))
            {
                catalogs.Add(state.Book);
            }
            states.Add(state);
            businesAPi.service.AddBook(state.Book.Title, state.Book.Author);

        }

        public override bool BookExist(string Title, string Author)
        {
            if(catalogs.Where(c => c.Title == Title && c.Author == Author).Any())
            {
                return true;
            }
            return false;
        }

        public override void AddUser(string surname,string firstname)
        {
            users.Add(new User(firstname, surname));
            businesAPi.service.AddUser(firstname, surname);

        }

        public override void RemoveUser(User u)
        {
            if(u != null)
            {
                if (users.Contains(u))
                {
                    users.Remove(u);
                    businesAPi.service.removeUser(u.Name, u.Surname);

                }

            }
            
        }

        public override void RemoveBook(Catalog c)
        {
            if (c != null)
            {
                if (catalogs.Contains(c))
                {
                
                catalogs.Remove(c);
                businesAPi.service.removeBook(c.Title, c.Author);

                }
            }
            
        }

        public override void Borrow(string title,string author,User user)
        {
            
                State state = STATES.Find(s => s.Book.Title == title && s.Book.Author == author && s.Available == true);
                if (state != null && user != null)
                {
                    events.Add(new Borrowing(state, user));
                    state.ChangeState();
                    businesAPi.service.BorrowOneBook(state.Book.Title, state.Book.Author, user.Name, user.Surname);

                }
            
        }

        public override void Return(string title, string author, User user)
        {
            
                State state = STATES.Find(s => s.Book.Title == title && s.Book.Author == author && s.Available == false);
                if (state != null && user != null)
                {
                    Task.Run(() =>
                    {
                        events.Add(new Returning(state, user));
                        state.ChangeState();
                        businesAPi.service.ReturnOneBook(state.Book.Title, state.Book.Author, user.Name, user.Surname);

                    });


                }
           


        }

        public override bool isAvailble(string title,string authoer)
        {

            return true;
            
           
        }

        public override void EditUser(string name,string firstname,string nName,string nfirstname)
        {
            businesAPi.service.EditUSer(name,firstname,nName,nfirstname);
            User u = USER.Find(x => x.Name == name && x.Surname == firstname);
            u.Surname = nfirstname;
            u.Name = nName;
            
        }

        public override void EditBOok(string title, string authoer, string nTitle, string nAuthoer)
        {
            businesAPi.service.EditBook(title, authoer, nTitle, nAuthoer);
            Catalog c = CATALOG.Find(x => x.Title == title && x.Author == authoer);
            c.Title = nTitle;
            c.Author = nAuthoer;

        }


    }
}
