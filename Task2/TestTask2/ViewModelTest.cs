using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace TestTask2
{
    [TestClass]
    public class ViewModelTest
    {

        MainWindowViewModel vwm1 = new MainWindowViewModel(new MainWindowModel(new MyTestLib()));
        MainWindowViewModel vwm2 = new MainWindowViewModel(new MainWindowModel(new MyTestLib()));

        [TestInitialize]
        public void init()
        {
            vwm1.mainModel.myLibrary.AddUser("Robin", "Moulinou");
            vwm2.mainModel.myLibrary.AddUser("Robin", "Moulinou");

        }


        [TestMethod]
        public void TestMethod1()
        {
          

            MyAbstractLib lib = vwm1.mainModel.myLibrary;


            int initial = lib.STATES.Count;
            lib.AddState(new State(new Catalog("test", "test")));
            Assert.IsTrue(lib.STATES.Count == initial+1);
            

        }
        [TestMethod]
        public void Test2()
        {
            MyAbstractLib lib = vwm2.mainModel.myLibrary;
            
            lib.Borrow("test", "test", new User("Robin", "Moulinou"));
            Assert.IsTrue(lib.isAvailble("test", "test") == false);
            lib.Return("test", "test", new User("Robin", "Moulinou"));
         

        }

    } 
}
