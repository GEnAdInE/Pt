using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Presentation.Model
{
    public class DataLayer : AbstractDataAPI
    {

        private List<State>? localstates;
        private List<User>? localusers;
        private List<Catalog>? localCatalog;
        private List<Event>? localEvent;

        public override List<State> states { get { return localstates; } set { localstates = value; } }
        public override List<User> users { get { return localusers; } set { localusers = value; } }
        public override List<Catalog> catalogs { get { return localCatalog; } set { localCatalog = value; } }
        public override List<Event> events { get { return localEvent; } set { localEvent = value; } }


        public override State FindBook(string title, string author)
        {
            try
            {

                return states.Where(x => x.Book.Title == title && x.Book.Author == author).First();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public override void Borrow(string Title, string Author, string Name, string Surname)
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

        public override void Return(string Title, string Author, string Name, string Surname)
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

        public override User FindUser(string name, string surname)
        {
            try
            {
                return users.Where(x => x.Name == name && x.Surname == surname).First();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public override bool isAvailible(Catalog book)
        {
            if (book != null)
            {
                return FindBook(book.Title, book.Author).Available;
            }
            return false;
        }
        public override void addBook(Catalog catalog)
        {
            catalogs.Add(catalog);
            states.Add(new State(catalog));
        }
        public override void addUser(User user)
        {
            users.Add(user);
        }
    }
}
