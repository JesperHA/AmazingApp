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
    /// Interaction logic for InputView.xaml
    /// </summary>
    public partial class InputView : Page
    {

        RelationViewModel _viewModel;
        public InputView()
        {
            InitializeComponent();
            _viewModel = (RelationViewModel)base.DataContext;
        }

        private async void CreateRelation(object sender, RoutedEventArgs e)
        {
            int relationId = int.Parse(RelationId.Text);
            string name = Name.Text;
            int department = int.Parse(Department.Text);
            string incoterm = Incoterm.Text;

            //Debug.WriteLine("RelationId input: {0} \nName input: {1}\nDepartment input: {2}\nIncoterm input: {3}", RelationId.Text, Name.Text, Department.Text, Incoterm.Text);
            //Relation relation = new Relation { RelationId = relationId, Name = name, Department = department, Incoterm = incoterm };
            await _viewModel.CreateRelation(relationId, name, department, incoterm);

        }
    }
}
