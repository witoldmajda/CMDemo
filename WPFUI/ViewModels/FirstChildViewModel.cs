using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;
using WPFUI.Views;

namespace WPFUI.ViewModels
{
    public class FirstChildViewModel : Screen
    {
        public FirstChildViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "John", LastName = "Cartney" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        private IEventAggregator eventAggregator;

        public FirstChildViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "John", LastName = "Cartney" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        private string _firstName = "Tim";

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _lastName = "Scout";

        public string LasttName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LasttName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LasttName} ";
            }

        }

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }

        private PersonModel _selectedPerson;
        

        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            //return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LasttName = "";
        }

        

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            //PM = new PersonModel();
            SelectedPerson = new PersonModel();

        }

        public void SendContent()
        {
            eventAggregator.PublishOnUIThread(SelectedPerson);
            SelectedPerson = new PersonModel();
            //_pm(SelectedPerson);
        }

        public delegate void UserDelegate(PersonModel personModel);
        public UserDelegate _pm;
    }
}
