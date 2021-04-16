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

        internal Vault Get(int id)
        {
            var data = _repo.Get(id);
            if (data == null)
            {
                throw new Exception("Invalid Id Aye");
            }
            return data;
        }

        internal Vault Create(Vault newVault)
        {
            newVault.Id = _repo.Create(newVault);
            return newVault;
        }

        internal object Edit(Vault editData, string userId)
        {
            Vault original = Get(editData.Id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot edit a Vault you did not create, get outta here"); }
            editData.Name = editData.Name == null ? original.Name : editData.Name;

            return _repo.Edit(editData);
        }

        internal string Delete(int id, string userId)
        {
            Vault original = Get(id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Vault you did not create, so stop trying"); }
            _repo.Remove(id);
            return "Vault deleted";
        }
    }
}