using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using contactlist.Data;
using contactlist.Entities;

namespace contactlist.ViewModels
{
    class ContactViewModel : ViewModel
    {
        private readonly Contact _contact;

        public ContactViewModel(Contact contact)
        {
            _contact = contact;
            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            var database = new Database();
            database.AddContact(_contact);

            var frame = Window.Current.Content as Frame;
            frame.GoBack();
        }

        public ICommand SaveCommand { get; set; }

        public string Firstname
        {
            get { return _contact.Firstname; }
            set
            {
                _contact.Firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get { return _contact.Lastname; }
            set
            {
                _contact.Lastname = value;
                OnPropertyChanged();
            }
        }

        public string EMail
        {
            get { return _contact.EMail; }
            set
            {
                _contact.EMail = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return _contact.EMail; }
            set
            {
                _contact.EMail = value;
                OnPropertyChanged();
            }
        }
    }
}
