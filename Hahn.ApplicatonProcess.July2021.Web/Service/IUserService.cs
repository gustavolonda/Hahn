using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using System;

namespace Hahn.ApplicatonProcess.July2021.Web.Service
{    /********************************************************
    *              Interface Asset Repository                *
    *********************************************************/
    public interface IUserService : IGenericService<User>
    {
        ResponseResult validador(User user, bool isInsert, int idWhereUpdate);
    }
}