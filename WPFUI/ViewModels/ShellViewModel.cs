using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    //public class ShellViewModel : Screen   - Dziedziczenie po Screen jest dobre dla jednego okna, dla wielu okien lepsze jest Conductor
    public class ShellViewModel : Conductor<object>
    {

        IEventAggregator eventAggregator = new EventAggregator();
        public FirstChildViewModel FirstChild { get; private set; }
        public SecondChildViewModel SecondChild { get; private set; }
        //public SecondChildViewModel RightPanel { get; private set; }

        public ShellViewModel()
        {
            FirstChild = new FirstChildViewModel(eventAggregator);
            SecondChild = new SecondChildViewModel(eventAggregator);
        }









        public void LoadPageOne()
        {
            //ActivateItem(new FirstChildViewModel());
            ActivateItem(new FirstChildViewModel(eventAggregator));            
            //FirstChild = new FirstChildViewModel(eventAggregator);
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel(eventAggregator));
        }


    }
}
