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

        internal IEnumerable<VaultKeep> GetAll()
        {
            string sql = "SELECT * FROM vaultkeeps;";
            return _db.Query<VaultKeep>(sql);
        }
    }
}