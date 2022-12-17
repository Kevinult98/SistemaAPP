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
    public partial class GastoDiario : ContentPage
    {
        GastoVIewModel viewModel;
        public GastoDiario()
        {
            InitializeComponent();
            BindingContext = viewModel = new GastoVIewModel();
            LoadList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActividadDiariaPage());
        }

        private async void BtnListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GastoDiarioListarPage());
            
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {

            if (TxtDescripcion.Text != null && TxtTotal.Text != null)
            {
                float total;

                total = int.Parse(TxtTotal.Text);

                bool R = await viewModel.AddGasto(TxtDescripcion.Text.Trim(), total);
                if (R)
                {
                    await DisplayAlert("!!!", "Gasto agregado correctamente :)", "OK");
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
        private async void LoadList()
        {
            CboTipoGasto.ItemsSource = await viewModel.GetQListTipo();
        }
    }
}