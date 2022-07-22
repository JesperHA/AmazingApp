using AmazingApp.Models;
using AmazingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmazingApp.Views
{
    /// <summary>
    /// Interaction logic for UpdateRelation.xaml
    /// </summary>
    public partial class UpdateRelation : Page
    {

        Relation _relation;
        BrushConverter bc = new BrushConverter();

        RelationViewModel _viewModel;
        public UpdateRelation(Relation relation)
        {
            InitializeComponent();
            _viewModel = (RelationViewModel)base.DataContext;
            _relation = relation;
            RelationId.Text = _relation.RelationId.ToString();
            Name.Text = _relation.Name;
            Department.Text = _relation.Department.ToString();
            Incoterm.Text = _relation.Incoterm;
        }

        private async void ClickUpdateRelation(object sender, RoutedEventArgs e)
        {

            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;



            try
            {
                int relationId = int.Parse(RelationId.Text);
                string name = Name.Text;
                int department = int.Parse(Department.Text);
                string incoterm = Incoterm.Text;
                try
                {

                    await _viewModel.UpdateRelation(relationId, name, department, incoterm);
                    Debug.WriteLine("Succes!");
                    alreadyExist.Visibility = Visibility.Hidden;
                    Brush brush = (Brush)bc.ConvertFrom("#34344b");
                    brush.Freeze();
                    RelationId.Background = brush;
                    Department.Background = brush;
                    OkImage.Visibility = Visibility.Visible;
                    sb.Begin(OkImage);

                }
                catch (SqlException error)
                {

                    if (error.Number == 2627)
                    {
                        alreadyExist.Visibility = Visibility.Visible;
                    }

                    Debug.WriteLine("Failed to insert to DB");
                    Debug.WriteLine(error);
                    ErrorImage.Visibility = Visibility.Visible;

                    sb.Begin(ErrorImage);
                }
            }
            catch (Exception)
            {

                Brush brush = (Brush)bc.ConvertFrom("#990000");
                brush.Freeze();

                RelationId.Background = brush;
                Department.Background = brush;
                Debug.WriteLine("Wrong input format!");
                ErrorImage.Visibility = Visibility.Visible;
                sb.Begin(ErrorImage);
            }






        }

    }
}
