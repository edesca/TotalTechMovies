using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechMovies.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotalTechMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        String Id=string.Empty;
        public MoviePage(string id)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Id = id;
        }
        public MovieViewModel ViewModel { get; set; }
        public MoviePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MovieViewModel();
            await ViewModel.Load(Id);
            this.BindingContext = ViewModel;

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }
    }
}