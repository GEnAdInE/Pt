using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.ViewModel
{
    internal class CommandDeleteBook : CommandBase
    {
        private readonly MainWindowViewModel _mvw;
        private readonly MyAbstractLib _lib;

        public CommandDeleteBook(MainWindowViewModel vwm, MyAbstractLib lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            if (_mvw.SelectedCatalog != null)
            {
                _lib.RemoveBook(_mvw.SelectedCatalog);
                _mvw.Catalogs.Remove(_mvw.SelectedCatalog);
            }
        }

    }
}
