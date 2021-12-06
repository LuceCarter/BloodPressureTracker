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

namespace BloodPressureTracker.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private Realms.Sync.App app;
        private User user;
        private Realm realm;
        private SyncConfiguration config;
        private ObservableCollection<BloodPressureReading> bloodPressureReadings;      

        public HistoryViewModel()
        {
            Title = "History";           
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
            app = Realms.Sync.App.Create(AppSecrets.RealmAppId);
            user = await app.LogInAsync(Credentials.Anonymous());
            config = new SyncConfiguration("myPartition", user);
            
            realm = await Realm.GetInstanceAsync(config);            

            BloodPressureReadings = new ObservableCollection<BloodPressureReading>(realm.All<BloodPressureReading>().ToList());
            
        }        
    }
}
