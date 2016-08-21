using System.Collections.Generic;
using System.Threading.Tasks;
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
            return await Get<List<SerieFollowersVM>>("Stats/TopSeries");
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
