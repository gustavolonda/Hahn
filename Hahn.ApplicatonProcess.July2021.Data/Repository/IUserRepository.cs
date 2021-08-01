using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{    /********************************************************
    *              Interface User Repository             *
    *********************************************************/
    public interface IUserRepository : IGenericRepository<User>
    {
         bool UserExists(int id);
         bool EmailExists(string email);
         bool EmailExistsByDiffrentId(int id, string email);
         User GetByUsername(string username);
    }
}