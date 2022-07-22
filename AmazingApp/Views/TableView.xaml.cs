using AmazingApp.Models;
using AmazingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmazingApp.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : Page
    {

        RelationViewModel _viewModel;
        public TableView()
        {
            InitializeComponent();
            _viewModel = (RelationViewModel)base.DataContext;

            Loaded += TableView_Loaded;
            relations.ItemsSource = _viewModel.RelationList;
        }

        protected void ItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var relation = ((ListViewItem)sender).Content as Relation;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new UpdateRelation(relation));
        }

        private async void TableView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.ExecuteLoadRelationList();

        }

    }
}
