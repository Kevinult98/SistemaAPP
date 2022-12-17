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
    public partial class ActionsPage : ContentPage
    {
        public ActionsPage()
        {
            InitializeComponent();
        }

        private async void BtnViewUsers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewUsers());
        }

        private async void BtnLabores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActividadDiariaPage());
        }

        private async void BtnEquipo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EquipoListarPage());
        }

        private async void BtnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}