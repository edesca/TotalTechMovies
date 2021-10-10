using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechMovies.Models;
using TotalTechMovies.ViewModels;
using TotalTechMovies.Views;
using Xamarin.Forms;

namespace TotalTechMovies
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

       
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();
            await ViewModel.Load();
            this.BindingContext = ViewModel;

        }

        /// <summary>
        /// Metodo que genera los datos de busqueda de peliculas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel = new MainPageViewModel();
            int length = search.Text.Length;

            try
            {
                if (length >= 3)
                {
                    ViewModel = new MainPageViewModel();
                    await ViewModel.Load();

                    var TopRate = ViewModel.Results.Where(b => b.title.StartsWith(search.Text));
                    ViewTopRate.ItemsSource = TopRate;

                    var UpComing = ViewModel.ResultsUpComing.Where(b => b.title.StartsWith(search.Text));
                    ViewUpComing.ItemsSource = UpComing;

                    var Popular = ViewModel.ResultsPopular.Where(b => b.title.StartsWith(search.Text));
                    ViewPopular.ItemsSource = Popular;
                }
                else if (string.IsNullOrEmpty(search.Text))
                {
                    await ViewModel.LoadTopRated();

                    ViewTopRate.ItemsSource = ViewModel.Results;

                    await ViewModel.LoadUpComing();

                    ViewUpComing.ItemsSource = ViewModel.ResultsUpComing;

                    await ViewModel.LoadPopular();

                    ViewPopular.ItemsSource = ViewModel.ResultsPopular;
                }
            }
            catch (Exception ex)
            {

                
            }
        }

        /// <summary>
        /// Metodo SelectionChanged de CollectionView del Listado TOPRATE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewTopRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        string id =Convert.ToString( (e.CurrentSelection.FirstOrDefault() as Result)?.id);
           
            await Navigation.PushAsync(new MoviePage(id));
            Navigation.RemovePage(this);
        }
        /// <summary>
        /// Metodo SelectionChanged de CollectionView del Listado UPCOMING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewUpComing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = Convert.ToString((e.CurrentSelection.FirstOrDefault() as Result)?.id);
            await Navigation.PushAsync(new MoviePage(id));
            Navigation.RemovePage(this);
        }

        /// <summary>
        /// Metodo SelectionChanged de CollectionView del Listado POPULAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewPopular_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = Convert.ToString((e.CurrentSelection.FirstOrDefault() as Result)?.id);
            await Navigation.PushAsync(new MoviePage(id));
            Navigation.RemovePage(this);
        }
    }
}
