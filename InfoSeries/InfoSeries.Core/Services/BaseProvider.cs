using System;
using System.Net.Http;
using System.Threading.Tasks;
using InfoSeries.Core.Exceptions;

namespace InfoSeries.Core.Services
{
    public class BaseProvider
    {
        protected string _baseUrl;

        protected HttpClient GetClient()
        {
            return GetClient(_baseUrl);
        }

        protected virtual HttpClient GetClient(string baseUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            return client;
        }

        protected async Task Get(string url)
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsAsync<TrackSeriesApiError>();
                        throw new TrackSeriesApiException(error.Message, response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new TrackSeriesApiException("", false, ex);
                }
            }
        }

        protected async Task<T> Get<T>(string url)
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsAsync<TrackSeriesApiError>();
                        var message = error != null ? error.Message : "";
                        throw new TrackSeriesApiException(message, response.StatusCode);
                    }
                    return await response.Content.ReadAsAsync<T>();
                }
                catch (HttpRequestException ex)
                {
                    throw new TrackSeriesApiException("", false, ex);
                }
                catch (UnsupportedMediaTypeException ex)
                {
                    throw new TrackSeriesApiException("", false, ex);
                }
            }
        }
    }
}
