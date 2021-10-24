using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BloodPressureTracker.Helpers;
using BloodPressureTracker.Models;
using MvvmHelpers;
using Realms;
using Realms.Sync;

namespace BloodPressureTracker.ViewModels
{
    public class TrendsViewModel : BaseViewModel
    {
        

        public TrendsViewModel()
        {
            Title = "Trends";
        }
       
    }
}
