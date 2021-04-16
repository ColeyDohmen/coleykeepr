using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;
using keeprcoley.Models;

namespace keepr_server.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> GetAll()
        {
            string sql = @"
            SELECT
            vault.*,
            profile.*
            FROM vaults vault
            JOIN profiles profile ON vault creatorId = profile.id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile; return vault;
            }, splitOn: "id");
        }
    }
}