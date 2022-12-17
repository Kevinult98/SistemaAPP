using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SistemaAPP.ViewModels;
using SistemaAPP.Models;

namespace SistemaAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {
        UserViewModel viewModel;
        public UserRegisterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadRoles();
        }
      
        private void CmdSeePassword(object sender, ToggledEventArgs e)
        {
            if (VerPass.IsToggled)
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

            try
            {
                if (TxtName.Text != null && TxtId.Text != null && TxtNumber.Text != null && TxtEmail.Text != null && TxtPassword.Text != null && TxtDireccion.Text != null)
                {
                    var tipo = CboTipoUsuario.SelectedItem as Models.TipoUsuario;
                    int id = tipo.IdTipoUsuario;
                    bool R = await viewModel.AddUser(TxtName.Text.Trim(),
                                                                TxtId.Text.Trim(),
                                                                TxtNumber.Text.Trim(),
                                                                TxtEmail.Text.Trim(),
                                                                TxtPassword.Text.Trim(),
                                                                TxtDireccion.Text.Trim(),
                                                                id,
                                                                TxtUserName.Text.Trim()
                                                                );

                    if (R)
                    {
                        await DisplayAlert("!!!", "Usuario agregado correctamente :)", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert(":(", "Hubo un error al agregar el usuario :(", "OK");
                    }
                }
                else
                {
                    await DisplayAlert(":(", "Necesita llenar todos los datos:(", "OK");
                }
            }
            catch (Exception)
            {

                throw;
            }     
           
        }

        private async void CmdCancel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void LoadRoles()
        {
            CboTipoUsuario.ItemsSource = await viewModel.GetQListTipo();
        }
    }
}