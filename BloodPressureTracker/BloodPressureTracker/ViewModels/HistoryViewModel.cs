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
            config = new SyncConfiguration($"{ App.RealmApp.CurrentUser.Id }", App.RealmApp.CurrentUser);            
            realm = await Realm.GetInstanceAsync(config);
            Console.WriteLine(realm.All<User>());
            user = realm.Find<User>(App.RealmApp.CurrentUser.Id);            

            if(user == null)
            {
                await Task.Delay(5000);
                user = realm.Find<User>(App.RealmApp.CurrentUser.Id);

                if (user == null)
                {
                    Console.WriteLine("NO USER OBJECT: This error occurs if " +
                        "you do not have the trigger configured on the backend " +
                        "or when there is a network connectivity issue. See " +
                        "https://docs.mongodb.com/realm/tutorial/realm-app/#triggers");

                    await App.Current.MainPage.DisplayAlert("No User object",
                        "The User object for this user was not found on the server. " +
                        "If this is a new user acocunt, the backend trigger may not have completed, " +
                        "or the tirgger doesn't exist. Check your backend set up and logs.", "OK");
                }
            }

            if(user != null)
            {               
                BloodPressureReadings = new ObservableCollection<BloodPressureReading>(realm.All<BloodPressureReading>().ToList().Reverse<BloodPressureReading>());
            } 
        }        
    }
}
