﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AmazingApp.Models;
using AmazingApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace AmazingApp.ViewModels
{
    class RelationViewModel : INotifyPropertyChanged
    {

        public ObservableRangeCollection<Relation> RelationList { get; }
        public Command LoadRelationListCommand { get; }

        RelationDataStore relationDataStore = new RelationDataStore();

        public RelationViewModel()
        {
            RelationList = new ObservableRangeCollection<Relation>();
            LoadRelationListCommand = new Command(async () => await ExecuteLoadRelationList());
        }


        public async Task ExecuteLoadRelationList()
        {

            try
            {
                RelationList.Clear();
                var items = await relationDataStore.GetRelationList();
                RelationList.AddRange(items);


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        //Relation _relation;

        //public Relation Relation
        //{
        //    get
        //    {
        //        return _relation;
        //    }
        //    set
        //    {
        //        _relation = value;
        //    }
        //}

        //public int RelationId
        //{
        //    get { return Relation.RelationId; }
        //    set
        //    {
        //        if (Relation.RelationId != value)
        //        {
        //            Relation.RelationId = value;
        //            RaisePropertyChanged("RelationId");
        //        }
        //    }
        //}
        //public string Name
        //{
        //    get { return Relation.name; }
        //    set { Relation.name = value; }
        //}
        //public int Department
        //{
        //    get { return Relation.department; }
        //    set { Relation.department = value; }
        //}
        //public string Incoterm
        //{
        //    get { return Relation.incoterm; }
        //    set { Relation.incoterm = value; }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
