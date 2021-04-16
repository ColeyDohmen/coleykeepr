using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr_server.Models;
using keeprcoley.Models;

namespace keepr_server.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> GetAll()
        {
            string sql = @"
            SELECT
            keep.*,
            profile.*
            FROM keeps keep
            JOIN profiles profile ON keep creatorId = profile.id;";
            return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
            {
                keep.Creator = profile; return keep;
            }, splitOn: "id");
        }
    }
}