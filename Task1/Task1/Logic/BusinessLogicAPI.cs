﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.DataLayer;

namespace Task1.LogicLayer
{
    public class BusinessLogicAPI
    {
        public AbstractDataAPI dataAPI;
        public DataService service { get; set; }
        public BusinessLogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            service = new DataService(this);
        }
    }
}