using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vault> GetAll()
        {
            return _repo.GetAll();
        }

        internal Vault GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal Vault Create(Vault newVault)
        {
            throw new NotImplementedException();
        }
    }
}