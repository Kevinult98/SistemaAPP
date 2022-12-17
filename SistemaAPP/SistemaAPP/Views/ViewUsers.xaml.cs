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
    public partial class ViewUsers : ContentPage
    {
        UserViewModel userViewModel;

        public ViewUsers()
        {
            InitializeComponent();

            BindingContext = userViewModel = new UserViewModel();

            LoadList();

        }
        private async void LoadList()
        {
            LstUsers.ItemsSource = await userViewModel.GetQList();
        }
    }
}