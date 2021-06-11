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
        ///<summary>
        ///Creates new Vault-Keep, if the vault is null it will throw an error, if you are not the original
        /// creator, an error will be thrown.
        ///</summary>
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

        ///<summary>
        ///Deletes Vault-Keep, checks that the vault-keep is an actual vault-keep, then it checks if the user is
        /// the original creator of said vault-keep.
        ///</summary>
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