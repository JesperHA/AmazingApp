using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AmazingApp.Models;

namespace AmazingApp.ViewModels
{
    class RelationViewModel : INotifyPropertyChanged
    {

        public RelationViewModel()
        {
            _relation = new Relation { RelationId = 1025775, name = "Nomeco", department = 202, incoterm = "DAP" };
        }

        Relation _relation;

        public Relation Relation
        {
            get
            {
                return _relation;
            }
            set
            {
                _relation = value;
            }
        }

        public int RelationId
        {
            get { return Relation.RelationId; }
            set
            {
                if (Relation.RelationId != value)
                {
                    Relation.RelationId = value;
                    RaisePropertyChanged("RelationId");
                }
            }
        }
        public string Name
        {
            get { return Relation.name; }
            set { Relation.name = value; }
        }
        public int Department
        {
            get { return Relation.department; }
            set { Relation.department = value; }
        }
        public string Incoterm
        {
            get { return Relation.incoterm; }
            set { Relation.incoterm = value; }
        }

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
