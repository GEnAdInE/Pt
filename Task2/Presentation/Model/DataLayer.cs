using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Task2.Presentation.Model
{
    public class DataLayer : AbstractDataAPI
    {
        public DataLayer(Task2.DataLayer.sql.MyDataContext dataContext) : base(dataContext)
        {
        }

        public override State FindBook(string title, string author)
        {
            try
            {

                return States.Where(x => x.Book.Title == title && x.Book.Author == author).First();

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
                    Events.Add(new Borrowing(state, User));
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
                    Events.Add(new Returning(state, User));
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
                return Users.Where(x => x.Name == name && x.Surname == surname).First();

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
            Catalogs.Add(catalog);
            States.Add(new State(catalog));
        }
        public override void addUser(User user)
        {
            Users.Add(user);
        }
    }
}
