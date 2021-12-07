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
        private Realms.Sync.App app;
        private Realms.Sync.User user;        
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
            config = new SyncConfiguration($"user={ app.CurrentUser.Id }", app.CurrentUser);            
            realm = await Realm.GetInstanceAsync(config);
            //user = realm.Find<User>(app.CurrentUser.Id);

            BloodPressureReadings = new ObservableCollection<BloodPressureReading>(realm.All<BloodPressureReading>().ToList().Reverse<BloodPressureReading>());
            
        }        
    }
}
