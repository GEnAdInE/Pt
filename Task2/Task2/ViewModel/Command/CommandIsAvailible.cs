using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.ViewModel
{
    public class CommandIsAvailible : CommandBase
    {

        private readonly MainWindowViewModel _mvw;
        private readonly MyAbstractLib _lib;

        public CommandIsAvailible(MainWindowViewModel vwm, MyAbstractLib lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            if(_mvw.SelectedCatalog != null) {
                _mvw.Status = _lib.isAvailble(_mvw.SelectedCatalog.Title, _mvw.SelectedCatalog.Author);

            }
            else
            {
                _mvw.Status = false;
            }
        }
    }
}
