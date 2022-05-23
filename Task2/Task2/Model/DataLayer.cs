using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Task2.Presentation.Model
{
    public class MyDataLayer : AbstractDataAPI
    {
        public MyDataLayer(DataClassesDataContext dataContext) : base(dataContext)
        {

        }

        public override States FindBook(string title, string author)
        {
            int id = -1;
            foreach (Catalogs c in Catalogs)
            {
                if (c.Title == title && c.Author == author)
                {
                    id = c.Id;
                }
            }

            //If there is several copies of the book, there is several state in the list
            Predicate<States> predicate = x => x.Book == id;
            if (States.Exists(predicate))
            {
                return States.Find(predicate);
            }
            else
            {
                return null;
            }

        }
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            States state = FindBook(Title, Author);
            if (state != null)
            {
                Users User = FindUser(Name, Surname);
                if (User != null)
                {

                    dataContext.Events.InsertOnSubmit(new Events { stateId = state.Id , userId = User.Id , description = "borrow"});
                    dataContext.SubmitChanges();
                    this.Events = dataContext.GetTable<Events>().ToList();
                }
                else
                {
                    throw new ArgumentException("User not found");
                }
            }
            else
            {
                throw new ArgumentException("Book not found");
            }

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            Users User = FindUser(Name, Surname);
            if (User == null)
            {
                throw new ArgumentException("User not found");
            }
            else
            {
                States state = FindBook(Title, Author);
                if (state != null)
                {
                    dataContext.Events.InsertOnSubmit(new Events { stateId = state.Id, userId = User.Id, description = "Return" });
                    dataContext.SubmitChanges();
                    Events = dataContext.GetTable<Events>().ToList();
                }
                else
                {
                    throw new ArgumentException("Book not found");
                }
            }
        }

        public override Users FindUser(string name, string surname)
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
        public override bool isAvailible(Catalogs book)
        {
            if (book != null)
            {
                if (FindBook(book.Title, book.Author).Availible == 1)
                    return true;
                else
                    return false;
            }
            return false;
        }
        public override void addBook(Catalogs catalog)
        {
            Catalogs.Add(catalog);
            States.Add(new States(){ Availible = 1, Book = catalog.Id});
        }
        public override void addUser(Users user)
        {
            Users.Add(user);
        }

      
    }
}
