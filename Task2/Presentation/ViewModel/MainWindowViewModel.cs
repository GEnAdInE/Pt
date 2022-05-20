using Task2.Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.DataLayer;
using System.Collections.ObjectModel;
using Task2.Presentation.ViewModel.Base;

namespace Task2.Presentation.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private ObservableCollection<User> ?m_users;
        public ObservableCollection<User> Users
        {
            get => m_users;
            set
            {
                m_users = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Catalog> ?m_catalogs;
        public ObservableCollection<Catalog> Catalogs
        {
            get => m_catalogs;
            set
            {
                m_catalogs = value;
                RaisePropertyChanged();
            }
        } 

        private User ?m_user;
        public User SelectedUser
        {
            get => m_user;
            set
            {
                m_user = value;
                RaisePropertyChanged();
            }
        }

        private Catalog ?m_catalog;
        private bool m_status;
        private User m_newUser = new User("", "");

        public Catalog SelectedCatalog
        {
            get => m_catalog;
            set
            {
                m_catalog = value;
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

        public RelayCommand ?FetchDataCommand
        {
            get; private set;
        }

        public RelayCommand ?FetechAvaibilityCommand
        {
            get; private set;
        }

        public RelayCommand? BorrowCommand
        {
            get; private set;
        }

        public RelayCommand? ReturnCommand
        {
            get; private set;
        }

        public RelayCommand? AddCatalogCommand
        {
            get; private set;
        }

        public RelayCommand? AddUserCommand
        {
            get; private set;
        }

        public RelayCommand? EditCatalogCommand
        {
            get; private set;
        }

        public RelayCommand? EditUserCommand
        {
            get; private set;
        }


        public MainWindowViewModel()
        {
            
          //NEED TO FETCH DATA ETC IDK HOW TO
            FetchDataCommand = new RelayCommand(() => { });//TODO 
            AddUserCommand = new RelayCommand (() =>
            {
                m_users.Add(new User(newUser.Name, newUser.Surname));
            });
            FetechAvaibilityCommand = new RelayCommand(() => { Status = !Status; });//TODO
            m_catalogs = new ObservableCollection<Catalog> { new Catalog("tp", "td"), new Catalog("La vie", "Arthuer") };//REMOVE
            m_users = new ObservableCollection<User> { new User("User1", "Toto"), new User("RObin", "Moulinou") };//REMOVE


        }

    }

   
}
