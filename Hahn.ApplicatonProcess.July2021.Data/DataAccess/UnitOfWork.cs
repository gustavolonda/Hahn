using Hahn.ApplicatonProcess.July2021.Data.DataAccess; 

using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
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
        public IUserRepository userRepository;
        public IAssetRepository assetRepository;
        // Init
        public UnitOfWork(AppDbContext context,ILoggerFactory loggerFactory)
        {
            this._context = context;
             this._logger  = loggerFactory.CreateLogger("logs");
        
        }
        public IUserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(_context, _logger);
                }
                return userRepository;
            }
        }

        public IAssetRepository AssetRepository
        {
            get
            {

                if (this.assetRepository == null)
                {
                    this.assetRepository = new AssetRepository(_context, _logger);
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