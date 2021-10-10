using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechMovies.Helpers;
using TotalTechMovies.Models;

namespace TotalTechMovies.ViewModels
{
    
    public class MainPageViewModel : BaseViewModel
    {
        string APIKey = ConstantesHttp.ApiKey;

        private ObservableCollection<Result> results;
        public ObservableCollection<Result> Results { get => results; set { results = value; OnPropertyChanged(); } }

        private ObservableCollection<Result> resultsupcoming;
        public ObservableCollection<Result> ResultsUpComing { get => resultsupcoming; set { resultsupcoming = value; OnPropertyChanged(); } }

        private ObservableCollection<Result> resultspopular;
        public ObservableCollection<Result> ResultsPopular { get => resultspopular; set { resultspopular = value; OnPropertyChanged(); } }

        public async Task Load()
        {
            await LoadTopRated();
            await LoadUpComing();
            await LoadPopular();
        }
        /// <summary>
        /// Metodo que envia la url para el consumo de API de TOPRATE de peliculas
        /// </summary>
        /// <returns></returns>
        public async Task LoadTopRated()
        {
            try
            {
             
                ObservableCollection<Result> r;
                var url = string.Format( "https://api.themoviedb.org/3/movie/top_rated?api_key={0}&language=en-US&page=1",APIKey);
                var service = new HttpHelper<TopRated>();
                var toprated = await service.GetRestServiceDataAsyncTopRated(url);
                var LimitItems = toprated.results.Take(ConstantesHttp.NumData);
                Results = new ObservableCollection<Result>(LimitItems);

            }
            catch (Exception ex)
            {

            }        
        }

        /// <summary>
        /// Metodo que envia la url para el consumo de API de UPCOMING de peliculas
        /// </summary>
        /// <returns></returns>
        public async Task LoadUpComing()
        {
            try
            {
                var url = string.Format("https://api.themoviedb.org/3/movie/upcoming?api_key={0}&language=en-US&page=1",APIKey);
                var service = new HttpHelper<UpComing>();
                var upcoming = await service.GetRestServiceDataAsyncUpComing(url);
                var LimitItems = upcoming.results.Take(ConstantesHttp.NumData);
                ResultsUpComing = new ObservableCollection<Result>(LimitItems);

            }
            catch (Exception ex)
            {      
            }
            
            
        }
        /// <summary>
        /// Metodo que envia la url para el consumo de API de POPULAR de peliculas
        /// </summary>
        /// <returns></returns>
        public async Task LoadPopular()
        {
            try
            {
                var url = string.Format("https://api.themoviedb.org/3/movie/popular?api_key={0}&language=en-US&page=1",APIKey);
                var service = new HttpHelper<Popular>();
                var popular = await service.GetRestServiceDataAsyncUpComing(url);
                var LimitItems = popular.results.Take(ConstantesHttp.NumData);
                ResultsPopular = new ObservableCollection<Result>(LimitItems);
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
