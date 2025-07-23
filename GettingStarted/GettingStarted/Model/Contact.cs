using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GettingStarted
{
    public class Contact : INotifyPropertyChanged
    {
        #region Fields
        private string contactName;
        #endregion
        #region Properties
        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }
        #endregion

        #region Constructor

        public Contact()
        {

        }
        public Contact(string Name)
        {
            contactName = Name;
        }
        #endregion
        #region Interface Member
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
