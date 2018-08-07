using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    public interface IUserService
    {
        Task<List<User>> getAll() ;

        Task<string> getPort();
    }
}