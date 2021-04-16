using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<VaultKeep> GetAll()
        {
            return _repo.GetAll();
        }
    }
}