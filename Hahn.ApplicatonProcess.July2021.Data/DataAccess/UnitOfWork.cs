using Hahn.ApplicatonProcess.July2021.Data.DataAccess; 

using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using Hahn.ApplicatonProcess.July2021.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
namespace Hahn.ApplicatonProcess.July2021.Data.DataAccess
{   /********************************************************
    *             Implements Unit Of Work                   *
    *********************************************************/
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private readonly ILogger _logger;
        public IGenericRepository<User> userRepository;
        public IGenericRepository<Asset> assetRepository;
        // Init
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        
        }
        public IGenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_context, _logger);
                }
                return userRepository;
            }
        }

        public IGenericRepository<Asset> AssetRepository
        {
            get
            {

                if (this.assetRepository == null)
                {
                    this.assetRepository = new GenericRepository<Asset>(_context, _logger);
                }
                return assetRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}