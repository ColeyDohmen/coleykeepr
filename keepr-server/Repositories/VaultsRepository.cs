using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            JOIN profiles profile ON vault.creatorId = profile.id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, splitOn: "id");
        }

        internal int Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (creatorId, name, description, isPrivate)
            VALUES
            (@CreatorId, @Name, @Description, @IsPrivate);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newVault);
        }

        internal Vault GetById(int id)
        {
            string sql = @"
            SELECT
            vault.*,
            profile.*
            FROM vaults vault
            JOIN profiles profile ON vault.creatorId = profile.id
            WHERE vault.id = @id;";
            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Vault> GetByCreatorId(string id)
        {
            string sql = @"
            SELECT
            vault.*,
            pr.*
            FROM vaults vault
            JOIN profiles pr ON vault.creatorId = pr.id 
            WHERE vault.creatorId = @id;";

            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id");
        }

        internal IEnumerable<Vault> GetVaultsByProfileId(string id)
        {
            string sql = @"
            SELECT
            vault.*,
            pr.*
            FROM vaults vault
            JOIN profiles pr ON vault.creatorId = pr.id 
            WHERE vault.creatorId = @id;";

            return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
            {
                vault.Creator = profile;
                return vault;
            }, new { id }, splitOn: "id");
        }

        internal Vault Edit(Vault editData)
        {
            string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description
            WHERE id = @Id;";
            _db.Execute(sql, editData);
            return editData;
        }
    }
}