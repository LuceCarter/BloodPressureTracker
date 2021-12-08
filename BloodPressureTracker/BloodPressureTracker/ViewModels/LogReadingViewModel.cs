using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BloodPressureTracker.Helpers;
using BloodPressureTracker.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms;
using Realms.Sync;
using User = BloodPressureTracker.Models.User;

namespace BloodPressureTracker.ViewModels
{
    public class LogReadingViewModel : BaseViewModel
    {
        public ICommand LogReadingCommand { get; set; }
        private Realms.Sync.App app;
        private User user;
        private Realm realm;
        private SyncConfiguration config;

        public LogReadingViewModel()
        {
            Title = "Log Blood Pressure Readings";
            LogReadingCommand = new AsyncCommand(() => LogReading());
        }        

        private string systolicEntry = "";
        public string SystolicEntry
        {
            get => systolicEntry;
            set => SetProperty(ref systolicEntry, value);
        }

        private string diastolicEntry = "";
        public string DiastolicEntry
        {
            get => diastolicEntry;
            set => SetProperty(ref diastolicEntry, value);
        }

        private string pulseEntry = "";
        public string PulseEntry
        {
            get => pulseEntry;
            set => SetProperty(ref pulseEntry, value);
        }

        private async Task LogReading()
        {  
            try
            {

                var currentTime = DateTime.Now.ToShortTimeString();
                var timeOfDay = "AM";
                int systolic;
                int diastolic;
                int pulse;

                systolic = Int32.Parse(SystolicEntry);
                diastolic = Int32.Parse(DiastolicEntry);
                pulse = Int32.Parse(PulseEntry);

                if (currentTime.ToLower().Contains("pm"))
                {
                    timeOfDay = "PM";
                }

                app = Realms.Sync.App.Create(AppSecrets.RealmAppId);
                config = new SyncConfiguration($"user={ app.CurrentUser.Id }", app.CurrentUser);
                realm = await Realm.GetInstanceAsync(config);

                var reading = new BloodPressureReading
                {
                    Date = DateTimeOffset.Parse(currentTime),
                    TimeOfDay = timeOfDay,
                    Systolic = systolic,
                    Diastolic = diastolic,
                    Pulse = pulse,
                    PartitionKey = app.CurrentUser.Id
                };

                      
                
             

                realm.Write(() =>
                {
                    realm.Add(reading);
                });

            } catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            
        }
    }
}
