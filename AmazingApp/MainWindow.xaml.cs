﻿using AmazingApp.ViewModels;
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
        }

        private void ButtonUpdateRelation_Click(object sender, RoutedEventArgs e)
        {
            ++_count;
            _viewModel.RelationId = _count;
        }
    }
}