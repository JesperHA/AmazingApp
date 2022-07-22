using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Relation> _RelationList;
        public ObservableCollection<Relation> RelationList
        {
            get { return _RelationList; }
            set
            {
                _RelationList = value;
                RaisePropertyChanged("RelationList");
            }
        }

        public Command LoadRelationListCommand { get; }

        RelationDataStore relationDataStore = new RelationDataStore();

        public RelationViewModel()
        {
            RelationList = new ObservableCollection<Relation>();
            LoadRelationListCommand = new Command(async () => await ExecuteLoadRelationList());
        }

        public async Task CreateRelation(int relationId, string name, int department, string incoterm)
        {

            try
            {
                Relation relation = new Relation { RelationId = relationId, Name = name, Department = department, Incoterm = incoterm };
                await relationDataStore.CreateRelation(relation);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateRelation(int relationId, string name, int department, string incoterm)
        {

            try
            {
                Relation relation = new Relation { RelationId = relationId, Name = name, Department = department, Incoterm = incoterm };
                await relationDataStore.UpdateRelation(relation);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task ExecuteLoadRelationList()
        {

            try
            {
                RelationList.Clear();
                var items = await relationDataStore.GetRelationList();
                foreach (var item in items)
                {
                    RelationList.Add(item);
                }
                
                Debug.WriteLine("Refreshed!");

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
