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
    public class MovieViewModel : BaseViewModel
    {
        string APIKey = ConstantesHttp.ApiKey;
        public MovieDetails Detail { get; set; }

        private ObservableCollection<Crew> resultcredit;
        public ObservableCollection<Crew> ResultsCredit { get => resultcredit; set { resultcredit = value; OnPropertyChanged(); } }

        public async Task Load(string id)
        {
            await LoadDetail(id);
            await LoadCredit(id);
        }
        /// <summary>
        /// Metodo que envia la url para el consumo de API de Detalle de pelicula
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task LoadDetail(string id)
        {
            try
            {
                //IsBusy = true;
                var url = string.Format( "https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-US",id,APIKey);
                var service = new HttpHelper<MovieDetails>();
                Detail = await service.GetRestServiceDataAsyncMovie(url);
                
                //IsBusy = false;
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Metodo que envia la url para el consumo de API de Credit de pelicula
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task LoadCredit(string id)
        {
            try
            {
                //IsBusy = true;
                var url = string.Format("https://api.themoviedb.org/3/movie/{0}/credits?api_key={1}&language=en-US",id,APIKey);
                var service = new HttpHelper<MovieCredit>();
                var credit = await service.GetRestServiceDataAsyncCredits(url);
                var LimitItems = credit.crew.Take(ConstantesHttp.NumData);
                ResultsCredit = new ObservableCollection<Crew>(LimitItems);

                //IsBusy = false;
            }
            catch (Exception ex)
            {

            }

        }
    }
}
