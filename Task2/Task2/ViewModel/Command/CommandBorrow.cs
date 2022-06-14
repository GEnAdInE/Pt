using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.ViewModel
{
    internal class CommandBorrow : CommandBase
    {

        private readonly MainWindowViewModel _mvw;
        private readonly MyAbstractLib _lib;

        public CommandBorrow(MainWindowViewModel vwm, ref MyAbstractLib lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            if(_mvw.SelectedCatalog != null && _mvw.SelectedUser != null)
            {
                _lib.Borrow(_mvw.SelectedCatalog.Title, _mvw.SelectedCatalog.Author, _mvw.SelectedUser);
                new CommandIsAvailible(this._mvw, _lib).Execute(this);
            }
           
        }
    }
}
