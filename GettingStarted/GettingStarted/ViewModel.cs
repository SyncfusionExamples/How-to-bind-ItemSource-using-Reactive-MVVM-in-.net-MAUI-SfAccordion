using ReactiveUI;
using System.Collections.ObjectModel;


namespace GettingStarted
{
    public class ViewModel : ReactiveObject
    {
        private ObservableCollection<ContactInfo> contacts;
        #region Properties
        public ObservableCollection<ContactInfo> Contacts
        {
            get
            {
                return this.contacts;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref contacts, value);
            }
        }
        public Command<object> TapCommand { get; set; }

        #endregion

        #region Constructor

        public ViewModel()
        {
            Contacts = new ObservableCollection<ContactInfo>();
            TapCommand = new Command<object>(OnTapped);
            Contacts.Add(new ContactInfo() { Type = "A", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Adam" }, new Contact { ContactName = "Aaron" } } });
            Contacts.Add(new ContactInfo() { Type = "B", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Bolt" }, new Contact { ContactName = "Bush" } } });
            Contacts.Add(new ContactInfo() { Type = "C", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Clark" }, new Contact { ContactName = "Clara" } } });
        }

        #endregion

        #region Private Methods

        private void OnTapped(object obj)
        {

            var data = obj as Contact;
            App.Current.MainPage.DisplayAlert("Message", "Tapped Accoridon item is : " + data.ContactName, "Ok");
        }
        #endregion
    }
}
