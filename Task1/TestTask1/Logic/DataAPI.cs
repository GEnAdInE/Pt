using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1.Logic
{
    internal class DataAPI : Task1.DataLayer.AbstractDataAPI
    {
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            try
            {
                BorrowItem(Title, Author, Name, Surname);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            try
            {
                ReturnItem(Title, Author, Name, Surname);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}

