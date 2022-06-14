using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task2.LogicLayer;
using Task2.Presentation.Model;
using Task2.Services;

namespace TestTask2
{
    public class MyTestLib : MyAbstractLib
    {
        private List<User> users;
        private List<Catalog> catalogs;
        private List<Event> events;
        private List<State> states;

        public override List<User> USER { get { return users; } set { users = value; } }
        public override List<Catalog> CATALOG { get { return catalogs; } set { catalogs = value; } }
        public override List<Event> EVENT { get { return events; } set { events = value; } }
        public override List<State> STATES { get { return states; } set { states = value; } }


        public MyTestLib()
        {
            users = new List<User>();
            catalogs = new List<Catalog>();
            events = new List<Event>();
            states = new List<State>();
            
        }

   

        public override void AddState(State state)
        {
            if (!BookExist(state.Book.Title, state.Book.Author))
            {
                catalogs.Add(state.Book);
            }
            states.Add(state);

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

        }

        public override void RemoveUser(User u)
        {
            if(u != null)
            {
                if (users.Contains(u))
                {
                    users.Remove(u);

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

                    });


                }
           


        }

        public override bool isAvailble(string title,string authoer)
        {

            State s = states.Find(x => x.Book.Title == title && x.Book.Author == authoer);
                if (s == null)
                {
                    return false;
                }
            return s.Available;
                
            
           
        }

        public override void EditUser(string name,string firstname,string nName,string nfirstname)
        {
            User u = USER.Find(x => x.Name == name && x.Surname == firstname);
            u.Surname = nfirstname;
            u.Name = nName;
            
        }

        public override void EditBOok(string title, string authoer, string nTitle, string nAuthoer)
        {
            Catalog c = CATALOG.Find(x => x.Title == title && x.Author == authoer);
            c.Title = nTitle;
            c.Author = nAuthoer;

        }


    }
}
