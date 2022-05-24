using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;    
using System.Windows.Shapes;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel viewModel;
        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ICI");
        }

        private void CmbBoxBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.m_command_Availible.Execute(this);
            viewModel.EditCatalog = new Model.Catalog(viewModel.SelectedCatalog.Title, viewModel.SelectedCatalog.Author);
        }

        private void CmbBoxUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.EditUser = new Model.User(viewModel.SelectedUser.Name, viewModel.SelectedUser.Surname);

        }
    }
}
