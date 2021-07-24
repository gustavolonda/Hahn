using Hahn.ApplicatonProcess.July2021.Data.Models;
using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{    /********************************************************
    *              Interface User Repository             *
    *********************************************************/
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}