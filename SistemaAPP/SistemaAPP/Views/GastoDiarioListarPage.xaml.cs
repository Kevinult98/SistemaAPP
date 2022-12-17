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
    public partial class GastoDiarioListarPage : ContentPage
    {
        TipoGastoViewModel gastoViewModel;
        public GastoDiarioListarPage()
        {
            InitializeComponent();
            BindingContext = gastoViewModel = new TipoGastoViewModel();
            LoadList();
        }

        private async void LoadList()
        {
            LstGasto.ItemsSource = await gastoViewModel.GetQList();
        }
        
    }
}