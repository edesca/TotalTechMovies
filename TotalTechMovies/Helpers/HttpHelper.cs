using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TotalTechMovies.Models;

namespace TotalTechMovies.Helpers
{
    /// <summary>
    /// Constantes para la configuracion de API
    /// </summary>
    public class ConstantesHttp
    {
        public const string ApiKey = "a91863bce37b979e6c21aa189874ff41";
        public const int NumData = 10;
    }
    /// <summary>
    /// Clase HttpHelper en donde se generan la peticion y obtencion de los datos de la API en formato Json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpHelper<T>
    {
        /// <summary>
        /// Metodo para obtener los datos de TOPRATES de peliculas reciviendo la URL de la API
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        public async Task<TopRated> GetRestServiceDataAsyncTopRated(string serviceAddress)
        {
            TopRated result = null;
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serviceAddress);
                var response = await client.GetAsync(serviceAddress);

                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<TopRated>(jsonResult);
            }
            catch (Exception ex)
            {


            }

            return result;
        }

        /// <summary>
        /// Metodo para obtener los datos de UPCOMING de peliculas reciviendo la URL de la API
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        public async Task<UpComing> GetRestServiceDataAsyncUpComing(string serviceAddress)
        {
            UpComing result = null;
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serviceAddress);
                var response = await client.GetAsync(serviceAddress);

                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<UpComing>(jsonResult);
            }
            catch (Exception ex)
            {


            }

            return result;
        }

        /// <summary>
        /// Metodo para obtener los datos de POPULAR de peliculas reciviendo la URL de la API
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        public async Task<Popular> GetRestServiceDataAsyncPopular(string serviceAddress)
        {
            Popular result = null;
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serviceAddress);
                var response = await client.GetAsync(serviceAddress);

                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<Popular>(jsonResult);
            }
            catch (Exception ex)
            {


            }

            return result;
        }
        /// <summary>
        /// Metodo para obtener los datos de DETALLE de peliculas reciviendo la URL de la API
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        public async Task<MovieDetails> GetRestServiceDataAsyncMovie(string serviceAddress)
        {
            MovieDetails result = null;
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serviceAddress);
                var response = await client.GetAsync(serviceAddress);

                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<MovieDetails>(jsonResult);
            }
            catch (Exception ex)
            {


            }

            return result;
        }
        /// <summary>
        /// Metodo para obtener los datos de CREDITOS de peliculas reciviendo la URL de la API
        /// </summary>
        /// <param name="serviceAddress"></param>
        /// <returns></returns>
        public async Task<MovieCredit> GetRestServiceDataAsyncCredits(string serviceAddress)
        {
            MovieCredit result = null;
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(serviceAddress);
                var response = await client.GetAsync(serviceAddress);

                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<MovieCredit>(jsonResult);
            }
            catch (Exception ex)
            {


            }

            return result;
        }
    }
}
