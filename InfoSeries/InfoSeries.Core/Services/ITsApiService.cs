using System.Collections.Generic;
using System.Threading.Tasks;
using InfoSeries.Core.Models;

namespace InfoSeries.Core.Services
{
    public interface ITsApiService
    {
        Task<List<SerieFollowersVM>> GetStatsTopSeries();
        Task<SerieVM> GetSerieByIdAll(int id);
        Task<SerieInfoVM> GetSerieById(int id);
        Task<List<SerieSearch>> GetSeriesSearch(string name);
        Task<SerieFollowersVM> GetStatsSerieHighlighted();
    }
}