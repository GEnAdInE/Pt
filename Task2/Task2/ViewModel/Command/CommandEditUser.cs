using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.Model;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.ViewModel
{
    public class CommandEditUser : CommandBase
    {
        private readonly MainWindowViewModel _mvw;
        private readonly MyAbstractLib _lib;

        public CommandEditUser(MainWindowViewModel vwm, ref MyAbstractLib lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            if (_mvw.SelectedUser != null && _mvw.EditUser != null)
            {
                _lib.EditUser(_mvw.SelectedUser.Name, _mvw.SelectedUser.Surname, _mvw.EditUser.Name, _mvw.EditUser.Surname);
            }

        }
    }
}
