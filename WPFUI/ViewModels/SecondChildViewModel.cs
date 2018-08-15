using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class SecondChildViewModel : Screen, IHandle<PersonModel>
    {

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        private IEventAggregator eventAggregator;

        //FirstChildViewModel fcvm;


        public SecondChildViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            //fcvm._pm += Handle;
            
        }

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


        public void Handle(PersonModel message)
        {
            People.Add(message);
            NotifyOfPropertyChange(() => People);
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            People = new BindableCollection<PersonModel>();
            eventAggregator.Subscribe(this);
        }


    }
}
