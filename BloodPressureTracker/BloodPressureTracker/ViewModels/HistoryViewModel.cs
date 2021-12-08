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
using Xamarin.Forms;
using User = BloodPressureTracker.Models.User;

namespace BloodPressureTracker.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {        
        private User user;        
        private Realm realm;
        private SyncConfiguration config;
        private ObservableCollection<BloodPressureReading> bloodPressureReadings;      

        public HistoryViewModel()
        {
            Title = "History";
            bloodPressureReadings = new ObservableCollection<BloodPressureReading>();
        }

        public ObservableCollection<BloodPressureReading> BloodPressureReadings
        {
            get => bloodPressureReadings;
            set => SetProperty(ref bloodPressureReadings, value);
        }       

        // Realm calls have to be run on the same thread so this is called from OnAppearing
        // in code-behind as this always uses a single thread.
        public async Task InitialiseRealm()
        {
                       
            config = new SyncConfiguration($"user={ App.RealmApp.CurrentUser.Id }", App.RealmApp.CurrentUser);            
            realm = await Realm.GetInstanceAsync(config);
            user = realm.Find<User>(App.RealmApp.CurrentUser.Id);

            if(user != null)
            {
                foreach(BloodPressureReading reading in user.Readings)
                {
                    BloodPressureReadings.Add(reading);
                }
                //BloodPressureReadings = new ObservableCollection<BloodPressureReading>(realm.All<BloodPressureReading>().Where(reading => reading.Id.ToString() == user.Id).ToList().Reverse<BloodPressureReading>());
            } 
        }        
    }
}
