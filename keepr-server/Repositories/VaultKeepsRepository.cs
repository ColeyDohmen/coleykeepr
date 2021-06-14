using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;
using keeprcoley.Models;

namespace keepr_server.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        ///<summary>
        ///Selects all vault-keeps then grabs the one with the id that it has been given.
        ///</summary>
        internal VaultKeep GetById(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        ///<summary>
        ///Creates a new vault-keep, giving it a vault id, a keep id, and a creator id.
        ///</summary>
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId, creatorId)
        VALUES
        (@VaultId, @KeepId, @CreatorId);
        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        ///<summary>
        ///Deletes a vault-keep where the id matches the one given, limits it to one.
        ///</summary>
        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}