using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.Model.Command
{
    public class CommandAddUser : CommandBase
    {
        private readonly MainWindowViewModel _mvw;
        private readonly MyLibrary _lib;

        public CommandAddUser(MainWindowViewModel vwm,MyLibrary lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {
            _lib.AddUser(_mvw.newUser.Surname, _mvw.newUser.Name);
            _mvw.Users.Add(new User(_mvw.newUser.Surname, _mvw.newUser.Name));
        }

        
    }
}
