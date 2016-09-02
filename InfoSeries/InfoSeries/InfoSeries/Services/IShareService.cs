using System.Threading.Tasks;

namespace InfoSeries.Services
{
    public interface IShareService
    {
        Task SharePoster(string title, string image);
    }
}
