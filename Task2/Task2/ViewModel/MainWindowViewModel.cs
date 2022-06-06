using Task2.Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;
using System.Collections.ObjectModel;
using Task2.Presentation.Model.Command;
using Task2.Presentation.ViewModel.Base;

namespace Task2.Presentation.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowModel mainModel;

        private ObservableCollection<User> m_users;
        public ObservableCollection<User> Users
        {
            get => m_users;
            set
            {
                m_users = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Catalog> m_catalogs;
        public ObservableCollection<Catalog> Catalogs
        {
            get => m_catalogs;
            set
            {
                m_catalogs = value;
                RaisePropertyChanged();
            }
        } 

        private User m_user;
        public User SelectedUser
        {
            get => m_user;
            set
            {
                m_user = value;
                RaisePropertyChanged();
            }
        }

        private Catalog m_catalog;
        private bool m_status;
        private User m_newUser = new User("", "");
        private Catalog m_newCatalog = new Catalog("", "");
        private Catalog m_editCatalog;
        private User m_editUser;

        public Catalog newCatalog
        {
            get => m_newCatalog;
            set
            {
                m_newCatalog = value;
                RaisePropertyChanged();
            }
        }

        public Catalog SelectedCatalog
        {
            get => m_catalog;
            set
            {
                m_catalog = value;
                RaisePropertyChanged();
            }
        }

        public Catalog EditCatalog
        {
            get => m_editCatalog;
            set
            {
                m_editCatalog = value;
                RaisePropertyChanged();
            
            }
        }

        public User EditUser
        {
            get => m_editUser;
            set
            {
                m_editUser = value;
                RaisePropertyChanged();

            }
        }

        public bool Status
        {
            get => m_status;
            set
            {
                m_status = value;
                RaisePropertyChanged();
            }
        }

        public User newUser
        {
            get => m_newUser;
            set
            {
                m_newUser = value;
                RaisePropertyChanged();
            }
        }

        public CommandBase m_command_AddBook { get; set; }
        public CommandBase m_command_RemoveBook { get; set; }
        public CommandBase m_command_AddUser { get; set; }
        public CommandBase m_command_RemoveUser { get; set; }

        public CommandBase m_command_Availible { get; set; }

        public CommandBase m_command_Borrow { get; set; }
        public CommandBase m_command_Return { get; set; }

        public CommandBase m_command_EditBook { get; set; }
        public CommandBase m_command_EditUser { get; set; }


        public MainWindowViewModel()
        {
            mainModel = new MainWindowModel();
            init();
        }

        private void init()
        {
            m_users = new ObservableCollection<User>(mainModel.myLibrary.USER);
            m_catalogs = new ObservableCollection<Catalog>(mainModel.myLibrary.CATALOG);

            m_command_AddUser = new CommandAddUser(this, this.mainModel.myLibrary);
            m_command_RemoveUser = new CommandDeleteUser(this, this.mainModel.myLibrary);

            m_command_AddBook = new CommandCreateBook(this, ref this.mainModel.myLibrary);

            m_command_RemoveBook = new CommandDeleteBook(this, this.mainModel.myLibrary);

            m_command_Availible = new CommandIsAvailible(this, this.mainModel.myLibrary);

            m_command_Borrow = new CommandBorrow(this, ref this.mainModel.myLibrary);

            m_command_Return = new CommandReturn(this, ref this.mainModel.myLibrary);
            m_command_EditBook = new CommandEditBook(this, ref this.mainModel.myLibrary);
            m_command_EditUser = new CommandEditUser(this, ref this.mainModel.myLibrary);
        }

    }

   
}
