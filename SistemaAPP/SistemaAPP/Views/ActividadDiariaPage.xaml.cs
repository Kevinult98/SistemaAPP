using SistemaAPP.Models;
using SistemaAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActividadDiariaPage : ContentPage
    {
        TipoActividadViewModel MyActividad { get; set; }
        VehiculoViewModel MyVehiculo { get; set; }

        GastoVIewModel MyGasto { get; set; }

        ActividadDiariaViewModel MyDiaria { get; set; }
        public ActividadDiariaPage()
        {
            InitializeComponent();
            BindingContext = MyActividad = new TipoActividadViewModel();
            BindingContext = MyVehiculo = new VehiculoViewModel();
            BindingContext = MyGasto = new GastoVIewModel();
            BindingContext = MyDiaria = new ActividadDiariaViewModel();
            LoadTipos();
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionsPage());
        }

        private async void BtnListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarActividadDiariaPage());
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {

                    var g = CboGastoDiario.SelectedItem as Models.GastoDiario;
                    int gasto = g.Idgasto;

                    var t = CboTipoActividad.SelectedItem as Models.TipoActividad;        
                    int actividad = t.Idtipo;

                    var k = CboVehiculo.SelectedItem as Models.Vehiculo;
                    int vehiculo = k.Idvehiculo;

                    int horaEntrada = (int)Convert.ToInt64(TxtHoraENtrada.Text);
                    int horaSalida = (int)Convert.ToInt64(TxtHoraSalida.Text);
                    string desc = TxtDescripcion.Text;
                    bool R = await MyDiaria.AddActividad(horaEntrada,
                                                         horaSalida,
                                                         TxtLugar.Text.Trim(),gasto,actividad,vehiculo,desc
                                                         );
                    if (R)
                    {
                        await DisplayAlert("!!!", "Se creo guardo la actividad correctamente", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert(":(", "Hubo un error al agregar la actividad :(", "OK");
                    }
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        private async void BtnGasto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GastoDiario());
        }

        private async void LoadTipos()
        {
            CboTipoActividad.ItemsSource = await MyActividad.GetQListTipo();
            CboVehiculo.ItemsSource = await MyVehiculo.GetQListTipo();
            CboGastoDiario.ItemsSource = await MyGasto.GetGasto();
        }

    }
}