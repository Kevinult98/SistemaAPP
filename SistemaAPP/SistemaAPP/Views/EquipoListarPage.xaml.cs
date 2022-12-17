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
    public partial class EquipoListarPage : ContentPage
    {
        EquipoViewModel equipoViewModel;
        public EquipoListarPage()
        {
            InitializeComponent();

            BindingContext = equipoViewModel = new EquipoViewModel();

            LoadList();
        }

        private async void LoadList()
        {
            LstEquipo.ItemsSource = await equipoViewModel.GetQList();
        }
    }
}