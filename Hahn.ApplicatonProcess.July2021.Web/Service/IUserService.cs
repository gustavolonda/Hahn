using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Threading.Tasks;
namespace Hahn.ApplicatonProcess.July2021.Web.Service
{    /********************************************************
    *                 Interface User Service                 *
    *********************************************************/
    public interface IUserService : IGenericService<User>
    {
        ResponseResult validador(User user, bool isInsert, int idWhereUpdate);
        ResponseResult Authenticate(AuthenticateRequest model);
        Task<ResponseResult>  Register(RegisterRequest model);
    }
}