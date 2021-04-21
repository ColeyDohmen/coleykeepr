using System;
using System.Collections.Generic;
using System.Linq;
using keepr_server.Models;
using keepr_server.Repositories;
using keeprcoley.Models;

namespace keepr_server.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        private readonly KeepsRepository _krepo;

        public VaultsService(VaultsRepository repo, KeepsRepository krepo)
        {
            _repo = repo;
            _krepo = krepo;
        }

        internal IEnumerable<Vault> GetAll()
        {
            IEnumerable<Vault> vaults = _repo.GetAll();
            return vaults.ToList().FindAll(v => v.IsPrivate);
        }

        internal Vault Get(int id, Profile userInfo)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id Aye");
            }
            if (data.IsPrivate == true && data.CreatorId != userInfo?.Id)
            {
                throw new Exception("Get outta here, this is private");
            }
            return data;
        }

        internal Vault Create(Vault newVault)
        {
            newVault.Id = _repo.Create(newVault);
            return newVault;
        }

        internal Vault Edit(Vault editData, string userId)
        {
            Vault original = Get(editData.Id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot edit a Vault you did not create, get outta here"); }
            editData.Name = editData.Name == null ? original.Name : editData.Name;

            return _repo.Edit(editData);
        }

        internal IEnumerable<Vault> GetVaultsByAccountId(string id)
        {
            return _repo.GetByCreatorId(id);
        }

        private Vault Get(int id)
        {
            var data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id Aye");
            }
            if (data.IsPrivate == true)
            {
                throw new Exception("Get outta here, this is private");
            }
            return data;
        }

        internal string Delete(int id, string userId)
        {
            Vault original = Get(id);
            if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Delete a Vault you did not create, so stop trying"); }
            _repo.Remove(id);
            return "Vault deleted";
        }

        internal IEnumerable<Vault> GetByProfileId(string id)
        {
            IEnumerable<Vault> vaults = _repo.GetVaultsByProfileId(id);
            return vaults.ToList().FindAll(v => v.IsPrivate == false);
        }


        internal IEnumerable<VaultKeepViewModel> GetByVaultId(int id, Profile userInfo)
        {
            var data = _repo.GetById(id);
            if (data.IsPrivate == true && data.CreatorId != userInfo?.Id)
            {
                throw new Exception("Get outta here, this is private");
            }
            IEnumerable<VaultKeepViewModel> keeps = _krepo.GetKeepsByVaultId(id);
            return keeps.ToList();
        }
    }
}