using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.ViewModel
{
    public class CommandEditBook :CommandBase
    {

        private readonly MainWindowViewModel _mvw;
        private readonly MyAbstractLib _lib;

        public CommandEditBook(MainWindowViewModel vwm, ref MyAbstractLib lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            if (_mvw.SelectedCatalog != null && _mvw.EditCatalog != null)
            {
                _lib.EditBOok(_mvw.SelectedCatalog.Title, _mvw.SelectedCatalog.Author, _mvw.EditCatalog.Title, _mvw.EditCatalog.Author);
            }

        }

    }
}
