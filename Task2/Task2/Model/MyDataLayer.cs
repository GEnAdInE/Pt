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
            if(Catalogs.Count > 0 && States.Count > 0)
            {
                Catalogs tmp = Catalogs.Where(x => x.Title == title && x.Author == author).First();
                return States.Where(x => x.Book == tmp.Id).First();
            }
            return null;
           
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
            int id = -1;
            if (FindBook(catalog.Title, catalog.Author) == null)
            {
                dataContext.Catalogs.InsertOnSubmit(new Catalogs { Title = catalog.Title, Author = catalog.Author });
                dataContext.SubmitChanges();
                Catalogs = dataContext.GetTable<Catalogs>().ToList();
                id = Catalogs.Where(x => x.Title == catalog.Title && x.Author == catalog.Author).First().Id;
                dataContext.States.InsertOnSubmit(new States { Book = id, Availible = 1 });
                dataContext.SubmitChanges();
                States = dataContext.GetTable<States>().ToList();
            }           
        }
        public override void addUser(Users user)
        {
            Users.Add(user);
        }

        public override void removeBook(string title,string author)
        {
            States s = FindBook(title, author);
            if(s != null)
            {
                States.Remove(s);
                Catalogs.Remove(Catalogs.Where(x => x.Title == title && x.Author == author).First());
            }
               
           
        }

        public override void removeUser(string name,string firstname)
        {
            Users u = FindUser(name, firstname);
            if(u != null)
            {
                Users.Remove(u);
            }
        }

    }
}
