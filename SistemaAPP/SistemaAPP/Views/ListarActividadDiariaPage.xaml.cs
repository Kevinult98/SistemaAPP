using SistemaAPP.Models;
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
    public partial class ListarActividadDiariaPage : ContentPage
    {
        ActividadDiariaViewModel viewModel;
        public ListarActividadDiariaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ActividadDiariaViewModel();

            LoadList();
        }

        private async void LoadList() 
        {
            LsActividad.ItemsSource = await viewModel.GetQListActividad();
        }
    }
}