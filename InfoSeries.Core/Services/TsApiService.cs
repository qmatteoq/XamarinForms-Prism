using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InfoSeries.Core.Exceptions;
using InfoSeries.Core.Models;

namespace InfoSeries.Core.Services
{
    public class TsApiService: BaseProvider, ITsApiService
    {
        public TsApiService()
        {
            _baseUrl = "https://api.trackseries.tv/v1/";
        }

public async Task<List<SerieFollowersVM>> GetStatsTopSeries()
{
    using (HttpClient client = GetClient())
    {
        try
        {
            var response = await client.GetAsync("https://api.trackseries.tv/v1/Stats/TopSeries");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<TrackSeriesApiError>();
                var message = error != null ? error.Message : "";
                throw new TrackSeriesApiException(message, response.StatusCode);
            }
            return await response.Content.ReadAsAsync<List<SerieFollowersVM>>();
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

        public async Task<SerieVM> GetSerieByIdAll(int id)
        {
            return await Get<SerieVM>($"Series/{id}/All");
        }

        public async Task<SerieInfoVM> GetSerieById(int id)
        {
            return await Get<SerieInfoVM>($"Series/{id}");
        }

        public async Task<List<SerieSearch>> GetSeriesSearch(string name)
        {
            return await Get<List<SerieSearch>>($"Series/Search?query={name}");
        }

        public async Task<SerieFollowersVM> GetStatsSerieHighlighted()
        {
            return await Get<SerieFollowersVM>("Stats/SerieHighlighted");
        }
    }
}
