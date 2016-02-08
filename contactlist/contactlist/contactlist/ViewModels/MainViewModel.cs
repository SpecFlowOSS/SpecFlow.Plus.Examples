using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class MainViewModel : ViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        private readonly Database _database;
        private string _searchString;

        public MainViewModel()
        {
            _database = new Database();
            Contacts = new ObservableCollection<Contact>(_database.SearchContacts(""));
            AddCommand = new Command(ShowAddWindow);
        }

        private void ShowAddWindow()
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof (NewContactPage));
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                Search(value);
                OnPropertyChanged();
            }
        }

        private void Search(string value)
        {
            Contacts.Clear();

            var result = _database.SearchContacts(value);
            result.ForEach(Contacts.Add);
        }

        public ICommand AddCommand { get; set; }


        public void Refresh()
        {
            Search(SearchString);
        }
    }
}
