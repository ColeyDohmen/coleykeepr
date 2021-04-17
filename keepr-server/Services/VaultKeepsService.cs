using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Repositories;

namespace keepr_server.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        private readonly VaultsRepository _vrepo;

        public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vrepo)
        {
            _repo = repo;
            _vrepo = vrepo;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            Vault vault = _vrepo.GetById(newVaultKeep.VaultId);
            if (vault == null)
            {
                throw new Exception("Not a valid vault dude");
            }
            if (vault.CreatorId != newVaultKeep.CreatorId)
            {
                throw new Exception("You are not the owner of this vault buddy");
            }

            return _repo.Create(newVaultKeep);
        }

        internal void Delete(int id, string userId)
        {
            VaultKeep keep = _repo.GetById(id);
            if (keep == null)
            {
                throw new Exception("Invalid aye");
            }
            if (keep.CreatorId != userId)
            {
                throw new Exception("Invalid User");
            }
            _repo.Delete(id);
        }
    }
}