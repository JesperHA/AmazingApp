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

namespace AmazingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        RelationViewModel _viewModel;
        int _count = 0;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (RelationViewModel)base.DataContext;
            //DataContext = new RelationViewModel();
        }

        private async void ButtonLoadRelations(object sender, RoutedEventArgs e)
        {
            await _viewModel.ExecuteLoadRelationList();

            relations.ItemsSource = _viewModel.RelationList;
            //foreach (var relation in _viewModel.RelationList)
            //{

            //    Grid g = new Grid();
            //    TextBlock tb = new TextBlock();

            //    tb.Text = relation.RelationId.ToString();
            //    g.Children.Add(tb);

            //    Debug.WriteLine("{0}", relation.RelationId);
            //}



        }
    }
}
