using AmazingApp.ViewModels;
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
using AmazingApp.ViewModels;
using System.Diagnostics;
using AmazingApp.Views;

namespace AmazingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        RelationViewModel _viewModel;
        TableView _tableView;
        InputView _inputView;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (RelationViewModel)base.DataContext;
            headerText.Content = "Home";
            //DataContext = new RelationViewModel();
        }

        private async void ButtonLoadRelations(object sender, RoutedEventArgs e)
        {
            headerText.Content = "Relations";
            await _viewModel.ExecuteLoadRelationList();

            FrameContent.NavigationService.RemoveBackEntry();
            if (_tableView == null)
            {
                _tableView = new TableView();
                
            }
            FrameContent.Navigate(_tableView);

        }

        private void ResetViews(object sender, RoutedEventArgs e)
        {
            headerText.Content = "Home";
            FrameContent.NavigationService.RemoveBackEntry();
            FrameContent.Navigate(null);
        }

        private void ButtonCreateRelation(object sender, RoutedEventArgs e)
        {
            headerText.Content = "Create new relation";
            FrameContent.NavigationService.RemoveBackEntry();
            if (_inputView == null)
            {
                _inputView = new InputView();

            }
            FrameContent.Navigate(_inputView);
        }
    }
}
