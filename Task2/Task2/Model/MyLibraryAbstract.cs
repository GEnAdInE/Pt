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
    public abstract class MyAbstractLib
    {


        public abstract List<User> USER { get; set; }
        public abstract List<Catalog> CATALOG { get; set; }
        public abstract List<Event> EVENT { get; set; }
        public abstract List<State> STATES { get; set; }


        public abstract void AddState(State state);

        public abstract bool BookExist(string Title, string Author);

        public abstract void AddUser(string surname, string firstname);
        public abstract void RemoveUser(User u);

        public abstract void RemoveBook(Catalog c);


        public abstract void Borrow(string title, string author, User user);


        public abstract void Return(string title, string author, User user);



        public abstract bool isAvailble(string title, string authoer);



        public abstract void EditUser(string name, string firstname, string nName, string nfirstname);


        public abstract void EditBOok(string title, string authoer, string nTitle, string nAuthoer);
   


    }
}
