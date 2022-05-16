using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;

namespace Task2.LogicLayer
{
    public class BusinessLogicAPI
    {
        public AbstractDataAPI dataAPI;
        public DataService service { get; set; }
        public BusinessLogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            this.dataAPI.states = new List<State>();
            this.dataAPI.users = new List<User>();
            this.dataAPI.events = new List<Event>();
            this.dataAPI.catalogs = new List<Catalog>();

            service = new DataService(this);
        }
    }
}
