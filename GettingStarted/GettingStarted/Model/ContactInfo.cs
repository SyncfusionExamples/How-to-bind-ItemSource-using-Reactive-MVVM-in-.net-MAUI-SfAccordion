using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GettingStarted
{
    public class ContactInfo
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public string Type { get; set; }
    }
}
