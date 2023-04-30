using System.Threading.Tasks;

namespace Frankfurter.API.Client.Infraestructure
{
    public interface IFrankfurterClientHttpClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
