using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.DataLayer;
using Task1.LogicLayer;

namespace TestTask1.Logic
{
    [TestClass]
    public class GeneralTest
    {

        BusinessLogicAPI? API;

        Catalog mybook = new Catalog("Book1", "Author1");
        User myUser = new User("User1", "Test");

        [TestInitialize]
        public void Init()
        {
            this.API = new BusinessLogicAPI(new DataAPI());
            
            API.dataAPI.addUser(myUser);
            API.dataAPI.addBook(mybook);
        }

        [TestMethod]
        public void BorrowABookTest()
        {

            Assert.IsTrue(API.service.getAvaibility(mybook.Title,mybook.Author));
            API.service.BorrowOneBook(mybook.Title, mybook.Author, myUser.Name, myUser.Surname);
            Assert.IsFalse(API.service.getAvaibility(mybook.Title, mybook.Author));

        }

        [TestMethod]
        public void ReturnABook()
        {
            API.service.BorrowOneBook(mybook.Title, mybook.Author, myUser.Name, myUser.Surname);
            API.service.ReturnOneBook(mybook.Title,mybook.Author,myUser.Name, myUser.Surname);
            Assert.IsTrue(API.service.getAvaibility(mybook.Title, mybook.Author));


        }
    }
}