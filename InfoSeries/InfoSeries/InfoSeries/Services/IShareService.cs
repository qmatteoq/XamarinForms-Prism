using System.Threading.Tasks;

namespace InfoSeries.Services
{
    public interface IShareService
    {
        Task ShareShirt(string title, string image);
    }
}
