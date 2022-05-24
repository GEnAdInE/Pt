﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.Model.Command
{
    public class CommandCreateBook : CommandBase
    {
        private readonly MainWindowViewModel _mvw;
        private readonly MyLibrary _lib;

        public CommandCreateBook(MainWindowViewModel vwm,ref MyLibrary lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
           
            _lib.AddState(new State(new Catalog(_mvw.newCatalog.Title, _mvw.newCatalog.Author)));
            _mvw.Catalogs.Add(new Catalog(_mvw.newCatalog.Title, _mvw.newCatalog.Author));
        }

    }
}
