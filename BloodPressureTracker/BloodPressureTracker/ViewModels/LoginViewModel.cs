using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BloodPressureTracker.Helpers;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Realms.Sync;

namespace BloodPressureTracker.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Realms.Sync.App app;
        private User user;

        public ICommand LoginCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }

        public LoginViewModel()
        {
            Title = "Login";
            LoginCommand = new AsyncCommand(Login);
            CreateAccountCommand = new AsyncCommand(CreateAccount);
        }

        private string emailEntry = "";
        public string EmailEntry
        {
            get => emailEntry;
            set => SetProperty(ref emailEntry, value);
        }

        private string passwordEntry = "";
        public string PasswordEntry
        {
            get => passwordEntry;
            set => SetProperty(ref passwordEntry, value);
        }

        public bool CheckIsLoggedIn()
        {            
            if (user.State == UserState.LoggedIn)
                return true;
            else
            {
                return false;
            }
        }

        private async Task Login()
        {
            try
            {
                app = Realms.Sync.App.Create(AppSecrets.RealmAppId);
                user = await app.LogInAsync(Credentials.EmailPassword(EmailEntry, PasswordEntry));

                if(user != null)
                {
                    await AppShell.Current.GoToAsync("///Main");
                    EmailEntry = "";
                    PasswordEntry = "";                    
                }
                else
                {
                    throw new Exception();
                }   
            } catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error logging in!", "Error: " + ex.Message, "OK");                
            }
        }

        private async Task CreateAccount()
        {
            try
            {
                app = Realms.Sync.App.Create(AppSecrets.RealmAppId);
                await app.EmailPasswordAuth.RegisterUserAsync(EmailEntry, PasswordEntry);
                await Login();

            } catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error creating account!", "Error: " + ex.Message, "OK");
            }
        }
    }
}
