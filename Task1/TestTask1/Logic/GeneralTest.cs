using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.DataLayer;
using Task1.LogicLayer;

namespace TestTask1.Logic
{
    [TestClass]
    public class GeneralTest
    {

        BusinessLogicAPI? APIBorrow;
        BusinessLogicAPI? APIReturn;





        public void GenerateUser()
        {
            APIBorrow.service.AddUser("John", "Doe");
            APIBorrow.service.AddUser("Jane", "Doe");
            APIBorrow.service.AddUser("Jack", "Doe");
            APIBorrow.service.AddUser("Jill", "Doe");
            APIBorrow.service.AddUser("Joe", "Doe");

            APIReturn.service.AddUser("John", "Doe");
            APIReturn.service.AddUser("Jane", "Doe");
            APIReturn.service.AddUser("Jack", "Doe");
            APIReturn.service.AddUser("Jill", "Doe");
            APIReturn.service.AddUser("Joe", "Doe");
        }
        public void GenerateBook() { 
            APIBorrow.service.AddBook("Victor Hugo", "Les Misérables");
            APIBorrow.service.AddBook("Victor Hugo", "Le Petit Prince");
            APIBorrow.service.AddBook("Stendhal", "Le Comte de Monte Cristo");
            APIBorrow.service.AddBook("Shakespeare", "Hamlet");
            APIBorrow.service.AddBook("Shakespeare", "Romeo et Juliette");

            APIReturn.service.AddBook("Victor Hugo", "Les Misérables");
            APIReturn.service.AddBook("Victor Hugo", "Le Petit Prince");
            APIReturn.service.AddBook("Stendhal", "Le Comte de Monte Cristo");
            APIReturn.service.AddBook("Shakespeare", "Hamlet");
            APIReturn.service.AddBook("Shakespeare", "Romeo et Juliette");
            APIReturn.service.findBook("Shakespeare", "Hamlet").ChangeState();
        }

        [TestInitialize]
        public void Init()
        {
            this.APIBorrow = new BusinessLogicAPI(new DataAPIOnlyBorrow());
            this.APIReturn = new BusinessLogicAPI(new DataAPIOnlyReturn());

            GenerateUser();
            GenerateBook();
        }

        [TestMethod]
        public void BorrowABookTest()
        {

            Assert.IsTrue(APIBorrow.service.getAvaibility("Victor Hugo", "Les Misérables"));
            APIBorrow.service.BorrowOneBook("Victor Hugo", "Les Misérables", "John", "Doe");
            Assert.IsFalse(APIBorrow.service.getAvaibility("Victor Hugo", "Les Misérables"));

            Assert.IsTrue(APIReturn.service.getAvaibility("Victor Hugo", "Les Misérables"));
            Assert.ThrowsException<NotImplementedException>(() =>
            {
                APIReturn.service.BorrowOneBook("Victor Hugo", "Les Misérables", "John", "Doe");
            });

        }

        [TestMethod]
        public void ReturnABook()
        {
            Assert.IsFalse(APIReturn.service.getAvaibility("Shakespeare", "Hamlet"));
            Assert.ThrowsException<NotImplementedException>(() => { APIBorrow.service.ReturnOneBook("Victor Hugo", "Les Misérables", "John", "Doe"); });
            APIReturn.service.ReturnOneBook("Shakespeare", "Hamlet", "John", "Doe");

            Assert.IsTrue(APIReturn.service.getAvaibility("Shakespeare", "Hamlet"));
        }
    }
}