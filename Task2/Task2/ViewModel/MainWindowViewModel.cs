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

        private MainWindowModel mainModel = new MainWindowModel();

        private ObservableCollection<Users> m_users;
        public ObservableCollection<Users> Users
        {
            get => m_users;
            set
            {
                m_users = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Catalogs> m_catalogs;
        public ObservableCollection<Catalogs> Catalogs
        {
            get => m_catalogs;
            set
            {
                m_catalogs = value;
                RaisePropertyChanged();
            }
        } 

        private Users m_user;
        public Users SelectedUser
        {
            get => m_user;
            set
            {
                m_user = value;
                RaisePropertyChanged();
            }
        }

        private Catalogs m_catalog;
        private bool m_status;
        private Users m_newUser = new Users();

        public Catalogs SelectedCatalog
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

        public Users newUser
        {
            get => m_newUser;
            set
            {
                m_newUser = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand FetchDataCommand
        {
            get; private set;
        }

        public RelayCommand FetechAvaibilityCommand
        {
            get; private set;
        }

        public RelayCommand BorrowCommand
        {
            get; private set;
        }

        public RelayCommand ReturnCommand
        {
            get; private set;
        }

        public RelayCommand AddCatalogCommand
        {
            get; private set;
        }

        public RelayCommand AddUserCommand
        {
            get; private set;
        }

        public RelayCommand EditCatalogCommand
        {
            get; private set;
        }

        public RelayCommand EditUserCommand
        {
            get; private set;
        }


        public MainWindowViewModel()
        {
            mainModel.setDataContext();
            
          //NEED TO FETCH DATA ETC IDK HOW TO
            FetchDataCommand = new RelayCommand(() => { });//TODO 
            AddUserCommand = new RelayCommand (() =>
            {
                //m_users.Add(new User(newUser.Name, newUser.Surname));
            });
            FetechAvaibilityCommand = new RelayCommand(() => { Status = !Status; });//TODO
            //m_catalog = new ObservableCollection<Catalogs>(mainModel.businessLogicAPI.dataAPI.Catalogs) ;//REMOVE
            m_users = new ObservableCollection<Users>(mainModel.businessLogicAPI.dataAPI.Users);//REMOVE


        }

    }

   
}
