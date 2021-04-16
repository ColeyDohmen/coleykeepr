using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Keep> GetAll()
        {
            return _repo.GetAll();
        }

        internal Keep GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal Keep Create(Keep newKeep)
        {
            throw new NotImplementedException();
        }

        internal object Edit(Keep editData, string id)
        {
            throw new NotImplementedException();
        }

        internal object Delete(int id1, string id2)
        {
            throw new NotImplementedException();
        }
    }
}