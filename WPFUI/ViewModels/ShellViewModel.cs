﻿using Caliburn.Micro;
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
       

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }


    }
}
