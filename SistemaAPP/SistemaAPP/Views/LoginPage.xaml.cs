using SistemaAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserViewModel Vm;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = Vm = new UserViewModel();
            Vm = new UserViewModel();
        }

        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (SwSeePassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void CmdUserRegister(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (TxtUserName.Text.Trim() != "" || TxtPassword.Text.Trim() != "")
                {
                    bool R = await Vm.ValidateUserAcces(TxtUserName.Text.Trim(), TxtPassword.Text.Trim());
                    if (R)
                    {
                        await DisplayAlert(":D", "Usuario Correcto", "OK");

                        await Navigation.PushAsync(new ActionsPage());
                    }
                    else
                    {
                        await DisplayAlert(":(", "Usuario o contraseña incorrectos!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert(":D", "Debe Ingresar Usuario o Contraseña", "OK");
                }
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
           
        }
    }
}