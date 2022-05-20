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
        public Catalog SelectedCatalog
        {
            get => m_catalog;
            set
            {
                m_catalog = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand ?FetchDataCommend
        {
            get; private set;
        }


        public void MainWindowModel()
        {
            FetchDataCommend = new RelayCommand(() => { });

        }

    }

   
}
